using Microsoft.Owin.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqTest
{
    /// <summary>
    /// CLR 版本：       4.0.30319.42000
    /// 类 名 称：       Program
    /// 机器名称：       102F
    /// 命名空间：       RabbitMqTest
    /// 文 件 名：       Program
    /// 创建时间：       2018/11/14 下午1:44:29
    /// 作    者：       吴占超
    /// 说    明：       
    /// 修改时间：
    /// 修 改 人：
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start("http://localhost:9090"))
            {
                Console.ReadLine();
            }
        }
    }
}
