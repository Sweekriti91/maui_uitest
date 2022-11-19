using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITest1
{
    public class AppInitializer
    {
        //const string MauiApkPath = "C:/code/maui_uitest/MauiApp1/MauiApp1/bin/Release/net6.0-android/com.companyname.mauiapp1-Signed.apk";
        //const string MauiAndroidApkPath = "C://code//maui_uitest//MauiApp1//MauiApp1//bin//Release//net7.0-android//com.companyname.mauiapp1-Signed.apk";
        const string MauiAndroidApkPath = "../../../MauiApp1/bin/Release/net7.0-android/com.companyname.mauiapp1-Signed.apk";
        //const string AppPath = "../../../MauiApp1/bin/Debug/net6.0-ios/";
        //const string IpaBundleId = "";

        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    //.ApkFile(MauiApkPath)
                    .ApkFile(MauiAndroidApkPath)
                    .StartApp();
            }

            return ConfigureApp
                .iOS
                //.AppBundle(AppPath)
                //.InstalledApp(IpaBundleId)
                .StartApp();
        }
    }
}