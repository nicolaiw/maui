using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Maui;
using System.Maui.CustomAttributes;
using System.Maui.Xaml;

#if UITEST
using System.Maui.Core.UITests;
using Xamarin.UITest;
using NUnit.Framework;
#endif

namespace System.Maui.Controls.Issues
{
	[Issue(IssueTracker.Github, 9196, "[Bug] [iOS] CollectionView EmptyView causes the application to crash",
		PlatformAffected.iOS)]
	public partial class Issue9196 : TestContentPage
	{
		public Issue9196()
		{
#if APP
			InitializeComponent();
#endif
		}

		protected override void Init()
		{
			BindingContext = new _9196ViewModel();
		}

#if UITEST
		[Test, Category(UITestCategories.CollectionView)]
		public void EmptyViewShouldNotCrash()
		{
			RunningApp.WaitForElement("Success");
		}
#endif
	}

	public class _9196ViewModel
	{
		public _9196ViewModel()
		{
			ReceiptsList = new List<string>();
		}

		public List<string> ReceiptsList { get; set; }
	}
}