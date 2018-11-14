using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace RabbitMqTest.Controllers
{
    /// <summary>
    /// CLR 版本：       4.0.30319.42000
    /// 类 名 称：       ValuesController
    /// 机器名称：       102F
    /// 命名空间：       RabbitMqTest.Controllers
    /// 文 件 名：       ValuesController
    /// 创建时间：       2018/11/14 下午1:49:48
    /// 作    者：       吴占超
    /// 说    明：       
    /// 修改时间：
    /// 修 改 人：
    /// </summary>
    public class ValuesController: ApiController
    {
        // GET api/values 
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5 
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values 
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5 
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5 
        public void Delete(int id)
        {
        }
    }
}
