using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace MvvmLight1.ViewModel
{
    public class DetailViewModel : ViewModelBase
    {
        private int _number;
        //private RelayCommand addCommand;
        public int Number
        {
            get
            {
                return _number;
            }

            set
            {
                _number = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand AddCommand 
        {
            get
            {
                return new RelayCommand(() =>
                {
                    this.Number++;
                });
            }
        }
    }

}

