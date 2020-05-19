using System.Maui.CustomAttributes;
using System.Maui.Internals;

namespace System.Maui.Controls.Issues
{
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Bugzilla, 39378, "Image binding with caching not operating as expected", PlatformAffected.All)]
	public partial class Bugzilla39378 : TestContentPage
	{
#if APP
		public Bugzilla39378()
		{
			InitializeComponent();
		}
#endif

		protected override void Init()
		{
			BindingContext = new ImageController39378();
		}

		[Preserve(AllMembers = true)]
		class ImageController39378 : ViewModelBase
		{
			
			public ImageController39378()
			{
				HomeImage = "https://raw.githubusercontent.com/xamarin/System.Maui/master/banner.png";
				BackgroundColor = "#f5f5dc";
			}

			public string BackgroundColor
			{
				get
				{ 
					return _backgroundColor;
				}

				set
				{
					_backgroundColor = value;
					OnPropertyChanged();
				}
			}

			public string HomeImage
			{
				get
				{ 
					return _homeImage;
				}

				set
				{
					_homeImage = value;
					OnPropertyChanged();
				}
			}

			string _backgroundColor;
			string _homeImage;
		}
	}
}