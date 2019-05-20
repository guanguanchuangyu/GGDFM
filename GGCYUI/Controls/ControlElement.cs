using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GGCYUI.Controls
{
    public class ControlElement
    {
        #region AttachTemplate-#附件特定控件模板
        public static ControlTemplate AttachTemplate(DependencyObject obj)
        {
            return (ControlTemplate)obj.GetValue(AttachTemplateProperty);
        }

        public static void SetAttachTemplate(DependencyObject obj, ControlTemplate value)
        {
            obj.SetValue(AttachTemplateProperty, value);
        }

        public static readonly DependencyProperty AttachTemplateProperty =
            DependencyProperty.RegisterAttached("AttachTemplate", typeof(ControlTemplate), typeof(ControlElement), new PropertyMetadata(default(ControlTemplate))); 
        #endregion
    }
}
