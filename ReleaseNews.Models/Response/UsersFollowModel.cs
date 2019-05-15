using System;
using System.Collections.Generic;
using System.Text;

namespace ReleaseNews.Models.Response
{
    public class UsersFollowModel
    {
        public int Id { get; set; }
        public int F_UserId { get; set; }
        public int FollowId { get; set; }
        public string F_RealName { get; set; }
        public string F_Sex { get; set; }
        public string F_Image { get; set; }
        public string F_Remark { get; set; }
        public string FollowTime { get; set; }
    }
}
