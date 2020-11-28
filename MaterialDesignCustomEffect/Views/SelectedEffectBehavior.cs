using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace MaterialDesignCustomEffect.Views
{
    public class SelectedEffectBehavior : Behavior<TextBox>
    {
        private RippleAdorner _rippleAdorner;

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.TextChanged += AssociatedObject_TextChanged;
            AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.TextChanged -= AssociatedObject_TextChanged;
            AssociatedObject.Loaded -= AssociatedObject_Loaded;

            base.OnDetaching();
        }

        private void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _rippleAdorner = new RippleAdorner(AssociatedObject);
            var myAdornerLayer = AdornerLayer.GetAdornerLayer(AssociatedObject);
            myAdornerLayer.Add(_rippleAdorner);
        }

        private void AssociatedObject_TextChanged(object sender, TextChangedEventArgs e)
        {
            _rippleAdorner.DoRipple();
        }
    }
}
