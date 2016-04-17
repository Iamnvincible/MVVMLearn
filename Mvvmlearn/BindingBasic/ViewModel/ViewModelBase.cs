using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BindingBasic.Annotations;

namespace BindingBasic.ViewModel
{
   public class ViewModelBase:INotifyPropertyChanged
    {
       public event PropertyChangedEventHandler PropertyChanged;

       [NotifyPropertyChangedInvocator]
       protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
       {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            //if (PropertyChanged != null)
            //{
            //    PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
            //}
        }
    }
}
