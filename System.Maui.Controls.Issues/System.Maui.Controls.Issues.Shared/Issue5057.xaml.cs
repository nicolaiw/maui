using System;
using System.Collections.Generic;
using System.Maui.CustomAttributes;
using System.Maui.Internals;
using System.Maui.Xaml;

namespace System.Maui.Controls.Issues
{
#if APP
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Github, 5057, "Android: ContentPage BackgroundColor ignored in Forms ",
		PlatformAffected.Android)]
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Issue5057 : ContentPage
	{
		public Issue5057()
		{
			InitializeComponent();
		}

		void BtnSetBkgndColorRed_Clicked(object sender, System.EventArgs e)
		{
			BackgroundColor = Color.Red;
		}

		void BtnSetBkgndImg_Clicked(object sender, System.EventArgs e)
		{
			BackgroundImageSource = "test.jpg";
		}

		void BtnSetBkgndColorDefault_Clicked(object sender, System.EventArgs e)
		{
			BackgroundColor = (Color)BackgroundColorProperty.DefaultValue;
		}

		void BtnSetBkgndImgNull_Clicked(object sender, System.EventArgs e)
		{
			BackgroundImageSource = null;
		}
	}
#endif
}
