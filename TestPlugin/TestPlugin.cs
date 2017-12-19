using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerAgregator;

namespace TestPlugin
{
    public class TestPlugin : PowerAgregator.IChatPlugin
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public bool Is2StepAuth { get { return false; } }

        public bool IsPassword { get { return false; } }

        public bool IsAutoResume { get { return false; } }

        public event Action<Message> MessageRecived;

        public IEnumerable<Message> GetChatForUser(ChatterUser user)
        {
            var Result = new Message[]
            {
                new Message()
                {
                    Recived = false,
                    Text= "Dialog Start!",
                    Time = new DateTime(2017,12,10,10,10,int.Parse(user.UserId)),
                    User = user
                },
                new Message()
                {
                    Recived = true,
                    Text= "Message 1!",
                    Time = new DateTime(2017,12,10,10,12,int.Parse(user.UserId)),
                    User = user
                },
                new Message()
                {
                    Recived = false,
                    Text= "Message 2!",
                    Time = new DateTime(2017,12,10,10,14,int.Parse(user.UserId)),
                    User = user
                },
                new Message()
                {
                    Recived = true,
                    Text= "Bye bye!",
                    Time = new DateTime(2017,12,10,10,17,int.Parse(user.UserId)),
                    User = user
                },
                new Message()
                {
                    Recived = false,
                    Text= "Dialog Start 2!",
                    Time = new DateTime(2017,12,11,10,10,int.Parse(user.UserId)),
                    User = user
                },
                new Message()
                {
                    Recived = true,
                    Text= "Message 1!",
                    Time = new DateTime(2017,12,11,10,12,int.Parse(user.UserId)),
                    User = user
                },
                new Message()
                {
                    Recived = false,
                    Text= "Message 2!",
                    Time = new DateTime(2017,12,11,10,14,int.Parse(user.UserId)),
                    User = user
                },
                new Message()
                {
                    Recived = true,
                    Text= "Bye bye 2!",
                    Time = new DateTime(2017,12,11,10,17,int.Parse(user.UserId)),
                    User = user
                },
                new Message()
                {
                    Recived = true,
                    Text= "Dialog Start 3!",
                    Time = new DateTime(2017,12,11,11,10,int.Parse(user.UserId)),
                    User = user
                },
                new Message()
                {
                    Recived = false,
                    Text= "Message 1!",
                    Time = new DateTime(2017,12,11,11,12,int.Parse(user.UserId)),
                    User = user
                },
                new Message()
                {
                    Recived = true,
                    Text= "Message 2!",
                    Time = new DateTime(2017,12,11,11,14,int.Parse(user.UserId)),
                    User = user
                },
                new Message()
                {
                    Recived = false,
                    Text= "Bye bye 3!",
                    Time = new DateTime(2017,12,11,11,17,int.Parse(user.UserId)),
                    User = user
                }
            };

            foreach (Message msg in Result)
            {
                msg.Time = msg.Time.AddHours(-7).AddMinutes(2);
            }

            return Result;
        }

        public IEnumerable<Message> GetChatForUser(ChatterUser user, DateTime LastMessage)
        {
            throw new NotImplementedException();
        }

        public byte[] GetImage(ChatterUser user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ChatterUser> GetUsers()
        {
            return new ChatterUser[]
            {

                new ChatterUser()
                {
                    Chatter = this,
                    Name = "Alex Herasemchuk",
                    UserId = "0"
                },
                new ChatterUser()
                {
                    Chatter = this,
                    Name = "Dan Lazarovich",
                    UserId = "1"
                },
                new ChatterUser()
                {
                    Chatter = this,
                    Name = "Denis",
                    UserId = "2"
                },
                new ChatterUser()
                {
                    Chatter = this,
                    Name = "Diana",
                    UserId = "3"
                },
                new ChatterUser()
                {
                    Chatter = this,
                    Name = "Gromova Antonina",
                    UserId = "4"
                },
                new ChatterUser()
                {
                    Chatter = this,
                    Name = "Ihor",
                    UserId = "5"
                },
                new ChatterUser()
                {
                    Chatter = this,
                    Name = "Langate",
                    UserId = "6"
                },
                new ChatterUser()
                {
                    Chatter = this,
                    Name = "Limona",
                    UserId = "7"
                },
                new ChatterUser()
                {
                    Chatter = this,
                    Name = "Marta Vinnyk",
                    UserId = "8"
                },
                new ChatterUser()
                {
                    Chatter = this,
                    Name = "Max",
                    UserId = "9"
                },
                new ChatterUser()
                {
                    Chatter = this,
                    Name = "olga",
                    UserId = "10"
                }
            };
        }

        public void Initialize(string Name, string Id)
        {
            this.Name = Name;
            this.Id = Id;
        }

        public bool Login(string login, string password = "")
        {
            return true;
        }

        public bool LoginStep2(string code)
        {
            throw new NotSupportedException();
        }

        public void RestoreData(SerializedAccount data)
        {
            this.Id = data.AccountId;
            this.Name = data.Data;
        }

        public bool Resume(Func<string> auth)
        {
            throw new NotSupportedException();
        }

        public bool SendMessage(ref Message message)
        {
            message.Recived = false;
            string msgText = message.Text;
            if (msgText.StartsWith("reply", StringComparison.InvariantCultureIgnoreCase))
            {
                msgText = msgText.Substring(6);
                new Task(() =>
                {
                    Task.Delay(5000).Wait();
                    MessageRecived?.Invoke(new Message() { Recived = true, Time = DateTime.Now, Text = "Thanks for: " + msgText });
                }).Start();
            }
            return true;
        }

        public SerializedAccount StoreData()
        {
            var Storage = new SerializedAccount();
            Storage.AccountId = this.Id;
            Storage.Type = typeof(TestPlugin).FullName;

            Storage.Data = Name;
            return Storage;
        }
    }
}
