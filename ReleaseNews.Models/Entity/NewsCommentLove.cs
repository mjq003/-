using System;
using System.Collections.Generic;
using System.Text;

namespace ReleaseNews.Models.Entity
{
    public class NewsCommentLove
    {
        public int Id { get; set; }
        public int NewsCommentId { get; set; }
        public int UserId { get; set; }
    }
}
