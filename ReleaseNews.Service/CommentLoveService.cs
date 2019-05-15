using ReleaseNews.Models.Entity;
using ReleaseNews.Models.Request;
using ReleaseNews.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReleaseNews.Service
{
    public class CommentLoveService
    {
        private Db _db;
        private NewsService _newsService;
        private UsersService _userService;
        public CommentLoveService(Db db, NewsService newsService, UsersService userService)
        {
            this._db = db;
            this._newsService = newsService;
            this._userService = userService;
        }

        /// <summary>
        /// 添加评论
        /// </summary>
        public ResponseModel AddCommentLove(AddNewsCommentLove commentlove)
        {
            var comlove = new NewsCommentLove { NewsCommentId = commentlove.NewsCommentId, UserId = commentlove.UserId };
            _db.NewsCommentLove.Add(comlove);
            int i = _db.SaveChanges();
            if (i > 0)
            {
                return new ResponseModel
                {
                    code = 200,
                    result = "添加成功",
                };
            }
            return new ResponseModel { code = 0, result = "添加失败" };
        }

        public bool CheckIfClickLove(int NewsCommentId, int UserId)
        {
            var newscommentlove = _db.NewsCommentLove.Where(c => c.NewsCommentId == NewsCommentId && c.UserId == UserId).ToList();
            return newscommentlove.Count() == 0 ? true : false;
        }
    }
}
