using System;
using System.Collections.Generic;
using System.Text;

namespace ReleaseNews.Models.Entity
{   
    /// <summary>
    /// 新闻评论
    /// </summary>
    public class NewsComment
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public int UserId { get; set; }
        public int OldId { get; set; }
        public int ReplyUserId { get; set; }
        public string Contents { get; set; }
        public DateTime AddTime { get; set; }
        public int Love { get; set; }
        public string Remark { get; set; }
        public virtual News News { get; set; }
    }
}
