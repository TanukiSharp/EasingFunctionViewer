using System;

namespace EasingFunctionViewer
{
	public class TimedValue<T>
	{
		public double Time { get; set; }
		public T Value { get; set; }

		public override string ToString() => $"{Time:f3} - {Value:f3}";
	}
}
