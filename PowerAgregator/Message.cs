using System;
using System.Linq;

namespace PowerAgregator
{
    public class Message
    {
        /// <summary>
        /// Message TimeStamp
        /// </summary>
        public DateTime Time;
        /// <summary>
        /// Message text
        /// </summary>
        public string Text;
        /// <summary>
        /// For future use (will contain files and images)
        /// </summary>
        public object Additions;

        /// <summary>
        /// If true - message recivied by account from user
        /// Othervice - sended by account
        /// </summary>
        public bool Recived;

        /// <summary>
        /// User that message belong to dialog with
        /// </summary>
        public ChatterUser User;

        public override string ToString()
        {
            return Time.ToString("[yyyy.MM.dd hh:mm]") + (Recived ? "" : "\t") + Text;
        }

        public Message(ChatterUser user)
        {
            this.User = user;
        }
        public Message(MessageData data, ChatterUser user)
        {
            this.Recived = data.Recived;
            this.Text = data.Text;
            this.Time = data.Date;
            this.User = user;
        }

        public MessageData StoreData()
        {
            return new MessageData
            {
                Date = Time,
                Recived = Recived,
                Text = Text,
                UserId = User.UserId,
                Id = Time.Ticks.ToString() + User.UserId
            };
        }
    }
}