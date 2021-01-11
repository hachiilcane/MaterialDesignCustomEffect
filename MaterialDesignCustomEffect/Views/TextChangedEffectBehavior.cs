using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace MaterialDesignCustomEffect.Views
{
    // for TextBox
    public class TextChangedEffectBehavior : Behavior<TextBox>
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

    // for TextBlock
    public class TextSourcePropertyChangedEffectBehavior : Behavior<TextBlock>
    {
        private RippleAdorner _rippleAdorner;
        private string _sourcePropertyName;

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.Loaded += AssociatedObject_Loaded;

            var bindingExpr =AssociatedObject.GetBindingExpression(TextBlock.TextProperty);
            if (bindingExpr.ResolvedSource is INotifyPropertyChanged source)
            {
                source.PropertyChanged += Source_PropertyChanged;
                _sourcePropertyName = bindingExpr.ResolvedSourcePropertyName;
            }
        }

        protected override void OnDetaching()
        {
            var bindingExpr = AssociatedObject.GetBindingExpression(TextBlock.TextProperty);
            if (bindingExpr.ResolvedSource is INotifyPropertyChanged source)
            {
                source.PropertyChanged -= Source_PropertyChanged;
                _sourcePropertyName = null;
            }

            AssociatedObject.Loaded -= AssociatedObject_Loaded;

            base.OnDetaching();
        }

        private void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _rippleAdorner = new RippleAdorner(AssociatedObject);
            var myAdornerLayer = AdornerLayer.GetAdornerLayer(AssociatedObject);
            myAdornerLayer.Add(_rippleAdorner);
        }

        private void Source_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == _sourcePropertyName)
            {
                _rippleAdorner.DoRipple();
            }
        }
    }
}
