using System.Windows;
using System.Windows.Controls;

namespace GGCYUI.Controls
{
    /// <summary>
    /// 简单的内容组容器
    /// </summary>
    public class SampleGroup : ItemsControl
    {
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new ContentControl();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is ContentControl;
        }

        #region Orientation
        public static readonly DependencyProperty OrientationProperty =
    DependencyProperty.Register("Orientation", typeof(Orientation), typeof(SampleGroup), new PropertyMetadata(default(Orientation)));
        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }
        #endregion
        #region ItemStyleSelector
        public static readonly DependencyProperty ItemStyleSelectorProperty =
    DependencyProperty.Register("ItemStyleSelector", typeof(StyleSelector), typeof(SampleGroup), new PropertyMetadata(default(StyleSelector)));
        public StyleSelector ItemStyleSelector
        {
            get { return (StyleSelector)GetValue(ItemStyleSelectorProperty); }
            set { SetValue(ItemStyleSelectorProperty, value); }
        }
        #endregion

        protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
        {
            base.OnVisualChildrenChanged(visualAdded, visualRemoved);

            var count = Items.Count;
            for (int i = 0; i < count; i++)
            {
                var item = (ContentControl)Items[i];
                item.Style = ItemStyleSelector?.SelectStyle(item, this);
            }
        }

    }
}
