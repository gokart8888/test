using Xamarin.Forms;

namespace PrismUnityApp2.Views
{
    public partial class IndexPage : ContentPage
    {
        public IndexPage()
        {
            InitializeComponent();
        }

        private void btnPage2_Clicked(object sender, System.EventArgs e)
        {
            lblTest.Text = "已按";
        }
    }
}
