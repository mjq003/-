using System;
using System.Collections.Generic;
using System.Text;

namespace ReleaseNews.Models.Entity
{
    public class NewsClassify
    {
        public NewsClassify()
        {
            this.News = new HashSet<News>();
        }
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public int Sort { get; set; }
        public string Remark { get; set; }
        //0:篮球 1：步行街
        public int ClassifyType { get; set; }
        public virtual ICollection<News> News { get; set; }
    }
}
