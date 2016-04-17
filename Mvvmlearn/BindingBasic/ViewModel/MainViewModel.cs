using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using BindingBasic.Model;

namespace BindingBasic.ViewModel
{
    public class MainViewModel:ViewModelBase
    {
        private string text;

        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                OnPropertyChanged(nameof(Text));
            }
        }
        public List<Student> Stu { get; set; }

        public MainViewModel()
        {
            Stu = new List<Student>();
            for (int i = 0; i < 1000; i++)
            {
                Student s = new Student {Name = DateTime.Now.ToString()};
                Stu.Add(s);
            }
        }
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            Text = DateTime.Now.ToString();
        }
    }
}
