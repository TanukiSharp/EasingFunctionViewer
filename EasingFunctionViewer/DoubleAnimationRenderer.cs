using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace EasingFunctionViewer
{
	public class DoubleAnimationRenderer : RendererBase
	{
		private readonly IEnumerable<TimedValue<double>> points;
		private readonly Pen zeroLinePen;

		public Pen LinePen { get; set; }
		public double ValueCoeficient { get; set; }
		public double UnitPerSecond { get; set; }

		public DoubleAnimationRenderer(IEnumerable<TimedValue<double>> points)
		{
			this.points = points;

			zeroLinePen = new Pen(new SolidColorBrush(Color.FromArgb(128, 20, 120, 255)), 1.0);
            if (zeroLinePen.CanFreeze)
                zeroLinePen.Freeze();

            LinePen = new Pen(Brushes.Black, 1.0);
			LinePen.EndLineCap = PenLineCap.Round;

            if (LinePen.CanFreeze)
                LinePen.Freeze();

			UnitPerSecond = 300.0;
		}

		protected override void Render(DrawingContext drawingContext)
		{
			TimedValue<double> previousValue = null;

			foreach (TimedValue<double> value in points)
			{
				if (previousValue == null)
				{
					previousValue = value;
					continue;
				}

				drawingContext.DrawLine(LinePen,
					new Point(previousValue.Time * UnitPerSecond, previousValue.Value * ValueCoeficient),
					new Point(value.Time * UnitPerSecond, value.Value * ValueCoeficient));

				previousValue = value;
			}

            drawingContext.DrawLine(
                zeroLinePen,
                new Point(0.0, 0.0),
                new Point(previousValue.Time * UnitPerSecond, 0.0)
            );
        }
    }
}
