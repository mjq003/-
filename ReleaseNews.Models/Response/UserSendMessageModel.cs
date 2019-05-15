using System;
using System.Collections.Generic;
using System.Text;

namespace ReleaseNews.Models.Response
{
    public class UserSendMessageModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SendMessageUserId { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
        public DateTime SendTime { get; set; }
    }
}
