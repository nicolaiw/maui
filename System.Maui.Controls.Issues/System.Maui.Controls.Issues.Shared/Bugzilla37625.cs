using System;
using System.Threading.Tasks;

using System.Maui.CustomAttributes;
using System.Maui.Internals;

#if UITEST
using Xamarin.UITest;
using NUnit.Framework;
#endif

namespace System.Maui.Controls.Issues
{
    [Preserve (AllMembers = true)]
    [Issue (IssueTracker.Bugzilla, 37625, "App crashes when quickly adding/removing Image views (Windows UWP)")]
    public class Bugzilla37625 : TestContentPage 
    {
        protected override async void Init ()
        {
            int retry = 5;
            while (retry-- >= 0) {
                var imageUri = new Uri ("https://raw.githubusercontent.com/xamarin/System.Maui/master/System.Maui.ControlGallery.Android/Assets/WebImages/XamarinLogo.png");
                Content = new Image () { Source = new UriImageSource () { Uri = imageUri }, BackgroundColor = Color.Black, AutomationId = "success" };

                await Task.Delay (50);
            }
        }

#if UITEST
        [Test]
        public void Bugzilla37625Test ()
        {
            RunningApp.WaitForElement (q => q.Marked ("success"));
        }
#endif
    }
}
