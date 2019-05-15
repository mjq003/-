using System;
using System.Collections.Generic;
using System.Text;

namespace ReleaseNews.Models.Request
{
    public class AddUsers
    {
        public string F_Account { get; set; }
        public string F_Password { get; set; }
        public string F_RealName { get; set; }
        public int F_Sex { get; set; }
        public DateTime F_CreateTime { get; set; }
        public int F_IsSystem { get; set; }
        public string F_Image { get; set; }
        public string F_Remark { get; set; }
    }
}
