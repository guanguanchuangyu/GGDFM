using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GGCYUI.Controls
{
    public class ControlElement
    {
        #region AttachTemplate-#附加特定控件模板
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
        #region 附加特定命令
        public static readonly DependencyProperty AttachComandProperty =
    DependencyProperty.RegisterAttached("AttachComand", typeof(ICommand), typeof(ControlElement), new PropertyMetadata(default(ICommand)));

        public static ICommand GetAttachComand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(AttachComandProperty);
        }

        public static void SetAttachComand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(AttachComandProperty, value);
        }



        #endregion
    }
}
