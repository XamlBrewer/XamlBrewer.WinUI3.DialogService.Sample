using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Diagnostics;
using XamlBrewer.WinUI3.DialogService.Sample.ViewModels;
using XamlBrewer.WinUI3.Services;

namespace XamlBrewer.WinUI3.DialogService.Sample.Views
{
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        public HomePageViewModel ViewModel => DataContext as HomePageViewModel;

        private async void MessageBox_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Message Dialog will be opened.");

            await this.MessageDialogAsync("Ready to go?", "Place a cat, a flask of poison, and a radioactive source in a sealed box.", "Got it");

            Debug.WriteLine("Message Dialog was closed.");
        }
    }
}
