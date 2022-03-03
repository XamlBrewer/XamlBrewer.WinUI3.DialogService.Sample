using Microsoft.UI.Xaml;
using XamlBrewer.WinUI3.Services;

namespace XamlBrewer.WinUI3.DialogService.Sample
{
    public partial class App : Application
    {
        private Shell shell;

        public App()
        {
            InitializeComponent();
        }

        public static FrameworkElement MainRoot { get; private set; }

        public INavigation Navigation => shell;

        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            shell = new Shell();
            shell.Activate();
            MainRoot = shell.Content as FrameworkElement;
        }
    }
}
