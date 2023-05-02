using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System.Threading;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace UITest1
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void Repl()
        {
            app.Repl();
        }

        // will pass
        [Test]
        public void PressButtonTest()
        {
            app.Screenshot("App Loaded");

            //check if Button  is on screen
            Query countButton = x => x.Marked("CountButton");
            app.WaitForElement(countButton);

            //tap button
            app.Tap(countButton);

            // check label updated
            var buttonLabelValue = "Clicked 1 time";
            Assert.DoesNotThrow(() => app.WaitForElement(x => x.Marked(buttonLabelValue)), "Button was not clicked");

            app.Screenshot("Button Clicked 1 time");
        }

        // default fails, uncomment line to pass
        [Test]
        public void TapButtonTwice()
        {
            app.Screenshot("App Loaded");

            //check if Button  is on screen
            Query countButton = x => x.Marked("CountButton");
            app.WaitForElement(countButton);

            //tap button
            app.Tap(countButton);
            //app.Tap(countButton);

            // check label updated
            var buttonLabelValue = "Clicked 2 times";
            Assert.DoesNotThrow(() => app.WaitForElement(x => x.Marked(buttonLabelValue)), "Button was not clicked 2 times");

            app.Screenshot("Button Clicked 2 times");
        }
    }
}