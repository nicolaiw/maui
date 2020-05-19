using System.Xml;
using Mono.Cecil;
using System.Maui.Xaml;

namespace System.Maui.Build.Tasks
{
	class ILRootNode : RootNode
	{
		public ILRootNode(XmlType xmlType, TypeReference typeReference, IXmlNamespaceResolver nsResolver, int linenumber = -1, int lineposition = -1) : base(xmlType, nsResolver, linenumber: linenumber, lineposition: lineposition)
		{
			TypeReference = typeReference;
		}

		public TypeReference TypeReference { get; private set; }
	}
}