using CommunityToolkit.Maui.Alerts;
using Ethel.Auth;
using Ethel.Views;
using Microsoft.Identity.Client;

namespace Ethel;

public partial class MainPage : ContentPage
{
    private readonly LandingPage _landingPage;
    private readonly IAuthService _authService;
    public MainPage(LandingPage landingPage, AuthService authService)
	{
		_landingPage = landingPage;
        _authService= authService;
		InitializeComponent();

	}

    async void OnLoginClicked(object? sender, EventArgs args)
    {
        var myUsername = Username.Text;
        var myPassword = Password.Text;
        try
        {
            var item = await _authService.SignInByUsernameAndPassword(CancellationToken.None,myUsername, myPassword);
            await _authService.GetUserInfo(item);
            await Navigation.PushAsync(_landingPage);
        }
        catch (MsalClientException ex)
        {
            await Toast.Make(ex.Message).Show();
        }

        Preferences.Default.Set("first_name", "John");
    }


}

