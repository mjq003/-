using System;
using System.Collections.Generic;
using System.Text;

namespace ReleaseNews.Models.Response
{
    public class NewsClassifyModel
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public int Sort { get; set; }
        public string Remark { get; set; }
        public int ClassifyType { get; set; }
    }
}
