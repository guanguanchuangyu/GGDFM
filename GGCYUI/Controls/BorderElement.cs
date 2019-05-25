using GGCYUI.Controls.Converters;
using GGCYUI.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace GGCYUI.Controls
{
    public class BorderElement
    {


        #region CornerRadius-#边框圆角值
        public static readonly DependencyProperty CornerRadiusProperty =
    DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(BorderElement), new PropertyMetadata(default(CornerRadius)));
        public static CornerRadius GetCornerRadius(DependencyObject obj)
        {
            return (CornerRadius)obj.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(DependencyObject obj, CornerRadius value)
        {
            obj.SetValue(CornerRadiusProperty, value);
        }
        #endregion


        #region Circular-#
        public static readonly DependencyProperty CircularProperty =
    DependencyProperty.RegisterAttached("Circular", typeof(bool), typeof(BorderElement), new PropertyMetadata(ValueBoxes.FalseBox, OnCircularChanged));
        public static bool GetCircular(DependencyObject obj)
        {
            return (bool)obj.GetValue(CircularProperty);
        }

        public static void SetCircular(DependencyObject obj, bool value)
        {
            obj.SetValue(CircularProperty, value);
        }

        private static void OnCircularChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Border border)
            {
                if ((bool)e.NewValue)
                {
                    var binding = new MultiBinding
                    {
                        Converter = new BorderCircularConverter()
                    };
                    binding.Bindings.Add(new Binding(FrameworkElement.ActualWidthProperty.Name) { Source = border });
                    binding.Bindings.Add(new Binding(FrameworkElement.ActualHeightProperty.Name) { Source = border });
                    border.SetBinding(Border.CornerRadiusProperty, binding);
                }
                else
                {
                    BindingOperations.ClearBinding(border, FrameworkElement.MinWidthProperty);
                    BindingOperations.ClearBinding(border, FrameworkElement.MinHeightProperty);
                    BindingOperations.ClearBinding(border, Border.CornerRadiusProperty);
                }
            }
        }
        #endregion
    }
}
