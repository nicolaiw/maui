using System;
using Android.Content;
using Android.OS;
using Android.Util;
using AProgressBar = Android.Widget.ProgressBar;
using Android.Graphics.Drawables;
using AColor = Android.Graphics.Color;
using Android.Content.Res;
using Android.Views;
using Android.Graphics;

namespace System.Maui.Platform.Android
{
	internal class CircularProgress : AProgressBar
	{
		public int MaxSize { get; set; } = int.MaxValue;

		public int MinSize { get; set; } = 0;

		public AColor DefaultColor { get; set; }

		const int _paddingRatio = 10;

		const int _paddingRatio23 = 14;

		bool _isRunning;

		AColor _backgroudColor;

		public CircularProgress(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
		{
			Indeterminate = true;
		}

		public override void Draw(Canvas canvas)
		{
			base.Draw(canvas);
			if (_isRunning != IsRunning)
				IsRunning = _isRunning;
		}

		public void SetColor(Color color)
		{
			var progress = color.IsDefault ? DefaultColor : color.ToAndroid();

			if (System.Maui.Maui.IsLollipopOrNewer)
			{
				IndeterminateTintList = ColorStateList.ValueOf(progress);
			}
			else
			{
				(Indeterminate ? IndeterminateDrawable : ProgressDrawable).SetColorFilter(color.ToAndroid(), FilterMode.SrcIn);
			}
		}

		public void SetBackgroundColor(Color color)
		{
			_backgroudColor = color.IsDefault ? AColor.Transparent : color.ToAndroid();
			(Background as GradientDrawable)?.SetColor(_backgroudColor);
		}

		AnimatedVectorDrawable AnimatedDrawable => IndeterminateDrawable.Current as AnimatedVectorDrawable;

		public bool IsRunning
		{
			get => AnimatedDrawable?.IsRunning ?? false;
			set
			{
				if (AnimatedDrawable == null)
					return;

				_isRunning = value;
				if (_isRunning && !AnimatedDrawable.IsRunning)
						AnimatedDrawable.Start();
				else if (AnimatedDrawable.IsRunning)
						AnimatedDrawable.Stop();
				
				PostInvalidate();
			}
		}

		public override void Layout(int l, int t, int r, int b)
		{
			var width = r - l;
			var height = b - t;
			var squareSize = Math.Min(Math.Max(Math.Min(width, height), MinSize), MaxSize);
			l += (width - squareSize) / 2;
			t += (height - squareSize) / 2;
			int strokeWidth;
			if (System.Maui.Maui.SdkInt < BuildVersionCodes.N)
				strokeWidth = squareSize / _paddingRatio23;
			else
				strokeWidth = squareSize / _paddingRatio;

			squareSize += strokeWidth;
			base.Layout(l - strokeWidth, t - strokeWidth, l + squareSize, t + squareSize);
		}
	}
}