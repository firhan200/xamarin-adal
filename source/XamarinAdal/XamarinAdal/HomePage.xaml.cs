using Xamarin.Forms;
using XamarinAdal.Domain;
using XamarinAdal.Helpers;

namespace XamarinAdal
{
    public partial class HomePage : ContentPage
    {
        AuthenticateResponse Response = null;

        public HomePage()
        {
            InitializeComponent();
        }

        public HomePage(AuthenticateResponse response)
        {
            Response = response;
            InitializeComponent();
            welcome.Text = $"Welcome, {Response.Profile.GivenName}!";
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            message.Text = await RestHelper.CallSecureRestAPI(Response.AccessToken);
        }
    }
}