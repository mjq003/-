using ReleaseNews.Models.Entity;
using ReleaseNews.Models.Request;
using ReleaseNews.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReleaseNews.Service
{
    public class UserSendMessageService
    {
        private Db _db;
        private UsersService _userService;
        /// <summary>
        /// 构造函数
        /// </summary>
        public UserSendMessageService(Db db, UsersService usersservice)
        {
            this._db = db;
            this._userService = usersservice;
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public ResponseModel AddUserSendMessage(AddUserSendMessage sendmessage)
        {
            var u = new UserSendMessage
            {
                UserId = sendmessage.UserId,
                SendMessageUserId = sendmessage.SendMessageUserId,
                Message = sendmessage.Message,
                SendTime = DateTime.Now,
                IfCheck = 0
            };
            _db.UserSendMessage.Add(u);
            int i = _db.SaveChanges();
            if (i > 0)
                return new ResponseModel { code = 200, result = "消息发送成功" };
            return new ResponseModel { code = 0, result = "消息发送失败" };
        }


        public ResponseModel GetOneUserSendMessageByUserId(int id)
        {
            var usersendmessage = _db.UserSendMessage.ToList().Where(s => s.SendMessageUserId == id && s.IfCheck == 0).OrderByDescending(s => s.SendTime);
            //new 返回对象；s
            ResponseModel response = new ResponseModel();
            response.code = 200;
            response.result = "请求数据成功";
            response.data = new List<UserSendMessageModel>();
            foreach (var message in usersendmessage)
            {
                response.data.Add(new UserSendMessageModel
                {
                    Id = message.Id,
                    UserId = message.UserId,
                    SendMessageUserId = message.SendMessageUserId,
                    UserName = _userService.GetOneUsers(message.UserId).data.F_RealName,
                    Message = message.Message,
                    SendTime = message.SendTime
                });
            }
            return response;
        }


        /// <summary>
        ///设置成已读 ifcheck 0:未读 1：已读
        /// </summary>
        public ResponseModel UpdateIfCheck(int id)
        {
            var sendmessage = _db.UserSendMessage.ToList().Where(s => s.SendMessageUserId == id && s.IfCheck == 0);
            foreach (var item in sendmessage)
            {
                item.IfCheck = 1;
            }
            _db.UserSendMessage.UpdateRange(sendmessage);
            int i = _db.SaveChanges();
            if (i > 0)
                return new ResponseModel { code = 200, result = "修改成功" };
            return new ResponseModel { code = 0, result = "修改失败" };
        }
    }
}
