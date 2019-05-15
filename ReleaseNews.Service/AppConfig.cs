using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReleaseNews.Service
{
    public class AppConfig
    {
        /// <summary>
        /// 读取配置文件
        /// </summary>
        public static string SqlConnectionString { get; } = ConfigurationManager.Configuration.GetConnectionString("MsSqlConnection");
    }
}
