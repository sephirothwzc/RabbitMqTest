using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Sephiroth.Infrastructure.Common.Log4Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqTest
{
    /// <summary>
    /// CLR 版本：       4.0.30319.42000
    /// 类 名 称：       MqHelper
    /// 机器名称：       102F
    /// 命名空间：       RabbitMqTest
    /// 文 件 名：       MqHelper
    /// 创建时间：       2018/11/14 下午1:57:22
    /// 作    者：       吴占超
    /// 说    明：       
    /// 修改时间：
    /// 修 改 人：
    /// </summary>
    public class MqHelper
    {
        public void Register()
        {
            Console.WriteLine("Received Mq");
            Task.Factory.StartNew(() =>
            {
                var factory = new ConnectionFactory();
                factory.HostName = "localhost";
                factory.UserName = "guest";
                factory.Password = "guest";

                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        bool durable = true;
                        channel.QueueDeclare("WxMessage", durable, false, false, null);
                        channel.BasicQos(0, 1, false);

                        var consumer = new QueueingBasicConsumer(channel);
                        channel.BasicConsume("WxMessage", false, consumer);

                        while (true)
                        {
                            var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();

                            var body = ea.Body;
                            var message = Encoding.UTF8.GetString(body);

                            int dots = message.Split('.').Length - 1;

                            SIC_log4net.WriteLog(this.GetType(), message);
                            //Console.WriteLine("Received {0}", message);
                            //Console.WriteLine("Done");

                            channel.BasicAck(ea.DeliveryTag, false);
                        }
                    }
                }
            });
        }
    }
}
