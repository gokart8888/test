using Prism.Unity;
using PrismUnityApp2.Views;
using Xamarin.Forms;

namespace PrismUnityApp2
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            //NavigationService.NavigateAsync("NavigationPage/MainPage?title=Hello%20from%20Xamarin.Forms");

            MainPage = new MainPage();
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<IndexPage>();
            Container.RegisterTypeForNavigation<IndexPage>();
        }
    }
}
