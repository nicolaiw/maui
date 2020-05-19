using System;
using System.Collections.Generic;

namespace System.Maui.StyleSheets
{
	interface IStyleSelectable
	{
		string[] NameAndBases { get; }
		string Id { get; }
		IStyleSelectable Parent { get; }
		IList<string> Classes { get; }
		IEnumerable<IStyleSelectable> Children { get; }
	}

	interface IStylable
	{
		BindableProperty GetProperty(string key, bool inheriting);
	}
}