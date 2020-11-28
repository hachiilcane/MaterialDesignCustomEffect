using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace MaterialDesignCustomEffect.Views
{
    public class RippleAdorner : Adorner
    {
        private VisualCollection _visualCollection;
        private ExecutableRipple _ripple;

        public RippleAdorner(UIElement adornedElement) : base(adornedElement)
        {
            _ripple = new ExecutableRipple();
            _ripple.IsHitTestVisible = false;
            
            var binding = new Binding("Foreground")
            {
                Source = adornedElement,
                Converter = new BrushRoundConverter()
            };
            _ripple.SetBinding(ExecutableRipple.FeedbackProperty, binding);

            _visualCollection = new VisualCollection(this);
            _visualCollection.Add(_ripple);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            var element = this.AdornedElement as FrameworkElement;
            _ripple.Arrange(new Rect(0, 0, element.ActualWidth, element.ActualHeight));

            return finalSize;
        }

        protected override int VisualChildrenCount
        {
            get { return _visualCollection.Count; }
        }

        protected override Visual GetVisualChild(int index)
        {
            return _visualCollection[index];
        }

        public void DoRipple()
        {
            _ripple.DoRipple();
        }
    }
}
