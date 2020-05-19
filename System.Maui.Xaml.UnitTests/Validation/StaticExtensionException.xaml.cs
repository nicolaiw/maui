using System;
using System.Collections.Generic;

using System.Maui;

using NUnit.Framework;

namespace System.Maui.Xaml.UnitTests
{	
	[XamlCompilation(XamlCompilationOptions.Skip)]
	public partial class StaticExtensionException : ContentPage
	{	
		public StaticExtensionException ()
		{
			InitializeComponent ();
		}

		public StaticExtensionException (bool useCompiledXaml)
		{
			//this stub will be replaced at compile time
		}

		[TestFixture]
		public class Issue2115
		{
			[TestCase (false)]
			public void xStaticThrowsMeaningfullException (bool useCompiledXaml)
			{
				Assert.Throws (new XamlParseExceptionConstraint (6, 34), () => new StaticExtensionException (useCompiledXaml));
			}
		}
	}
}