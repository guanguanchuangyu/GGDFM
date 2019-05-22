using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GGCYUI.Controls.Converters
{
    /// <summary>
    /// 根据Name转化为Object对象实例
    /// 并缓存到当前域中
    /// </summary>
    public class NameToObjectConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }
            //获取当前可执行文件所在程序集
            Assembly assembly = Assembly.GetEntryAssembly();
            string typeName = value as string;
            
            //根据名称从当前域中获取实例
            var instance = AppDomain.CurrentDomain.GetData(typeName);
            //判定实例是否存在
            if (instance == null)
            {
                //根据类的完整名称进行实例化
                instance = assembly.CreateInstance(typeName);
                if (instance != null)//存在实例则保存到域中
                {
                    AppDomain.CurrentDomain.SetData(typeName, instance);
                }
            }
            return instance;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
