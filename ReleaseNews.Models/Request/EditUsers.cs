using System;
using System.Collections.Generic;
using System.Text;

namespace ReleaseNews.Models.Request
{
    public class EditUsers
    {
        public int F_UserId { get; set; }
        public string F_Account { get; set; }
        public string F_RealName { get; set; }
        public int F_Sex { get; set; }
        public int F_IsSystem { get; set; }
        public string F_Image { get; set; }
        public string F_Remark { get; set; }
    }
}
