using CoreGraphics;
using Foundation;

namespace System.Maui.Platform.iOS
{
	internal sealed class HorizontalDefaultCell : DefaultCell
	{
		public static NSString ReuseId = new NSString("System.Maui.Platform.iOS.HorizontalDefaultCell");

		[Export("initWithFrame:")]
		[Internals.Preserve(Conditional = true)]
		public HorizontalDefaultCell(CGRect frame) : base(frame)
		{
			Constraint = Label.HeightAnchor.ConstraintEqualTo(Frame.Height);
			Constraint.Active = true;
		}

		public override void ConstrainTo(CGSize constraint)
		{
			Constraint.Constant = constraint.Height;
		}

		public override CGSize Measure()
		{
			return new CGSize(Label.IntrinsicContentSize.Width, Constraint.Constant);
		}
	}
}