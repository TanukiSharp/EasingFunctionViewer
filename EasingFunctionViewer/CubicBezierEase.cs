using System;
using System.Windows.Media.Animation;
using System.Windows;

namespace EasingFunctionViewer
{
	public class CubicBezierEase : IEasingFunction
	{
		private Point m_Point1;
		private Point m_Point2;
		private Point m_Control1;
		private Point m_Control2;

		public CubicBezierEase(Point point1, Point control1, Point control2, Point point2)
		{
			m_Point1 = point1;
			m_Control1 = control1;
			m_Control2 = control2;
			m_Point2 = point2;
		}

		public double Ease(double normalizedTime)
		{
			double t = normalizedTime;
			double invt = 1.0 - normalizedTime;

			Point result = new Point();

			result = result.Add(m_Point1.Multiply(invt * invt * invt));
			result = result.Add(m_Control1.Multiply(3 * invt * invt * t));
			result = result.Add(m_Control2.Multiply(3 * invt * t * t));
			result = result.Add(m_Point2.Multiply(t * t * t));

    		return result.Y;
		}
	}

	public static class PointExtension
	{
		public static Point Add(this Point point, Point value)
		{
			return new Point(point.X + value.X, point.Y + value.Y);
		}

		public static Point Multiply(this Point point, double value)
		{
			return new Point(point.X * value, point.Y * value);
		}
	}
}
