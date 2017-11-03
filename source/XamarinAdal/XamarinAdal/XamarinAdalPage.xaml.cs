using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinAdal.Interfaces;

namespace XamarinAdal
{
    public partial class XamarinAdalPage : ContentPage
    {
        public XamarinAdalPage()
        {
            InitializeComponent();
        }

        async void Login_Clicked(object sender, System.EventArgs e)
        {
            await LoginAsync();
        }

        async void Clear_Clicked(object sender, System.EventArgs e)
        {
            await ClearAsync();
        }

        private async Task LoginAsync()
        {
            var response = await DependencyService.Get<IAuthenticator>().Authenticate(Settings.TenantId, Settings.ResourceId, Settings.ClientId, Settings.ReturnUrl);

            if (response != null)
            {
                await Navigation.PushModalAsync(new HomePage(response));
            }
        }

        private async Task ClearAsync()
        {
            await DependencyService.Get<IAuthenticator>().ClearToken(Settings.TenantId);
        }
    }
}