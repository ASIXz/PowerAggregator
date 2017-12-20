using System.Data.Entity;
using PowerAgregator;
using System.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace DesctopPA
{
    public class PowerAgregatorContext5 : DbContext
    {
        public DbSet<AgregatorUserData> AgregatorUsers { get; set; }
        public DbSet<ChatterUserData> ChatterUser { get; set; }
        public DbSet<SerializedAccount> Accounts { get; set; }
        public DbSet<MessageData> Messages { get; set; }

        public PowerAgregatorContext5() : base("DBConnection")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<PowerAgregatorContext5>());

        }
    }

    public static class DBHelper
    {
        public static PowerAgregatorContext5 db;
        public static void SaveAccountDataToDataBase(Core core)
        {
            if (db == null) db = new PowerAgregatorContext5();

            db.Accounts.RemoveRange(db.Accounts);
            db.Accounts.AddRange(core.Chatters.Select(x => x.StoreData()));

            db.ChatterUser.RemoveRange(db.ChatterUser);
            db.ChatterUser.AddRange(core.ChatterUsers.Select(x => x.StoreData()));

            db.AgregatorUsers.RemoveRange(db.AgregatorUsers);
            db.AgregatorUsers.AddRange(core.Users.Select(x => x.StoreData()));

            db.SaveChanges();
        }

        public static void ClearDatabase()
        {
            if (db == null) db = new PowerAgregatorContext5();

            db.Accounts.RemoveRange(db.Accounts);

            db.ChatterUser.RemoveRange(db.ChatterUser);

            db.AgregatorUsers.RemoveRange(db.AgregatorUsers);

            db.Messages.RemoveRange(db.Messages);

            db.SaveChanges();


        }

        public static void RestoreAccountDataFromDataBase(Core core)
        {
            if (db == null) db = new PowerAgregatorContext5();

            core.Chatters.Clear();
            foreach (SerializedAccount acc in db.Accounts)
            {
                var plugin = PluginHelper.Plugins.First(x => x.FullName == acc.Type);
                var Chatter = Activator.CreateInstance(plugin) as IChatPlugin;
                Chatter.RestoreData(acc);
                Chatter.MessageRecived += core.AddMessage;
                core.Chatters.Add(Chatter);
            }

            core.Users = db.AgregatorUsers.ToList().Select(x => new AgregatorUser(x)).ToList();
            core.ChatterUsers = db.ChatterUser.ToList().Select(x => new ChatterUser(x, core)).ToList();
        }

        public static void LoadMessages(ChatterUser user)
        {
            user.Messages = db.Messages.Where(x => x.UserId == user.UserId).ToList().Select(x => new Message(x, user)).ToList();
        }

        public static void SaveMessages(ChatterUser user)
        {
            db.Messages.RemoveRange(db.Messages.Where(x => x.UserId == user.UserId));
            db.Messages.AddRange(user.Messages.Select((x, i) =>
            {
                var c = x.StoreData();
                c.Id += i.ToString();
                return c;
            }));
            db.SaveChanges();
        }

        public static void SaveMessage(Message message)
        {
            db.Messages.Add(message.StoreData());
            db.SaveChanges();
        }
    }
}
