using MVVMSample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMSample.ViewModel
{
    public class DetailViewModel
    {
        public string Content { get; set; }
        public DetailViewModel(Data data)
        {
            Content ="内容:"+ data.DataTestString;
        }
    }
}
