using ReleaseNews.Models.Entity;
using ReleaseNews.Models.Request;
using ReleaseNews.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReleaseNews.Service
{
    /// <summary>
    /// Banner服务
    /// </summary>
    public class BannerService
    {
        private Db _db;
        /// <summary>
        /// 构造函数
        /// </summary>
        public BannerService(Db db)
        {
            this._db = db;
        }
        /// <summary>
        /// 添加Banner
        /// </summary>
        /// <param name="banner"></param>
        /// <returns></returns>
        public ResponseModel AddBanner(AddBanner banner)
        {
            var ba = new Banner { AddTime = DateTime.Now, Image = banner.Image, Url = banner.Url, Remark = banner.Remark };
            //添加
            _db.Banner.Add(ba);
            //保存操作
            int i = _db.SaveChanges();
            //判断是否添加成功
            if (i > 0)
                return new ResponseModel { code = 200,result = "添加成功"};
            return new ResponseModel { code = 0,result = "添加失败" };

        }
        /// <summary>
        /// 获取Banner集合
        /// </summary>
        /// <returns></returns>
        public ResponseModel GetBannerList()
        {   
            //查询全部数据 根据时间排序
            var banners = _db.Banner.ToList().OrderByDescending(c => c.AddTime);
            //new 返回对象；
            ResponseModel response = new ResponseModel();
            response.code = 200;
            response.result = "请求数据成功";
            response.data = new List<BannerModel>();
            foreach (var banner in banners)
            {
                response.data.Add(new BannerModel
                {
                    Id = banner.Id,
                    Image = banner.Image,
                    Url = banner.Url,
                    Remark = banner.Remark
                });
            }
            return response;
        }
        /// <summary>
        /// 删除banner
        /// </summary>
        /// <param name="bannerId"></param>
        /// <returns></returns>
        public ResponseModel DeleteBanner(int bannerId)
        {   
            //查询数据
            var banner = _db.Banner.Find(bannerId);
            //判断是否为空
            if (banner == null)
                return new ResponseModel { code = 0,result = "查询的数据不存在" };
            //否则执行删除
            _db.Banner.Remove(banner);
            //执行保存操作；
            int i = _db.SaveChanges();
            //判断是否删除成功；
            if (i > 0)
                return new ResponseModel { code = 200, result = "删除成功"};
            return new ResponseModel { code = 0,result = "删除失败"};
        }
    }
}
