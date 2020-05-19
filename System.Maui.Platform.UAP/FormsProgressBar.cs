using global::Windows.UI.Xaml;

namespace System.Maui.Platform.UWP
{
	public class FormsProgressBar : global::Windows.UI.Xaml.Controls.ProgressBar
	{
		public static readonly DependencyProperty ElementOpacityProperty = DependencyProperty.Register(
			nameof(ElementOpacity), typeof(double), typeof(FormsProgressBar), new PropertyMetadata(default(double)));

		public double ElementOpacity
		{
			get { return (double)GetValue(ElementOpacityProperty); }
			set { SetValue(ElementOpacityProperty, value); }
		}

		protected override global::Windows.Foundation.Size MeasureOverride(global::Windows.Foundation.Size availableSize)
		{
			var result = base.MeasureOverride(availableSize);
			if (!double.IsInfinity(availableSize.Width))
				result.Width = availableSize.Width;
			return result;
		}
	}
}
