using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ReleaseNews.Models.Entity;
using ReleaseNews.Models.Request;
using ReleaseNews.Models.Response;
using ReleaseNews.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ReleaseNews.Service
{
    /// <summary>
    /// NewsService
    /// </summary>
    public class NewsService
    {
        private Db _db;
        private UsersService _userService;
        private UserSendMessageService _usersendmessageService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="db"></param>
        public NewsService(Db db, UsersService userService, UserSendMessageService usersendmessageService)
        {
            this._db = db;
            this._userService = userService;
            this._usersendmessageService = usersendmessageService;
        }
        /// <summary>
        /// 添加一个新闻类别
        /// </summary>
        /// <param name="newsClassify"></param>
        /// <returns></returns>
        public ResponseModel AddNewsClassify(AddNewsClassify newsClassify)
        {
            var exit = _db.NewsClassify.FirstOrDefault(c => c.Name == newsClassify.Name) != null;
            //判断是否重复添加数据；
            if (exit)
                return new ResponseModel { code = 0, result = "该类别已存在" };
            //实现添加
            var classify = new NewsClassify { Name = newsClassify.Name, Sort = newsClassify.Sort, Remark = newsClassify.Remark };
            //添加
            _db.NewsClassify.Add(classify);
            //保存
            int i = _db.SaveChanges();
            //判断是否添加成功；
            if (i > 0)
                return new ResponseModel { code = 200, result = "新闻类别添加成功" };
            return new ResponseModel { code = 0, result = "新闻类别添加失败" };
        }
        /// <summary>
        /// 获取一个新闻类别
        /// </summary>
        public ResponseModel GetOneNewsClassify(int id)
        {
            var classify = _db.NewsClassify.Find(id);
            if (classify == null)
                return new ResponseModel { code = 0, result = "该类别不存在" };
            return new ResponseModel
            {
                code = 200,
                result = "新闻类别获取成功",
                data = new NewsClassifyModel
                {
                    Id = classify.Id,
                    Sort = classify.Sort,
                    Name = classify.Name,
                    Remark = classify.Remark
                }
            };
        }
        /// <summary>
        /// 获取一个新闻类别
        /// </summary>
        private NewsClassify GetOneNewsClassify(Expression<Func<NewsClassify, bool>> where)
        {
            return _db.NewsClassify.FirstOrDefault(where);
        }
        /// <summary>
        /// 编辑一个新闻类别
        /// </summary>
        public ResponseModel EditNewsClassify(EditNewsClassify newsClassify)
        {
            var classify = this.GetOneNewsClassify(c => c.Id == newsClassify.Id);
            if (classify == null)
                return new ResponseModel { code = 0, result = "该类别不存在" };
            classify.Name = newsClassify.Name;
            classify.Sort = newsClassify.Sort;
            classify.Remark = newsClassify.Remark;
            _db.NewsClassify.Update(classify);
            int i = _db.SaveChanges();
            if (i > 0)
                return new ResponseModel { code = 200, result = "新闻类别编辑成功" };
            return new ResponseModel { code = 0, result = "新闻类别编辑失败" };
        }

        /// <summary>
        /// 获取所有新闻类别集合
        /// </summary>
        public ResponseModel GetAllNewsClassifyList()
        {
            var classifys = _db.NewsClassify.OrderBy(c => c.Sort).ToList();
            var response = new ResponseModel { code = 200, result = "新闻类别集合获取成功" };
            response.data = new List<NewsClassifyModel>();
            foreach (var classify in classifys)
            {
                response.data.Add(new NewsClassifyModel
                {
                    Id = classify.Id,
                    Name = classify.Name,
                    Sort = classify.Sort,
                    Remark = classify.Remark
                });
            }
            return response;
        }


        /// <summary>
        /// 获取新闻类别集合
        /// </summary>
        public ResponseModel GetNewsClassifyList()
        {
            var classifys = _db.NewsClassify.Where(s => s.ParentId == 0 && s.ClassifyType == 0).OrderBy(c => c.Sort).ToList();
            var response = new ResponseModel { code = 200, result = "新闻类别集合获取成功" };
            response.data = new List<NewsClassifyModel>();
            foreach (var classify in classifys)
            {
                response.data.Add(new NewsClassifyModel
                {
                    Id = classify.Id,
                    Name = classify.Name,
                    Sort = classify.Sort,
                    Remark = classify.Remark
                });
            }
            return response;
        }

        /// <summary>
        /// 获取首页新闻类别集合
        /// </summary>
        public ResponseModel GetMainNewsClassifyList(ResponseModel userList)
        {
            var classifys = _db.NewsClassify.Where(s => s.ParentId == 0 && s.ClassifyType == 0 || s.Id == 44).OrderBy(c => c.Sort).Take(5).ToList();
            var response = new ResponseModel { code = 200, result = "新闻类别集合获取成功" };
            response.data = new List<NewsClassifyModel>();
            foreach (var classify in classifys)
            {
                response.data.Add(new NewsClassifyModel
                {
                    Id = classify.Id,
                    Name = classify.Name,
                    Sort = classify.Sort,
                    Remark = classify.Remark
                });
            }
            if (userList.code == 200)
            {
                var users = _userService.GetUsersByAccount(userList.data.F_Account);
                var usersendmessageCount = _usersendmessageService.GetOneUserSendMessageByUserId(userList.data.F_UserId).data.Count;
                response.maindata = new List<MainModel>();
                response.maindata.Add(new MainModel
                {
                    username = userList.data.F_Account,
                    image = userList.data.F_Image == null ? "/UserPic/defalt.jpg" : userList.data.F_Image,
                    userId = userList.data.F_UserId,
                    messageCount = usersendmessageCount > 0 ? $"({usersendmessageCount.ToString()})" : ""
                });
            }
            else
            {
                response.maindata = new List<MainModel>();
                response.maindata.Add(new MainModel
                {
                    username = "0000",
                    image = "/UserPic/defalt.jpg",
                    userId = 0,
                    messageCount = "0"
                });
            }
            return response;
        }

        /// <summary>
        /// 获取首页新闻类别集合
        /// </summary>
        public ResponseModel GetPostNewsClassifyList(int type)
        {
            List<NewsClassify> NewsClassifyLst = new List<NewsClassify>();
            if (type == 0) //显示父节点
            {
                NewsClassifyLst = _db.NewsClassify.Where(s => s.ParentId == 0 && s.ClassifyType == 1).OrderBy(c => c.Sort).ToList();
            }
            else if (type == 1) //显示子节点
            {
                NewsClassifyLst = _db.NewsClassify.Where(s => s.ParentId != 0 && s.ClassifyType == 1).OrderBy(c => c.Sort).ToList();
            }
            var response = new ResponseModel { code = 200, result = "新闻类别集合获取成功" };
            response.data = new List<NewsClassifyModel>();
            foreach (var classify in NewsClassifyLst)
            {
                response.data.Add(new NewsClassifyModel
                {
                    Id = classify.Id,
                    Name = classify.Name,
                    Sort = classify.Sort,
                    Remark = classify.Remark
                });
            }
            return response;
        }

        public List<MainModel> GetLayOutList(ResponseModel userList)
        {
            var users = _userService.GetUsersByAccount(userList.data.F_Account);
            var usersendmessageCount = _usersendmessageService.GetOneUserSendMessageByUserId(userList.data.F_UserId).data.Count;
            List<MainModel> mmLst = new List<MainModel>();
            mmLst.Add(new MainModel
            {
                username = userList.data.F_Account,
                image = userList.data.F_Image == null ? "/UserPic/defalt.jpg" : userList.data.F_Image,
                userId = userList.data.F_UserId,
                messageCount = usersendmessageCount > 0 ? $"({usersendmessageCount.ToString()})" : ""
            });
            return mmLst;
        }

        /// <summary>
        /// 添加新闻
        /// </summary>
        public ResponseModel AddNews(AddNews news)
        {
            var classify = this.GetOneNewsClassify(c => c.Id == news.NewsClassifyId);
            if (classify == null)
                return new ResponseModel { code = 0, result = "该类别不存在" };
            var n = new News
            {
                NewsClassifyId = news.NewsClassifyId,
                Title = news.Title,
                Image = news.Image,
                Contents = news.Contents,
                PublishDate = DateTime.Now,
                Remark = news.Remark
            };
            _db.News.Add(n);
            int i = _db.SaveChanges();
            if (i > 0)
                return new ResponseModel { code = 200, result = "新闻添加成功" };
            return new ResponseModel { code = 0, result = "新闻添加失败" };
        }


        /// <summary>
        /// 添加帖子
        /// </summary>
        /// <param name="banner"></param>
        /// <returns></returns>
        public ResponseModel AddPost(AddNews news)
        {
            var n = new News { NewsClassifyId = news.NewsClassifyId, UserId = news.UserId, Title = news.Title, Contents = news.Contents, PublishDate = DateTime.Now };
            //添加
            _db.News.Add(n);
            //保存操作
            int i = _db.SaveChanges();
            //判断是否添加成功
            if (i > 0)
                return new ResponseModel { code = 200, result = "发帖成功" };
            return new ResponseModel { code = 0, result = "发帖失败" };

        }



        /// <summary>
        /// 获取一个新闻
        /// </summary>
        public ResponseModel GetoneNews(int id)
        {
            var news = _db.News.Include("NewsClassify").Include("NewsComment").FirstOrDefault(c => c.Id == id);
            if (news == null)
                return new ResponseModel { code = 0, result = "该新闻不存在" };
            return new ResponseModel
            {
                code = 200,
                result = "新闻获取成功",
                data = new NewsModel
                {
                    Id = news.Id,
                    ClassifyName = news.NewsClassify.Name,
                    Title = news.Title,
                    Image = news.Image,
                    Contents = news.Contents,
                    PublishDate = news.PublishDate.ToString("yyyy-MM-dd"),
                    CommentCount = news.NewsComment.Count(),
                    Remark = news.Remark
                }
            };
        }


        /// <summary>
        /// 获取用户发布的帖子
        /// </summary>
        public ResponseModel GetUserPost(int id)
        {
            var news = _db.News.Where(s => s.UserId == id).Take(5).ToList();
            if (news == null)
                return new ResponseModel { code = 0, result = "该帖子不存在" };
            var response = new ResponseModel
            {
                code = 200,
                result = "帖子获取成功"
            };
            response.data = new List<NewsModel>();
            foreach (var n in news)
            {
                response.data.Add(new NewsModel
                {
                    Id = n.Id,
                    Title = n.Title,
                    PublishDate = n.PublishDate.ToString("yyyy-MM-dd")
                });
            }
            return response;
        }


        /// <summary>
        /// 删除一个新闻
        /// </summary>
        public ResponseModel DelOneNews(int id)
        {
            var news = _db.News.FirstOrDefault(c => c.Id == id);
            if (news == null)
                return new ResponseModel { code = 0, result = "该新闻不存在" };
            _db.News.Remove(news);
            int i = _db.SaveChanges();
            if (i > 0)
                return new ResponseModel { code = 200, result = "新闻删除成功" };
            return new ResponseModel { code = 0, result = "新闻删除失败" };
        }

        public ResponseModel DelOneNewsClassify(int id)
        {
            var newsclassify = _db.NewsClassify.FirstOrDefault(c => c.Id == id);
            if (newsclassify == null)
                return new ResponseModel { code = 0, result = "该新闻类别不存在" };
            _db.NewsClassify.Remove(newsclassify);
            int i = _db.SaveChanges();
            if (i > 0)
                return new ResponseModel { code = 200, result = "新闻类别删除成功!" };
            return new ResponseModel { code = 0, result = "新闻类别删除失败!" };
        }


        /// <summary>
        /// 分页查询新闻
        /// </summary>
        public ResponseModel NewsPageQuery(int pageSize, int pageIndex, int Querytype, out int total, List<Expression<Func<News, bool>>> where)
        {
            var list = _db.News.Include("NewsClassify").Include("NewsComment");
            foreach (var item in where)
            {
                list = list.Where(item);
            }
            int totalCount = 0;
            var pageData = new List<News>();
            if (Querytype == 0) //查询所有
            {
                pageData = list.OrderByDescending(c => c.PublishDate).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
                totalCount = list.Count();
            }
            if (Querytype == 1) //查询篮球模块
            {
                pageData = list.Where(s => s.NewsClassify.ParentId == 0 && s.NewsClassify.ClassifyType == 0).OrderByDescending(c => c.PublishDate).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
                totalCount = list.Where(s => s.NewsClassify.ParentId == 0 && s.NewsClassify.ClassifyType == 0).Count();
            }
            if (Querytype == 2) //查询步行街
            {
                pageData = list.Where(s => s.NewsClassify.ParentId != 0 && s.NewsClassify.ClassifyType == 1).OrderByDescending(c => c.PublishDate).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
                totalCount = list.Where(s => s.NewsClassify.ParentId != 0 && s.NewsClassify.ClassifyType == 1).Count();
            }
            total = totalCount;
            var response = new ResponseModel
            {
                code = 200,
                result = "分页新闻获取成功"
            };
            response.data = new List<NewsModel>();
            HtmlToText convert = new HtmlToText();
            foreach (var news in pageData)
            {
                response.data.Add(new NewsModel
                {
                    Id = news.Id,
                    ClassifyId = news.NewsClassify.Id,
                    ClassifyName = news.NewsClassify.Name,
                    Title = news.Title,
                    Image = news.Image,
                    Contents = convert.Convert(news.Contents).Length > 50 ? $"{convert.Convert(news.Contents).Substring(0, 50)}..." : convert.Convert(news.Contents),
                    PublishDate = news.PublishDate.ToString("yyyy-MM-dd"),
                    CommentCount = news.NewsComment.Count(),
                    LoveCount = news.NewsComment.Sum(s => s.Love),
                    Remark = news.Remark == null ? "" : news.Remark
                });
            }
            return response;
        }
        /// <summary>
        /// 查询新闻列表
        /// </summary>
        public ResponseModel GetNewsList(Expression<Func<News, bool>> where, int NewsClassifyId, int topCount)
        {
            var listAll = _db.News.Include("NewsClassify").Include("NewsComment");
            var list = new List<News>();
            if (NewsClassifyId == 0) //所有球队
            {
                list = listAll.Where(s => s.NewsClassify.ParentId == 0 && s.NewsClassify.ClassifyType == 0).OrderByDescending(c => c.PublishDate).Take(topCount).ToList();
            }
            else
            {
                var NewsClassifylst = _db.NewsClassify.Find(NewsClassifyId);
                if (NewsClassifylst.ParentId == 0 && NewsClassifylst.ClassifyType == 1)
                {
                    var newsIds = _db.NewsClassify.Where(s => s.ParentId == NewsClassifyId).Select(c => c.Id);
                    list = listAll.Where(s => newsIds.Contains(s.NewsClassifyId)).OrderByDescending(c => c.PublishDate).Take(topCount).ToList();
                }
                else
                {
                    list = listAll.Where(s => s.NewsClassifyId == NewsClassifyId).OrderByDescending(c => c.PublishDate).Take(topCount).ToList();
                }
            }
            var response = new ResponseModel
            {
                code = 200,
                result = "新闻列表获取成功"
            };
            response.data = new List<NewsModel>();
            HtmlToText convert = new HtmlToText();
            foreach (var news in list)
            {
                response.data.Add(new NewsModel
                {
                    Id = news.Id,
                    ClassifyName = news.NewsClassify.Name,
                    Title = news.Title,
                    Image = news.Image == null ? convert.ConvertImgSrc(news.Contents) : news.Image,
                    Contents = convert.Convert(news.Contents).Length > 50 ? $"{convert.Convert(news.Contents).Substring(0, 50)}..." : convert.Convert(news.Contents),
                    PublishDate = news.PublishDate.ToString("yyyy-MM-dd"),
                    CommentCount = news.NewsComment.Count(),
                    LoveCount = news.NewsComment.Sum(s => s.Love),
                    Remark = news.Remark
                });
            }
            return response;
        }





        /// <summary>
        /// 获取最新评论的新闻集合
        /// </summary>
        public ResponseModel GetNewCommentNewsList(Expression<Func<News, bool>> where, int topCount)
        {
            //var newsIds = _db.NewsComment.OrderByDescending(c => c.AddTime).GroupBy(c => c.NewsId).Select(c => c.Key).Take(topCount);
            var newsIds = _db.NewsComment.Where(a => !_db.NewsComment.Any(x => x.Id < a.Id && x.NewsId == a.NewsId)).OrderByDescending(a => a.AddTime).Select(c => c.NewsId).Take(topCount);
            var list = _db.News.Include("NewsClassify").Include("NewsComment").Where(c => newsIds.Contains(c.Id) && c.NewsClassify.ParentId == 0 && c.NewsClassify.ClassifyType == 0).OrderByDescending(c => c.PublishDate);
            var response = new ResponseModel
            {
                code = 200,
                result = "最新评论的新闻获取成功"
            };
            response.data = new List<NewsModel>();
            foreach (var news in list)
            {
                response.data.Add(new NewsModel
                {
                    Id = news.Id,
                    ClassifyName = news.NewsClassify.Name,
                    Title = news.Title,
                    Image = news.Image,
                    Contents = news.Contents.Length > 50 ? news.Contents.Substring(0, 50) : news.Contents,
                    PublishDate = news.PublishDate.ToString("yyyy-MM-dd"),
                    CommentCount = news.NewsComment.Count(),
                    Remark = news.Remark
                });
            }
            return response;
        }

        /// <summary>
        /// 搜索一个新闻
        /// </summary>
        public ResponseModel GetSearchOneNews(Expression<Func<News, bool>> where)
        {
            var news = _db.News.Where(where).FirstOrDefault();
            if (news == null)
                return new ResponseModel { code = 0, result = "新闻搜索失败" };
            return new ResponseModel { code = 200, result = "新闻搜索成功", data = news.Id };
        }
        /// <summary>
        /// 获取新闻数量
        /// </summary>
        public ResponseModel GetNewsCount(Expression<Func<News, bool>> where)
        {
            var count = _db.News.Where(where).Count();
            return new ResponseModel { code = 200, result = "新闻数量获取成功", data = count };
        }
        /// <summary>
        /// 获取推荐新闻列表
        /// </summary>
        public ResponseModel GetRecommendNewsList(int newsId)
        {
            var news = _db.News.FirstOrDefault(c => c.Id == newsId);
            if (news == null)
                return new ResponseModel { code = 0, result = "新闻不存在" };
            var newsList = _db.News.Include("NewsComment").Where(c => c.NewsClassifyId == news.NewsClassifyId && c.Id != newsId).OrderByDescending(c => c.PublishDate).OrderByDescending(c => c.NewsComment.Count).Take(6).ToList();
            var response = new ResponseModel
            {
                code = 200,
                result = "最新评论的新闻获取成功"
            };
            response.data = new List<NewsModel>();
            foreach (var n in newsList)
            {
                response.data.Add(new NewsModel
                {
                    Id = n.Id,
                    ClassifyName = n.NewsClassify.Name,
                    Title = n.Title,
                    Image = n.Image,
                    Contents = n.Contents.Length > 50 ? n.Contents.Substring(0, 50) : n.Contents,
                    PublishDate = n.PublishDate.ToString("yyyy-MM-dd"),
                    CommentCount = n.NewsComment.Count(),
                    Remark = n.Remark
                });
            }
            return response;
        }
    }
}
