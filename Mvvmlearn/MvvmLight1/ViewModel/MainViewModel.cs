using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using MvvmLight1.Model;
using System.Windows.Input;
using Windows.Devices.Sensors;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MvvmLight1.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        //private RelayCommand<object> _story1Command;
        //private RelayCommand<string> showDialogCommand;
        private RelayCommand<object> _checkedCommand;


        //public RelayCommand<string> ShowDialogCommand
        //{
        //    get
        //    {
        //        return showDialogCommand ?? (showDialogCommand = new RelayCommand<string>(async (e) =>
        //         {
        //             await new MessageDialog(e).ShowAsync();
        //         }));
        //    }
        //}
        //C#6新特性的使用
        public RelayCommand<string> ShowDialogCommand { get; } = new RelayCommand<string>(async (e) =>
          {
              await new MessageDialog(e).ShowAsync();
          });

        public RelayCommand Story1Command { get; } = new RelayCommand(() =>
         {
             Messenger.Default.Send("start", "OpacityStory");
         });

        //    get
        //    {
        //        return _story1Command ?? (_story1Command = new RelayCommand<object>((s) =>
        //            {
        //                Messenger.Default.Send<object>(new object());
        //            }));
        //    }
        //}

        public RelayCommand<object> CheckedCommand
        {
            get
            {
                return _checkedCommand ?? (_checkedCommand = new RelayCommand<object>(async (s) =>
                {
                    await new MessageDialog(s.ToString()).ShowAsync();
                }));
            }
        }

        public RelayCommand<object> NaviCommand
        {
            get
            {
                return new RelayCommand<object>((para) =>
                {
                    Frame rootFrame = Window.Current.Content as Frame;
                    rootFrame?.Navigate(typeof(DetailPage), para);
                });
            }
        }
    }
}