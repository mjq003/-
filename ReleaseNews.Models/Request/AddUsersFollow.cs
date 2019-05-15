using System;
using System.Collections.Generic;
using System.Text;

namespace ReleaseNews.Models.Request
{
    public class AddUsersFollow
    {
        public int Id { get; set; }
        public int F_UserId { get; set; }
        public int FollowId { get; set; }
        public DateTime FollowTime { get; set; }
    }
}
