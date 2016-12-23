using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace EasingFunctionViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //IEasingFunction easingFunction = new PowerEase() { Power = 5.0, EasingMode = EasingMode.EaseInOut };

            //IEasingFunction easingFunction = new CubicBezierEase(
            //    new Point(0.0, 0.0),
            //    new Point(0.5, 0.0),
            //    new Point(0.5, 1.0),
            //    new Point(1.0, 1.0)
            //);

            //IEasingFunction easingFunction = new ElasticEase();
            IEasingFunction easingFunction = new ElasticEase() { EasingMode = EasingMode.EaseIn, Springiness = 2.0 };

            var points = new List<TimedValue<double>>();

            for (double t = 0.0; t < 1.0; t += 0.01)
                points.Add(new TimedValue<double> { Time = t, Value = easingFunction.Ease(t) });

            DoubleAnimationRenderer renderer = new DoubleAnimationRenderer(points);
            renderer.ValueCoeficient = 100.0;
            renderer.UnitPerSecond = 100.0;

            Image image = renderer.PerformRender();

            Content = image;
        }
    }
}
