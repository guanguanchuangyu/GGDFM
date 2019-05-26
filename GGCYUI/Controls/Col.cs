using GGCYUI.Datas;
using GGCYUI.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GGCYUI.Controls
{
    /// <summary>
    ///  栅格化列的自定义
    /// </summary>
    public class Col:ContentControl
    {
        #region Layout

        public static readonly DependencyProperty LayoutProperty =
    DependencyProperty.Register("Layout", typeof(ColLayout), typeof(Col), new PropertyMetadata(default(ColLayout)));

        public ColLayout Layout
        {
            get { return (ColLayout)GetValue(LayoutProperty); }
            set { SetValue(LayoutProperty, value); }
        }
        #endregion

        #region Offset
        public static readonly DependencyProperty OffsetProperty =
    DependencyProperty.Register("Offset", typeof(int), typeof(Col), new PropertyMetadata(ValueBoxes.IntBox0));
        public int Offset
        {
            get { return (int)GetValue(OffsetProperty); }
            set { SetValue(OffsetProperty, value); }
        }
        #endregion

        #region Span
        public static readonly DependencyProperty SpanProperty =
            DependencyProperty.Register("Span", typeof(int), typeof(Col), new PropertyMetadata(24),OnSpanValidate);

        private static bool OnSpanValidate(object value)
        {
            var v = (int)value;
            return v >= 1 || v <= 24;
        }

        public int Span
        {
            get { return (int)GetValue(SpanProperty); }
            set { SetValue(SpanProperty, value); }
        }
        #endregion

        #region Methods
        internal int GetLayoutCellCount(ColLayoutStatus status)
        {
            var result = 0;
            if (Layout != null)
            {
                switch (status)
                {
                    case ColLayoutStatus.Xs:
                        result = Layout.Xs;
                        break;
                    case ColLayoutStatus.Sm:
                        result = Layout.Sm;
                        break;
                    case ColLayoutStatus.Md:
                        result = Layout.Md;
                        break;
                    case ColLayoutStatus.Lg:
                        result = Layout.Lg;
                        break;
                    case ColLayoutStatus.Xl:
                        result = Layout.Xl;
                        break;
                    case ColLayoutStatus.Xxl:
                        break;
                }
            }
            else
            {
                result = Span;
            }
            return result;
        }
        #endregion
    }
}
