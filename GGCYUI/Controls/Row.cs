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
    /// 
    /// </summary>
    public class Row : Panel
    {
        private ColLayoutStatus _layoutStatus;
        private double _maxChildDesiredHeight;

        #region Gutter
        public static readonly DependencyProperty GutterProperty =
  DependencyProperty.Register("Gutter", typeof(double), typeof(Row), new PropertyMetadata(ValueBoxes.DoubleBox0,null,OnGutterCoerce), OnGutterValidate);

        private static object OnGutterCoerce(DependencyObject d, object baseValue)
        {
            //判定录入值是否符合浮点要求-不符合则返回默认值
            return OnGutterValidate(baseValue) ? baseValue : .0;
        }

        private static bool OnGutterValidate(object value)
        {
            return ValidateHelper.IsInRangeOfPosDouble(value, true);
        }
        public double Gutter
        {
            get { return (double)GetValue(GutterProperty); }
            set { SetValue(GutterProperty, value); }
        }

        
        #endregion

        protected override Size MeasureOverride(Size constraint)
        {
            //总列数
            var totalCellCount = 0;
            //总行数
            var totalRowCount = 1;
            var gutterHalf = Gutter / 2;
            foreach (var child in InternalChildren.OfType<Col>())
            {
                //设定外边距
                child.Margin = new Thickness(gutterHalf);
                child.Measure(constraint);
                var childDesiredSize = child.DesiredSize;
                //获取到当前子元素的最大高度
                if (_maxChildDesiredHeight < childDesiredSize.Height)
                {
                    //设定当前最大的计算行高度
                    _maxChildDesiredHeight = childDesiredSize.Height;
                }
            }

            //当前计算宽度和最大列数比
            var itemWidth = constraint.Width / ColLayout.ColMaxCelCount;
            //创建(-gutterHalf, -gutterHalf, 0, _maxChildDesiredHeight)的矩形
            var childBounds = new Rect(-gutterHalf, -gutterHalf, 0, _maxChildDesiredHeight);
            _layoutStatus = ColLayout.GetLayoutStatus(constraint.Width);

            //自己数量超出最大数量自动换行
            foreach (var child in InternalChildren.OfType<Col>())
            {
                //获取当前子集模式的设定列数
                var cellCount = child.GetLayoutCellCount(_layoutStatus);
                //统计当前总列数量
                totalCellCount += cellCount;
                //判定当前总列数量是否高于最大列数量-自动换行
                if (totalCellCount > ColLayout.ColMaxCelCount)
                {
                    childBounds.X = -gutterHalf;
                    childBounds.Y = _maxChildDesiredHeight;
                    totalCellCount = cellCount;
                    totalRowCount++;
                }

                //计算新的子集的宽度
                var childWidth = cellCount * itemWidth;
                //重新设定当前矩形的宽度
                childBounds.Width = childWidth;
                child.Arrange(childBounds);
                //重新设定子集的横坐标
                childBounds.X = childWidth + child.Offset * itemWidth;
            }
            return new Size(0, _maxChildDesiredHeight * totalRowCount - Gutter);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            //总列数
            var totalCellCount = 0;
            var gutterHalf = Gutter / 2;
            //设定当前行宽度
            var itemWidth = (finalSize.Width + Gutter) / ColLayout.ColMaxCelCount;
            var childBounds = new Rect(-gutterHalf, -gutterHalf, 0, _maxChildDesiredHeight);
            _layoutStatus = ColLayout.GetLayoutStatus(itemWidth);

            foreach (var child in InternalChildren.OfType<Col>())
            {
                var cellCount = child.GetLayoutCellCount(_layoutStatus);
                totalCellCount += cellCount;

                var childWidth = cellCount * itemWidth;
                childBounds.Width = childWidth;
                childBounds.X += child.Offset * itemWidth;
                if (totalCellCount > ColLayout.ColMaxCelCount)
                {
                    childBounds.X = -gutterHalf;
                    childBounds.Y = _maxChildDesiredHeight;
                    totalCellCount = cellCount;
                }

                child.Arrange(childBounds);
                childBounds.X += childWidth;
            }

            return finalSize;
        }
    }
}
