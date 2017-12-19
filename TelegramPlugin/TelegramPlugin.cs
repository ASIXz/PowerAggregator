using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerAgregator;
using TLSharp.Core;
using TeleSharp.TL;
using TeleSharp.TL.Messages;
using System.Threading;

namespace TelegramPlugin
{
    public class TelegramPlugin : PowerAgregator.IChatPlugin
    {
        static DateTime ZeroTDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public string Name { get; set; }
        public string Id { get { return id; } }

        public bool IsPassword { get { return false; } }
        public bool Is2StepAuth { get { return true; } }
        public bool IsAutoResume { get { return false; } }

        private string id;

        public void Initialize(string Name, string Id)
        {
            this.id = Id;
            this.Name = Name;
        }

        private string login;
        //FileSessionStore store;
        TelegramClient client;
        bool connected;
        string hash;
        string code;
        TLUser user;

        public bool Login(string login, string password = "")
        {
            this.login = login;
            var store = new FileSessionStore();
            string sessionKey = Name;
            client = new TelegramClient(162156, "489ea0f0a6ec8dff21fd02dcbea6ee42", store, sessionKey);
            var x = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                /* run your code here */
                ALogin();
                Task.Delay(5000).Wait();
            });
            x.Start();
            x.Join();
            return connected;

        }



        async void ALogin()
        {
            connected = await client.ConnectAsync();
            try
            {
                hash = await client.SendCodeRequestAsync(login);
            }
            catch
            {
                hash = await client.SendCodeRequestAsync(login);
            }
        }

        public bool LoginStep2(string code)
        {
            this.code = code;
            try
            {
                var x = new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    /* run your code here */
                    Login2();
                    Task.Delay(5000).Wait();
                });
                x.Start();
                x.Join();
                if (user != null) return true;
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        async void Login2()
        {
            try
            {
                user = await client.MakeAuthAsync(login, hash, code);
            }
            catch (Exception ex)
            {
                ActionResult = ex;
            }
        }

        object ActionResult;

        public event Action<Message> MessageRecived;

        async void AGetUsers()
        {
            TLDialogs Dialogs;
            await client.ConnectAsync();
            try
            {
                Dialogs = (TLDialogs)await client.GetUserDialogsAsync();
            }
            catch (Exception ex)
            {
                hash = await client.SendCodeRequestAsync(login);
                user = await client.MakeAuthAsync(login, hash, code);
                Dialogs = (TLDialogs)await client.GetUserDialogsAsync();
            }
            ActionResult = Dialogs.Users.Select(x =>
            {
                TLUser user = x as TLUser;
                return new ChatterUser()
                {
                    Chatter = this,
                    Name = user.FirstName,
                    UserId = (user.AccessHash ?? 0).ToString() + "!" + user.Id.ToString()
                };
            });
        }

        public IEnumerable<ChatterUser> GetUsers()
        {
            var x = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                /* run your code here */
                AGetUsers();
                Task.Delay(5000).Wait();
            });
            x.Start();
            x.Join();
            var result = ActionResult as IEnumerable<ChatterUser>;
            foreach (ChatterUser item in result)
            {
                item.Messages = GetChatForUser(item).ToList();
            }
            return result;
        }

        private long DecomposeId(string ComposedId, out int id)
        {
            int splitPosition = ComposedId.IndexOf('!');
            long hash = long.Parse(ComposedId.Substring(0, splitPosition));
            id = int.Parse(ComposedId.Substring(splitPosition + 1, ComposedId.Length - splitPosition - 1));
            return hash;
        }

        public async void AGetHistory(ChatterUser user)
        {
            long hash = DecomposeId(user.UserId, out int id);
            await client.ConnectAsync(true);
            try
            {
                ActionResult = await client.GetHistoryAsync(new TLInputPeerUser() { UserId = id, AccessHash = hash }, 0, 0, 0);
            }
            catch
            {
                ActionResult = new TLMessagesSlice();
            }
        }

        public IEnumerable<Message> GetChatForUser(ChatterUser user)
        {
            var z = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                /* run your code here */
                AGetHistory(user);
                Task.Delay(5000).Wait();
            });
            z.Start();
            z.Join();
            var msgs = (TLMessagesSlice)ActionResult;
            var result = msgs.Messages.Select(x =>
            {
                var msg = (TLMessage)x;
                return new Message()
                {
                    Time = ZeroTDate.AddSeconds(msg.Date),
                    Recived = !msg.Out,
                    Text = msg.Message,
                    User = user
                };
            });

            return result;

            //ZeroTDate.AddSeconds(((res as TLMessages).Messages[0] as TLMessage).Date)
        }

        public SerializedAccount StoreData()
        {
            var Storage = new SerializedAccount();
            Storage.AccountId = this.Id;
            Storage.Type = typeof(TelegramPlugin).FullName;
            //
            Storage.Data = Name;
            return Storage;
        }
        async void ARestore()
        {
            connected = await client.ConnectAsync(true);
        }


        public void RestoreData(SerializedAccount data)
        {
            //
            this.id = data.AccountId;
            this.Name = data.Data;
            string sessionKey = Name;
            var store = new FileSessionStore();
            client = new TelegramClient(153480, "b4fe99e13f7820911ad3cd6c12514e7f", store, sessionKey);
            //var session = store.Load(sessionKey);
            //user = session.TLUser;
        }

        public IEnumerable<Message> GetChatForUser(ChatterUser user, DateTime LastMessage)
        {
            throw new NotImplementedException();
        }

        public bool SendMessage(ref Message message)
        {
            throw new NotImplementedException();
        }

        public bool Resume(Func<string> auth)
        {
            throw new NotImplementedException();
        }

        public byte[] GetImage(ChatterUser user)
        {
            throw new NotImplementedException();
        }
    }
}
