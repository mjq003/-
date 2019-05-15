using System;
using System.Collections.Generic;
using System.Text;

namespace ReleaseNews.Models.Entity
{
    public class UserSendMessage
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SendMessageUserId { get; set; }
        public string Message { get; set; }
        public DateTime SendTime { get; set; }
        public int IfCheck { get; set; }
    }
}
