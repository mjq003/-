using System;
using System.Collections.Generic;
using System.Text;

namespace ReleaseNews.Models.Entity
{
    public class UsersFollow
    {
        public int Id { get; set; }
        public int F_UserId { get; set; }
        public int FollowId { get; set; }
        public DateTime FollowTime { get; set; }
        public virtual Users Users { get; set; }
    }
}
