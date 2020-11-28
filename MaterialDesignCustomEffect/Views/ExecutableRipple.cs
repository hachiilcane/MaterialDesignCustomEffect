using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MaterialDesignCustomEffect.Views
{
    public class ExecutableRipple : Ripple
    {
        /// <summary>
        /// Make a ripple forcely.
        /// </summary>
        public void DoRipple()
        {
            // if IsCentered is set to false, the exception occurs in OnPreviewMouseLeftButtonDown().
            RippleAssist.SetIsCentered(this, true);

            // raise Down and Up event by force.
            OnPreviewMouseLeftButtonDown(null);

            var args = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left)
            {
                RoutedEvent = PreviewMouseLeftButtonUpEvent
            };

            RaiseEvent(args);
        }
    }
}
