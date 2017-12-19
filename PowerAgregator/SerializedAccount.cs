using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerAgregator
{
    public class SerializedAccount
    {
        [Key]
        public string AccountId { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }
    }

    public class ChatterUserData
    {
        [Key]
        public string Name { get; set; }
        public string ChatterId { get; set; }
        public string UserId { get; set; }
        public string UserAdditionalSpec { get; set; }
        public string AgregatorUserId { get; set; }
    }

    public class MessageData
    {
        [Key]
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }
        public bool Recived { get; set; }
    }

    public class AgregatorUserData
    {
        [Key]
        public string Name { get; set; }
    }
}
