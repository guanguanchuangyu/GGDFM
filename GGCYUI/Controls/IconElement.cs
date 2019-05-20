using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace GGCYUI.Controls
{
    public class IconElement
    {

        #region Geometry-#矢量字体图标
        public static readonly DependencyProperty GeometryProperty =
DependencyProperty.RegisterAttached("Geometry", typeof(Geometry), typeof(IconElement), new PropertyMetadata(default(Geometry)));
        public static Geometry GetGeometry(DependencyObject obj)
        {
            return (Geometry)obj.GetValue(GeometryProperty);
        }

        public static void SetGeometry(DependencyObject obj, Geometry value)
        {
            obj.SetValue(GeometryProperty, value);
        }
        #endregion

        #region Width-#图标宽度
        public static readonly DependencyProperty WidthProperty =
DependencyProperty.RegisterAttached("Width", typeof(double), typeof(IconElement), new PropertyMetadata(double.NaN));
        public static double GetWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(WidthProperty);
        }

        public static void SetWidth(DependencyObject obj, double value)
        {
            obj.SetValue(WidthProperty, value);
        }
        #endregion

        #region Height-#图标宽度

        public static readonly DependencyProperty HeightProperty =
    DependencyProperty.RegisterAttached("Height", typeof(double), typeof(IconElement), new PropertyMetadata(double.NaN));
        public static double GetHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(HeightProperty);
        }

        public static void SetHeight(DependencyObject obj, double value)
        {
            obj.SetValue(HeightProperty, value);
        }



        #endregion
    }
}
