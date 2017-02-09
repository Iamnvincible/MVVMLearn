using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Views;

namespace MVVM2017.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private bool _isactive
            ;

        public bool IsActive
        {
            get { return _isactive; }
            set { Set(ref _isactive, value); }
        }
        public ICommand ChangeProgressCommand { get; set; }
        public ICommand GotoNextCommand { get; set; }
        private void ChangeProgress()
        {
            IsActive = !IsActive;
        }
        public MainViewModel()
        {
            IsActive = true;
            ChangeProgressCommand = new RelayCommand(ChangeProgress);
            GotoNextCommand = new RelayCommand(() =>
              {
                  var navigationService = ServiceLocator.Current.GetInstance<INavigationService>();
                  navigationService.NavigateTo("PageTwo");
              });
        }
    }
}
