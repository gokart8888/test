using Xamarin.Forms;

namespace PrismUnityApp2.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnPage1_Clicked(object sender, System.EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new IndexPage());
        }
    }
}
