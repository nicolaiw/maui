using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Maui.CustomAttributes;
using System.Maui.Internals;
using System.Linq;
using System.Threading.Tasks;


#if UITEST
using Xamarin.UITest;
using NUnit.Framework;
using System.Maui.Core.UITests;
#endif
namespace System.Maui.Controls.Issues
{
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Github, 8784, "[UWP][Bug] SearchBar placeholder, and potentially text, overlaps SearchIcon",
		PlatformAffected.UWP)]
#if UITEST
	[NUnit.Framework.Category(UITestCategories.SearchBar)]
#endif
	public class Issue8784 : TestContentPage
	{
		protected override void Init()
		{
			Title = "Issue 8784";

			StackLayout layout = new StackLayout();

			Label instructions = new Label
			{
				Text = "Check that the placeholder text and content text in SearchBars below does not overlap SearchIcon"
			};

			SearchBar size100PlaceholderSearchBar = new SearchBar
			{
				FontSize = 100f,
				Placeholder = "100pt Placeholder Text"
			};

			SearchBar size100TextSearchBar = new SearchBar
			{
				FontSize = 100f,
				Text = "100pt Content Text"
			};

			layout.Children.Add(instructions);
			layout.Children.Add(size100PlaceholderSearchBar);
			layout.Children.Add(size100TextSearchBar);


			Content = layout;
		}
	}
}
