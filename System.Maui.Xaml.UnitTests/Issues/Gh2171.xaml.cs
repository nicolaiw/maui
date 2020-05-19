using System;
using NUnit.Framework;
using System.Maui.Core.UnitTests;

namespace System.Maui.Xaml.UnitTests
{
	public partial class Gh2171 : ContentPage
	{
		public Gh2171()
		{
			InitializeComponent();
		}

		public Gh2171(bool useCompiledXaml)
		{
			//this stub will be replaced at compile time
		}

		[TestFixture]
		class Tests
		{
			[SetUp]
			public void Setup()
			{
				Device.PlatformServices = new MockPlatformServices();
			}

			[TearDown]
			public void TearDown()
			{
				Device.PlatformServices = null;
			}

			[TestCase(false), TestCase(true)]
			public void ParsingNestedMarkups(bool useCompiledXaml)
			{
				var layout = new Gh2171(useCompiledXaml);
				var markup = layout.BindingContext as Gh2171Extension;
				Assert.That(markup, Is.Not.Null);
				Assert.That(markup.Foo, Is.EqualTo("foo"));
				Assert.That(markup.Bar, Is.EqualTo("bar"));
				Assert.That((markup.Binding as Binding).Path, Is.EqualTo("Text"));
			}
		}
	}

	public class Gh2171Extension : IMarkupExtension
	{
		public string Foo { get; set; }
		public string Bar { get; set; }
		public BindingBase Binding { get; set; }
		object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => this;
	}
}
