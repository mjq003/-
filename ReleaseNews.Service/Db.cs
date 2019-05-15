using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ReleaseNews.Models.Entity;

namespace ReleaseNews.Service
{
    /// <summary>
    /// 数据上下文
    /// </summary>
    public class Db : DbContext
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Db()
        {
        }

        /// <summary>
        /// 重写 OnConfiguring
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //数据库连接
            optionsBuilder.UseSqlServer(AppConfig.SqlConnectionString, b => b.UseRowNumberForPaging());

        }
        /// <summary>
        /// 重写 OnModelCreating
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Banner> Banner { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<NewsClassify> NewsClassify { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<NewsComment> NewsComment { get; set; }
        public virtual DbSet<UsersFollow> UsersFollow { get; set; }
        public virtual DbSet<NewsCommentLove> NewsCommentLove { get; set; }
        public virtual DbSet<UserSendMessage> UserSendMessage { get; set; }
    }
}
