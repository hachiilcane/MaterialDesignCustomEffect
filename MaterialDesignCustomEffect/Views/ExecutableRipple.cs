using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace MaterialDesignCustomEffect.Views
{
    public class ExecutableRipple : Ripple
    {
        private DispatcherTimer _timer;
        private PropertyInfo _rippleXProperty;
        private PropertyInfo _rippleYProperty;

        /// <summary>
        /// Make a ripple forcely.
        /// </summary>
        public void DoRipple()
        {
            if (_timer == null)
            {
                _timer = new DispatcherTimer();
                _timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
                _timer.Tick += _timer_Tick;

                _rippleXProperty = typeof(Ripple).GetProperty(nameof(RippleX), BindingFlags.Instance | BindingFlags.Public);
                _rippleYProperty = typeof(Ripple).GetProperty(nameof(RippleY), BindingFlags.Instance | BindingFlags.Public);
            }

            // if RippleX and RippleY are not set, the center of ripple is at right-bottom corner.
            _rippleXProperty.SetValue(this, ActualWidth / 2 - RippleSize / 2);
            _rippleYProperty.SetValue(this, ActualHeight / 2 - RippleSize / 2);

            VisualStateManager.GoToState(this, TemplateStateNormal, false);
            VisualStateManager.GoToState(this, TemplateStateMousePressed, true);

            // For the purpose of getting a natural effect, add a interval of UI thread.
            _timer.Start();
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();

            VisualStateManager.GoToState(this, TemplateStateNormal, true);
        }
    }
}
