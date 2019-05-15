using System;
using System.Collections.Generic;
using System.Text;

namespace ReleaseNews.Models.Request
{
    public class AddNewsCommentLove
    {
        public int Id { get; set; }
        public int NewsCommentId { get; set; }
        public int UserId { get; set; }
    }
}
