using System;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows;

namespace EasingFunctionViewer
{
	public abstract class RendererBase
	{
		protected abstract void Render(DrawingContext drawingContext);

		public Image PerformRender()
		{
			DrawingGroup drawingGroup = new DrawingGroup();

			using (DrawingContext drawingContext = drawingGroup.Open())
			{
				Render(drawingContext);
			}

			return new Image
			{
				Source = new DrawingImage(drawingGroup),
				RenderTransform = new ScaleTransform(1.0, -1.0),
				RenderTransformOrigin = new Point(0.5, 0.5)
			};
		}
	}
}
