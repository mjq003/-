using System;
using System.Collections.Generic;
using System.Text;

namespace ReleaseNews.Models.Response
{
    public class NewsModel
    {
        public int Id { get; set; }
        public int ClassifyId { get; set; }
        public int UserId { get; set; }
        public string ClassifyName { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Contents { get; set; }
        public string PublishDate { get; set; }
        public int CommentCount { get; set; }
        public string Remark { get; set; }
        public int LoveCount { get; set; }
    }
}
