using System;
using System.Collections.Generic;

using System.Maui;

using NUnit.Framework;

namespace System.Maui.Xaml.UnitTests
{
	public partial class Bz31529 : ContentPage
	{
		public Bz31529 ()
		{
			InitializeComponent ();
		}
		public Bz31529 (bool useCompiledXaml)
		{
			//this stub will be replaced at compile time
		}

		[TestFixture]
		class Tests
		{
			[TestCase(true)]
			[TestCase(false)]
			public void AllowWhiteSpacesInMarkups (bool useCompiledXaml)
			{
				var layout = new Bz31529 (useCompiledXaml);
				Assert.AreEqual ("Foo", layout.button.CommandParameter);
			}
		}
	}
}