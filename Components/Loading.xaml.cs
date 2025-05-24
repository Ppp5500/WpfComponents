using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfComponents.Components
{
    /// <summary>
    /// Interaction logic for Loading.xaml
    /// </summary>
    public partial class Loading : Window
    {
        private Stopwatch _stopwatch;
        private DispatcherTimer _timer;

        public Loading()
        {
            InitializeComponent();

            // Bar1
            var animation1 = new DoubleAnimationUsingKeyFrames();
            animation1.KeyFrames.Add(new EasingDoubleKeyFrame(8, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0))));
            animation1.KeyFrames.Add(new EasingDoubleKeyFrame(25, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.4))));
            animation1.KeyFrames.Add(new EasingDoubleKeyFrame(8, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.8)))); // 다시 원래대로
            animation1.KeyFrames.Add(new DiscreteDoubleKeyFrame(8, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1.1)))); // 0.3초 멈춤 효과

            animation1.RepeatBehavior = RepeatBehavior.Forever;
            animation1.BeginTime = TimeSpan.FromSeconds(0); // 즉시 시작
            Bar1.BeginAnimation(HeightProperty, animation1);

            // Bar2
            var animation2 = animation1.Clone();
            animation2.BeginTime = TimeSpan.FromSeconds(0.2); // 0.2초 지연
            Bar2.BeginAnimation(HeightProperty, animation2);

            // Bar3
            var animation3 = animation1.Clone();
            animation3.BeginTime = TimeSpan.FromSeconds(0.4); // 0.4초 지연
            Bar3.BeginAnimation(HeightProperty, animation3);

            _stopwatch = Stopwatch.StartNew();

            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(1000)
            };

            _timer.Tick += (s, args) =>
            {
                Timer.Text = _stopwatch.Elapsed.ToString(@"hh\:mm\:ss");
            };

            _timer.Start();
        }
    }
}
