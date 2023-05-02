using Foundation;

namespace MauiApp1;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp()
	{

#if DEBUG
	Xamarin.Calabash.Start();
#endif
		return MauiProgram.CreateMauiApp();
	}
}
