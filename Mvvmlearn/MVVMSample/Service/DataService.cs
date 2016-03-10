using MVVMSample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMSample.Service
{
    public class DataService
    {
        //业务代码
        public static List<Data> GetDatas()
        {
            return new List<Data>()
            {
                new Data {DataTestString="Alpha" },
                new Data {DataTestString="Beta" },
                new Data {DataTestString="yamma" },
                new Data {DataTestString="yamma" },
                new Data {DataTestString="yamma" }
            };
        }
    }
}
