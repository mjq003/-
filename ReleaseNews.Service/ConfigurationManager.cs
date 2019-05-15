using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ReleaseNews.Service
{
    public class ConfigurationManager
    {
        public readonly static IConfiguration Configuration;

        /// <summary>
        /// 设置读取配置文件
        /// </summary>
        static ConfigurationManager()
        {
            Configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true).Build();
        }
    }
}
