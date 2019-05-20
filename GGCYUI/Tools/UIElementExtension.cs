using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GGCYUI.Tools
{
    /// <summary>
    /// UIElementExtension
    /// </summary>
    public static class UIElementExtension
    {
        /// <summary>
        /// Show
        /// </summary>
        /// <param name="uIElement"></param>
        public static void Show(this UIElement uIElement)
        {
            uIElement.Visibility = Visibility.Visible;
        }
        /// <summary>
        ///     显示元素
        /// </summary>
        /// <param name="element"></param>
        /// <param name="show"></param>
        public static void Show(this UIElement element, bool show)
        {
            element.Visibility = show ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
