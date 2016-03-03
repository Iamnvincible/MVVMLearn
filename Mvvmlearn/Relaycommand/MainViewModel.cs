using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace Relaycommand
{
    public class MainViewModel
    {
        public ICommand TestCommand { get; set; }
        public int elvalue
        {
            get; set;
        }
        public MainViewModel()
        {
            // TestCommand = new RelayCommand();
            TestCommand = new RelayCommand(async para => 
            {
                await new MessageDialog("你好世界"+para+elvalue).ShowAsync();
            });
        }
    }
}
