using Microsoft.EntityFrameworkCore;
using NetCoreCacheService;
using ReleaseNews.Models.Entity;
using ReleaseNews.Models.Request;
using ReleaseNews.Models.Response;
using ReleaseNews.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ReleaseNews.Service
{
    public class CommentService
    {
        private Db _db;
        private NewsService _newsService;
        private UsersService _userService;
        private CommentLoveService _commentloveService;
        public CommentService(Db db, NewsService newsService, UsersService userService, CommentLoveService commentloveService)
        {
            this._db = db;
            this._newsService = newsService;
            this._userService = userService;
            this._commentloveService = commentloveService;
        }
        /// <summary>
        /// 添加评论
        /// </summary>
        public ResponseModel AddComment(AddComment comment, dynamic u)
        {
            var news = _newsService.GetoneNews(comment.NewsId);
            if (news.code == 0)
                return new ResponseModel { code = 0, result = "新闻不存在" };
            var com = new NewsComment { AddTime = DateTime.Now, NewsId = comment.NewsId, UserId = u.F_UserId, OldId = comment.OldId, ReplyUserId = comment.ReplyUserId, Contents = comment.Contents };
            _db.NewsComment.Add(com);
            int i = _db.SaveChanges();
            if (i > 0)
            {
                return new ResponseModel
                {
                    code = 200,
                    result = "评论添加成功",
                    data = new
                    {
                        contents = comment.Contents,
                        floor = "#" + (Convert.ToInt32(news.data.CommentCount) + 1),
                        username = _userService.GetOneUsers(u.F_UserId).data.F_RealName,
                        userimage = _userService.GetOneUsers(u.F_UserId).data.F_Image,
                        love = comment.Love,
                        addTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    }
                };
            }
            return new ResponseModel { code = 0, result = "评论添加失败" };
        }



        public ResponseModel AddReplyComment(AddComment comment)
        {
            var news = _newsService.GetoneNews(comment.NewsId);
            if (news.code == 0)
                return new ResponseModel { code = 0, result = "新闻不存在" };
            var com = new NewsComment { AddTime = DateTime.Now, NewsId = comment.NewsId, UserId = comment.UserId, OldId = comment.OldId, ReplyUserId = comment.ReplyUserId, Contents = comment.Contents };
            _db.NewsComment.Add(com);
            int i = _db.SaveChanges();
            if (i > 0)
            {
                return new ResponseModel
                {
                    code = 200,
                    result = "回复成功",
                    data = new
                    {
                        contents = comment.Contents,
                        floor = "#" + (Convert.ToInt32(news.data.CommentCount) + 1),
                        username = _userService.GetOneUsers(comment.UserId).data.F_RealName,
                        userimage = _userService.GetOneUsers(comment.UserId).data.F_Image,
                        love = comment.Love,
                        addTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    }
                };
            }
            return new ResponseModel { code = 0, result = "回复失败" };
        }

        /// <summary>
        /// 给评论点赞
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ResponseModel GetLove(int Id, int userId)
        {
            if (_commentloveService.CheckIfClickLove(Id, userId))
            {
                var comment = _db.NewsComment.Find(Id);
                if (comment == null)
                    return new ResponseModel { code = 0, result = "该评论不存在" };
                comment.Love = comment.Love + 1;
                _db.NewsComment.Update(comment);
                int i = _db.SaveChanges();
                ResponseModel commentlove = _commentloveService.AddCommentLove(new AddNewsCommentLove() { NewsCommentId = Id, UserId = userId });
                if (i > 0 && commentlove.code == 200)
                    return new ResponseModel { code = 200, result = "点赞成功" };
                return new ResponseModel { code = 0, result = "点赞失败" };
            }
            return new ResponseModel { code = 0, result = "你已经点赞过次评论" };
        }

        /// <summary>
        /// 删除评论
        /// </summary>
        public ResponseModel DeleteComment(int id)
        {
            var comment = _db.NewsComment.Find(id);
            if (comment == null)
                return new ResponseModel { code = 0, result = "评论不存在" };
            _db.NewsComment.Remove(comment);
            int i = _db.SaveChanges();
            if (i > 0)
            {
                return new ResponseModel
                {
                    code = 200,
                    result = "新闻评论删除成功"
                };
            }
            return new ResponseModel { code = 0, result = "新闻评论删除失败" };
        }
        /// <summary>
        /// 获取评论集合
        /// </summary>
        public ResponseModel GetCommentList(Expression<Func<NewsComment, bool>> where)
        {
            var comments = _db.NewsComment.Include("News").Where(where).OrderBy(c => c.AddTime).ToList();
            var response = new ResponseModel();
            response.code = 200;
            response.result = "评论获取成功";
            response.data = new List<CommentModel>();
            int floor = 1;
            HtmlToText convert = new HtmlToText();
            foreach (var comment in comments)
            {
                CommentModel cm = new CommentModel();
                cm.Id = comment.Id;
                cm.NewsId = comment.NewsId;
                cm.NewsName = comment.News.Title;
                cm.UserName = _userService.GetOneUsers(comment.UserId).data.F_RealName;
                cm.UserId = comment.UserId;
                cm.UserImage = _userService.GetOneUsers(comment.UserId).data.F_Image;
                cm.Contents = convert.ConvertImgByFace(comment.Contents);
                cm.AddTime = comment.AddTime;
                cm.Love = comment.Love;
                cm.Remark = comment.Remark;
                cm.Floor = "#" + floor;

                List<NewsComment> nc = GetRaplyComment(comment.Id);
                List<CommentReply> crlst = new List<CommentReply>();
                if (nc.Count() > 0)
                {
                    foreach (var item in nc)
                    {
                        CommentReply cr = new CommentReply();
                        cr.NewsId = item.NewsId;
                        cr.OldId = item.OldId;
                        cr.UserName = _userService.GetOneUsers(item.UserId).data.F_RealName;
                        cr.ReplyUserId = item.ReplyUserId;
                        cr.ReplyUserName = _userService.GetOneUsers(item.ReplyUserId).data.F_RealName;
                        cr.ReplyUserImage = _userService.GetOneUsers(item.ReplyUserId).data.F_Image;
                        cr.Id = item.Id;
                        cr.Love = item.Love;
                        cr.Contents = convert.ConvertImgByFace(item.Contents);
                        cr.AddTime = item.AddTime;
                        crlst.Add(cr);
                    }
                }
                cm.crLst = crlst;
                response.data.Add(cm);
                floor++;
            }
            response.data.Reverse();
            return response;
        }


        //查询楼中楼回复
        public List<NewsComment> GetRaplyComment(int oldcommentId)
        {
            var comments = _db.NewsComment.Where(s => s.OldId == oldcommentId).OrderBy(c => c.AddTime).ToList();
            return comments;
        }
    }
}
