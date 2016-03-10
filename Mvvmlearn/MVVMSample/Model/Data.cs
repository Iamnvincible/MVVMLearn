using MVVMSample.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMSample.Model
{
    public class Data : ModelBase
    {
        private string dataTestString;

        public string DataTestString
        {
            get { return dataTestString; }
            set
            {
                if (value != null)
                {
                    dataTestString = value;
                    OnPropertyChanged("DataTestString");
                }
            }
        }

    }
}
