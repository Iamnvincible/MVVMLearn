using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Relaycommand
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MainViewModel mvm;
        public MainPage()
        {
            this.InitializeComponent();
            mvm = new MainViewModel();
            mvm.UIStoryboard += (s, e) =>
            {
                story1.Begin();
            };
            this.DataContext = mvm;
        }



        private async void StackPanel_ManipulationInertiaStarting(object sender, ManipulationInertiaStartingRoutedEventArgs e)
        {
            await new MessageDialog("你摸我！").ShowAsync();

        }

        private void TextBlock_ManipulationStarting(object sender, ManipulationStartingRoutedEventArgs e)
        {

        }
    }
}
