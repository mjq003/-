using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NetCoreCacheService;
using Newtonsoft.Json;
using ReleaseNews.Models.Entity;
using ReleaseNews.Models.Request;
using ReleaseNews.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ReleaseNews.Service
{
    public class UsersService
    {
        private Db _db;
        /// <summary>
        /// 构造函数
        /// </summary>
        public UsersService(Db db)
        {
            this._db = db;
        }
        /// <summary>
        /// 添加users
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public ResponseModel AddUser(AddUsers users)
        {
            var u = new Users
            {
                F_Account = users.F_Account,
                F_Password = users.F_Password,
                F_RealName = users.F_RealName,
                F_Image = users.F_Image,
                F_Remark = users.F_Remark,
                F_CreateTime = DateTime.Now,
            };
            _db.Users.Add(u);
            int i = _db.SaveChanges();
            if (i > 0)
                return new ResponseModel { code = 200, result = "用户添加成功" };
            return new ResponseModel { code = 0, result = "用户添加失败" };

        }

        public ResponseModel UsersUserQuery(int pageSize, int pageIndex, out int total, List<Expression<Func<Users, bool>>> where)
        {
            var list = _db.Users.Where(e => true);
            foreach (var item in where)
            {
                list = list.Where(item);
            }
            total = list.Count();
            var pageData = list.OrderByDescending(c => c.F_CreateTime).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
            var response = new ResponseModel
            {
                code = 200,
                result = "分页用户获取成功"
            };
            response.data = new List<UsersModel>();
            foreach (var users in pageData)
            {
                response.data.Add(new UsersModel
                {
                    F_UserId = users.F_UserId,
                    F_Account = users.F_Account,
                    F_Password = users.F_Password,
                    F_RealName = users.F_RealName == null ? "" : users.F_RealName,
                    F_Sex = users.F_Sex == 0 ? "女" : "男",
                    F_Image = users.F_Image,
                    F_CreateTime = users.F_CreateTime.ToString("yyyy-MM-dd"),
                    F_Remark = users.F_Remark == null ? "" : users.F_Remark
                });
            }
            return response;
        }



        /// <summary>
        /// 获取users集合
        /// </summary>
        /// <returns></returns>
        public ResponseModel GetUserList()
        {
            //查询全部数据 根据时间排序
            var users = _db.Users.ToList().OrderByDescending(c => c.F_CreateTime);
            //new 返回对象；
            ResponseModel response = new ResponseModel();
            response.code = 200;
            response.result = "请求数据成功";
            response.data = new List<BannerModel>();
            foreach (var user in users)
            {
                response.data.Add(new UsersModel
                {
                    F_UserId = user.F_UserId,
                    F_Account = user.F_Account,
                    F_Password = user.F_Password,
                    F_RealName = user.F_RealName
                });
            }
            return response;
        }


        public IEnumerable<Users> GetUsersByAccount(string account)
        {
            var users = _db.Users.ToList().Where(s => s.F_Account == account);
            return users;
        }


        public IEnumerable<Users> GetUsersByRealName(string realname)
        {
            var users = _db.Users.ToList().Where(s => s.F_RealName == realname);
            return users;
        }


        /// <summary>
        ///判断用户登录信息 type 0:首页登录 1:后台管理员
        /// </summary>
        public ResponseModel CheckLogin(int userid, string username, string password, string type, ref UsersModel user)
        {
            var users = type == "1" ? _db.Users.FirstOrDefault(c => c.F_Account == username && c.F_Password == password && c.F_IsSystem == 1) : _db.Users.FirstOrDefault(c => c.F_Account == username && c.F_Password == password && c.F_IsSystem == 0);
            if (users == null)
            {
                return new ResponseModel { code = 0, result = "该账号不存在,或者密码错误！" };
            }
            else
            {
                if (type == "0")
                {
                    UsersModel u = new UsersModel();
                    u.F_UserId = userid;
                    u.F_Account = username;
                    u.F_RealName = users.F_RealName;
                    u.F_Sex = users.F_Sex == 0 ? "女" : "男";
                    u.F_Remark = users.F_Remark;
                    u.F_Image = users.F_Image;
                    user = u;
                    //MemoryCacheService.SetChacheValue("loginuserinfo", list);
                }
                return new ResponseModel { code = 200, result = "登录成功" };
            }
        }

        /// <summary>
        ///修改用户密码
        /// </summary>
        public ResponseModel UpdateUserPassWord(EditUserPwd edituserpwd)
        {
            var users = this.GetOneUsers(c => c.F_UserId == edituserpwd.F_UserId);
            if (users == null)
                return new ResponseModel { code = 0, result = "该用户不存在" };
            users.F_Password = edituserpwd.F_NewPassword;
            _db.Users.Update(users);
            int i = _db.SaveChanges();
            if (i > 0)
                return new ResponseModel { code = 200, result = "密码修改成功" };
            return new ResponseModel { code = 0, result = "密码修改失败" };
        }


        /// <summary>
        ///修改用户信息
        /// </summary>
        public ResponseModel UpdateUserInfo(EditUsers edituser, ref UsersModel user)
        {
            var users = this.GetOneUsers(c => c.F_UserId == edituser.F_UserId);
            if (users == null)
                return new ResponseModel { code = 0, result = "该用户不存在" };
            users.F_RealName = edituser.F_RealName;
            users.F_Image = edituser.F_Image;
            users.F_Sex = edituser.F_Sex;
            users.F_Remark = edituser.F_Remark;
            _db.Users.Update(users);
            int i = _db.SaveChanges();
            if (i > 0)
            {
                UsersModel u = new UsersModel();
                u.F_UserId = users.F_UserId;
                u.F_Account = users.F_Account;
                u.F_RealName = users.F_RealName;
                u.F_Sex = users.F_Sex == 0 ? "女" : "男";
                u.F_Remark = users.F_Remark;
                u.F_Image = users.F_Image;
                user = u;
                return new ResponseModel { code = 200, result = "头像修改成功" };
            }
            return new ResponseModel { code = 0, result = "头像修改失败" };
        }


        /// <summary>
        ///修改用户信息
        /// </summary>
        public ResponseModel UpdateUser(EditUsers edituser)
        {
            var users = this.GetOneUsers(c => c.F_UserId == edituser.F_UserId);
            if (users == null)
                return new ResponseModel { code = 0, result = "该用户不存在" };
            users.F_Account = edituser.F_Account;
            users.F_RealName = edituser.F_RealName;
            users.F_Image = edituser.F_Image;
            users.F_Sex = edituser.F_Sex;
            users.F_Remark = edituser.F_Remark;
            _db.Users.Update(users);
            int i = _db.SaveChanges();
            if (i > 0)
                return new ResponseModel { code = 200, result = "用户信息修改成功" };
            return new ResponseModel { code = 0, result = "用户信息修改失败" };
        }


        private Users GetOneUsers(Expression<Func<Users, bool>> where)
        {
            return _db.Users.FirstOrDefault(where);
        }


        public ResponseModel GetOneUsers(int id)
        {
            var users = _db.Users.Find(id);
            if (users == null)
                return new ResponseModel { code = 0, result = "该用户不存在" };
            return new ResponseModel
            {
                code = 200,
                result = "用户数据成功",
                data = new UsersModel
                {
                    F_UserId = users.F_UserId,
                    F_Password = users.F_Password,
                    F_Account = users.F_Account,
                    F_RealName = users.F_RealName,
                    F_Sex = users.F_Sex == 0 ? "女" : "男",
                    F_Image = users.F_Image,
                    F_Remark = users.F_Remark == null ? "" : users.F_Remark
                }
            };
        }

        ///// <summary>
        ///// 获取登录者信息
        ///// </summary>
        ///// <returns></returns>
        //public ResponseModel GetCacheUser()
        //{
        //    var userList = MemoryCacheService.GetList<Users>("loginuserinfo");
        //    if (userList == null)
        //        return new ResponseModel { code = 0, result = "该用户不存在" };
        //    return new ResponseModel
        //    {
        //        code = 200,
        //        result = "用户数据成功",
        //        data = new UsersModel
        //        {
        //            F_UserId = userList.FirstOrDefault().F_UserId,
        //            F_Account = userList.FirstOrDefault().F_Account,
        //            F_RealName = userList.FirstOrDefault().F_RealName,
        //            F_Sex = userList.FirstOrDefault().F_Sex == 0 ? "女" : "男",
        //            F_Image = userList.FirstOrDefault().F_Image,
        //            F_Remark = userList.FirstOrDefault().F_Remark
        //        }
        //    };
        //}
    }
}
