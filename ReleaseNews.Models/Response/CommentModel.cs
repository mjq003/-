using System;
using System.Collections.Generic;
using System.Text;

namespace ReleaseNews.Models.Response
{
    public class CommentModel
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public string NewsName { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public int OldId { get; set; }
        public int ReplyUserId { get; set; }
        public string UserImage { get; set; }
        public string ReplyUserName { get; set; }
        public string Contents { get; set; }
        public DateTime AddTime { get; set; }
        public int Love { get; set; }
        public string Remark { get; set; }
        public string Floor { get; set; }
        public List<CommentReply> crLst { get; set; }
    }

    public class CommentReply
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public int OldId { get; set; }
        public string UserName { get; set; }
        public int ReplyUserId { get; set; }
        public string ReplyUserName { get; set; }
        public string ReplyUserImage{ get; set; }
        public string Contents { get; set; }
        public DateTime AddTime { get; set; }
        public int Love { get; set; }
    }
}
