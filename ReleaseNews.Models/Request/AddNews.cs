using System;
using System.Collections.Generic;
using System.Text;

namespace ReleaseNews.Models.Request
{
    public class AddNews
    {
        public int NewsClassifyId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Contents { get; set; }
        public string Remark { get; set; }
    }
}
