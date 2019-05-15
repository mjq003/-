using System;
using System.Collections.Generic;
using System.Text;

namespace ReleaseNews.Models.Request
{
    public class AddComment
    {
        public int NewsId { get; set; }
        public int UserId { get; set; }
        public int OldId { get; set; }
        public int ReplyUserId { get; set; }
        public string Contents { get; set; }
        public int Love { get; set; }
    }
}
