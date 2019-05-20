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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GGCYUI.Controls
{
    public class SimplePanel : Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            var maxSize = new Size();
            var children = InternalChildren;
            for (int i = 0, count = children.Count;i < count ; ++i)
            {
                var child = children[i];
                if (child != null)
                {
                    child.Measure(availableSize);
                    maxSize.Width = Math.Max(maxSize.Width, child.DesiredSize.Width);
                    maxSize.Height = Math.Max(maxSize.Height, child.DesiredSize.Height);
                }
            }

            return maxSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            foreach (UIElement child in InternalChildren)
            {
                child?.Arrange(new Rect(finalSize));
            }
            return finalSize;
        }
        static SimplePanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SimplePanel), new FrameworkPropertyMetadata(typeof(SimplePanel)));
        }
    }
}
