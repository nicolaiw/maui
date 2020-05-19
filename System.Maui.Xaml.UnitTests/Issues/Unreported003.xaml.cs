using System;
using System.Collections.Generic;

using System.Maui;
using NUnit.Framework;

namespace System.Maui.Xaml.UnitTests
{
	public partial class Unreported003 : ContentPage
	{
		public Unreported003 ()
		{
			InitializeComponent ();
		}

		public Unreported003 (bool useCompiledXaml)
		{
			//this stub will be replaced at compile time
		}

		[TestFixture]
		class Tests
		{
			[TestCase(true), TestCase(false)]
			public void AllowCtorArgsForValueTypes (bool useCompiledXaml)
			{
				var page = new Unreported003 (useCompiledXaml);
			}
		}
	}
}