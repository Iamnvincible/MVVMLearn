using MVVMSample.Common;
using MVVMSample.Model;
using MVVMSample.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MVVMSample.ViewModel
{
    public class MainViewModel
    {
        public List<Data> ListDatas { get; set; }
        public ICommand GoToDetail { get; set; }
        public MainViewModel()
        {
            ListDatas = DataService.GetDatas();
            GoToDetail = new RelayCommand(Para =>
              {
                  Frame rootFrame = Window.Current.Content as Frame;
                  if (rootFrame != null)
                  {
                      rootFrame.Navigate(typeof(DetailPage), Para);
                  }
              });
        }
    }
}
