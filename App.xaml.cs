using Ethel.Handlers;

namespace Ethel;

public partial class App : Application
{
	public App(MainPage mainPage)
	{
		InitializeComponent();

		Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) =>
		{
			if( view is BorderlessEntry)
			{
#if ANDROID
				handler.PlatformView.Background = null;
				handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif IOS
				//handler.PlatformView.Background=UIKit.UIColor.Clear;
				handler.PlatformView.Layer.BorderWidth=0;
				handler.PlatformView.BorderStyle =UIKit.UITextBorderStyle.None;

#elif WINDOWS
				handler.PlatformView.BorderThickness= new Microsoft.UI.Xaml.Thickness(0);
#endif
			}
		});

        MainPage = new NavigationPage(mainPage);
    }

   }
