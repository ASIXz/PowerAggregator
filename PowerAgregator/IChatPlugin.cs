using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerAgregator
{
    /// <summary>
    /// Uses for chat plugins like telegram, skype, viber etc
    /// </summary>
    public interface IChatPlugin
    {
        /// <summary>
        /// Uniqe name of plugin+account
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Uniqe id of plugin+account (5 number length, used as preffix)
        /// </summary>
        string Id { get; }

        bool Is2StepAuth { get; }
        bool IsPassword { get; }
        bool IsAutoResume { get; }
        
        /// <summary>
        /// Initialize mthod uses for attach all delegates to sender
        /// Required events 
        /// - login
        /// - getusers
        /// - getmessages
        /// </summary>
        void Initialize(string Name, string Id);

        /// <summary>
        /// Main authentification method
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool Login(string login, string password = "");

        /// <summary>
        /// 2nd step autorization method. Use for 2 steps authentification
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        bool LoginStep2(string code);

        /// <summary>
        /// 
        /// </summary>
        event Action<Message> MessageRecived;

        /// <summary>
        /// Get full list of refered users
        /// </summary>
        /// <returns></returns>
        IEnumerable<ChatterUser> GetUsers();

        /// <summary>
        /// Get image for user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        byte[] GetImage(ChatterUser user);

        /// <summary>
        /// Get user's messages
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        IEnumerable<Message> GetChatForUser(ChatterUser user);

        /// <summary>
        /// Get user's messages that newer than LastMessage DateTime
        /// </summary>
        /// <param name="user"></param>
        /// <param name="LastMessage"></param>
        /// <returns></returns>
        IEnumerable<Message> GetChatForUser(ChatterUser user, DateTime LastMessage);

        /// <summary>
        /// Sending message method
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        bool SendMessage(ref Message message);

        bool Resume(Func<string> auth);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        SerializedAccount StoreData();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        void RestoreData(SerializedAccount data);
        

    }
}
