using System.Diagnostics;
using Windows.UI.Core;
using Windows.UI.Xaml.Navigation;
using MvvmLight1.ViewModel;
using GalaSoft.MvvmLight.Messaging;

namespace MvvmLight1
{
    public sealed partial class MainPage
    {
        //public MainViewModel Vm => (MainViewModel)DataContext;
        //public MainViewModel vm => (MainViewModel)DataContext;
        public MainPage()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }


        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            Messenger.Default.Unregister(this);
            base.OnNavigatingFrom(e);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Messenger.Default.Register<string>(this, "OpacityStory", Stroryrun);
            base.OnNavigatedTo(e);
        }

        private void Stroryrun(object e)
        {
            this.Story1.Begin();
            Debug.WriteLine(e.ToString());
        }
    }
}
