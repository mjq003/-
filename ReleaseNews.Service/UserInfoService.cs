using Microsoft.EntityFrameworkCore;
using ReleaseNews.Models.Entity;
using ReleaseNews.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ReleaseNews.Service
{
    public class UserInfoService
    {
        private Db _db;
        private UsersService _userService;
        /// <summary>
        /// 构造函数
        /// </summary>
        public UserInfoService(Db db, UsersService userService)
        {
            this._db = db;
            this._userService = userService;
        }
        /// <summary>
        /// 添加关注
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public ResponseModel AddUserFollow(int userId, int followId)
        {
            var userfollow = _db.UsersFollow.FirstOrDefault(c => c.F_UserId == userId && c.FollowId == followId);
            if (userfollow == null)
            {
                var u = new UsersFollow
                {
                    F_UserId = userId,
                    FollowId = followId,
                    FollowTime = DateTime.Now,
                };
                _db.UsersFollow.Add(u);
                int i = _db.SaveChanges();
                if (i > 0)
                    return new ResponseModel { code = 200, result = "关注成功" };
                return new ResponseModel { code = 0, result = "关注失败" };
            }
            else
            {
                return new ResponseModel { code = 0, result = "该用户已经关注!" };
            }
        }

        /// <summary>
        /// 取消关注
        /// </summary>
        public ResponseModel DelUserFollow(int userId, int followId)
        {
            var userfollow = _db.UsersFollow.FirstOrDefault(c => c.F_UserId == userId && c.FollowId == followId);
            if (userfollow == null)
                return new ResponseModel { code = 0, result = "该用户不存在" };
            _db.UsersFollow.Remove(userfollow);
            int i = _db.SaveChanges();
            if (i > 0)
                return new ResponseModel { code = 200, result = "取消关注成功" };
            return new ResponseModel { code = 0, result = "取消关注失败" };
        }


        /// <summary>
        /// 获取粉丝
        /// </summary>
        public ResponseModel GetFunsCount(int followId)
        {
            var count = _db.UsersFollow.Where(s => s.FollowId == followId).Count();
            return new ResponseModel { code = 200, result = "粉丝获取成功", data = count };
        }

        /// <summary>
        /// 获取关注
        /// </summary>
        public ResponseModel GetFollowCount(int userId)
        {
            var count = _db.UsersFollow.Where(s => s.F_UserId == userId).Count();
            return new ResponseModel { code = 200, result = "关注获取成功", data = count };
        }


        /// <summary>
        /// 查看粉丝列表
        /// </summary>
        public ResponseModel UserFunsPageQuery(int FollowId)
        {
            var list = _db.UsersFollow.Include("Users").Where(s => s.FollowId == FollowId);
            //total = list.Count();
            //var pageData = list.OrderByDescending(c => c.FollowTime).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
            var response = new ResponseModel
            {
                code = 200,
                result = "分页关注成功"
            };
            response.data = new List<UsersFollowModel>();
            foreach (var userfollow in list)
            {
                response.data.Add(new UsersFollowModel
                {
                    Id = userfollow.Id,
                    F_UserId = userfollow.F_UserId,
                    F_RealName = userfollow.Users.F_RealName,
                    F_Image = userfollow.Users.F_Image,
                    F_Sex = userfollow.Users.F_Sex == 0 ? "女" : "男",
                    F_Remark = userfollow.Users.F_Remark,
                    FollowTime = userfollow.FollowTime.ToString("yyyy-MM-dd")
                });
            }
            return response;
        }


        /// <summary>
        /// 查看关注列表
        /// </summary>
        public ResponseModel UserFollowPageQuery(int UserId)
        {
            var list = _db.UsersFollow.Include("Users").Where(s => s.F_UserId == UserId);
            //total = list.Count();
            //var pageData = list.OrderByDescending(c => c.FollowTime).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
            var response = new ResponseModel
            {
                code = 200,
                result = "分页关注成功"
            };
            response.data = new List<UsersFollowModel>();
            foreach (var userfollow in list)
            {
                response.data.Add(new UsersFollowModel
                {
                    Id = userfollow.Id,
                    F_UserId = userfollow.FollowId,
                    F_RealName = _userService.GetOneUsers(userfollow.FollowId).data.F_RealName,
                    F_Image = _userService.GetOneUsers(userfollow.FollowId).data.F_Image,
                    F_Sex = _userService.GetOneUsers(userfollow.FollowId).data.F_Sex,
                    F_Remark = _userService.GetOneUsers(userfollow.FollowId).data.F_Remark,
                    FollowTime = userfollow.FollowTime.ToString("yyyy-MM-dd")
                });
            }
            return response;
        }
    }
}
