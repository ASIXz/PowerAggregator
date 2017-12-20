using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PowerAgregator
{
    public class Core
    {
        public List<IChatPlugin> Chatters = new List<IChatPlugin>();
        public List<AgregatorUser> Users = new List<AgregatorUser>();
        public List<ChatterUser> ChatterUsers = new List<ChatterUser>();

        public event Action<IEnumerable<Message>, ChatterUser> MessageAdded;

        public Core()
        {
        }

        public void AddUser(ChatterUser source, string id)
        {
            var destination = new AgregatorUser(id);
            Users.Add(destination);

            AddUser(source, destination);
        }

        public void AddUser(ChatterUser source, AgregatorUser destination)
        {
            //ChatterUsers.Remove(source);
            destination.Chatters.Add(source);
            source.AgregatorUser = destination;
        }

        public IEnumerable<Message> GetChatMessages(ChatterUser user)
        {
            if (user.Messages == null || user.Messages.Count() == 0)
            {
                var chatter = user.Chatter;
                user.Messages = chatter.GetChatForUser(user).ToList();
            }
            return user.Messages;
        }

        public IEnumerable<Message> GetChatMessages(AgregatorUser user)
        {
            var Messages = new List<Message>().AsEnumerable();
            foreach (ChatterUser item in user.Chatters)
            {
                Messages = Messages.Concat(GetChatMessages(item));
            }
            Messages.OrderBy(x => x.Time);
            return Messages;
        }

        public IEnumerable<Message> GetChatMessages(AgregatorUser user, Action<ChatterUser> LoadStoredMessages)
        {
            foreach (ChatterUser item in user.Chatters)
            {
                LoadStoredMessages(item);
            }
            return GetChatMessages(user);
        }

        public IChatPlugin AddChatter(IChatPlugin ChatPlugin, string Name, string Id)
        {
            try
            {
                if (Chatters.Any(x => x.Id == Id)) return null;
                ChatPlugin.Initialize(Name, Id);
                ChatPlugin.MessageRecived += AddMessage;
                Chatters.Add(ChatPlugin);

                return ChatPlugin;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void RemoveChatter(string Id)
        {
            var Chatter = Chatters.First(x => x.Id == Id);
            Chatters.Remove(Chatter);
        }

        public void SendMessage(AgregatorUser user, string message)
        {
            if (user.ActiveDialog != null && user.DialogExpire < DateTime.Now)
            {
                SendMessage(user.ActiveDialog, message);
            }
            else
            {
                //Create sending engeine;
                foreach (ChatterUser item in user.Chatters)
                {
                    item.ClculateHistoricalRates();
                }
                var list = user.Chatters.OrderBy(x => x.ResponseTime.TotalSeconds * x.ActivityRate);
                var Tasks = list.Select(x => new Task(() =>
                {
                    if (user.ActiveDialog == null)
                    {
                        SendMessage(x, message);
                        Task.Delay(x.ResponseTime).Wait();
                    }
                })).ToArray();
                for (int i = 1; i < Tasks.Length; i++)
                {
                    Tasks[(i - 1) / 2].ContinueWith(((x, n) => Tasks[(int)n].Start()), i);
                }
                Tasks[0].Start();
            }
        }

        public void SendMessage(ChatterUser user, string message)
        {
            Message msg = new Message(user) { Time = DateTime.Now, Text = message, Recived = false };
            if (user.Chatter.SendMessage(ref msg))
            {
                AddMessage(new Message[] { msg }, user);
            }
        }

        public void AddMessage(IEnumerable<Message> messages, ChatterUser user)
        {
            if (user.AgregatorUser != null)
            {
                if (messages.Any(x =>x.Recived))
                {
                    user.AgregatorUser.ActiveDialog = user;
                    user.AgregatorUser.DialogExpire = DateTime.Now + user.ResponseTime;
                }
                else
                {
                    //if first output message
                    if (user.AgregatorUser.ActiveDialog == user && user.Messages.Last().Recived)
                    {//no update StartTime, just doble existing waiting time;
                        user.AgregatorUser.DialogExpire += user.ResponseTime;
                    }
                }
            }
            //user = ChatterUsers.First(x => x.UserId == user.UserId);
            user.Messages.AddRange(messages);
            MessageAdded?.Invoke(messages, user);
        }

        public bool ChangeUserKey(AgregatorUser user, string name)
        {
            if (string.IsNullOrWhiteSpace(name) || (Users.Any(x => x.Name == name))) return false;
            else
                user.Name = name;
            return true;
        }
    }
}
