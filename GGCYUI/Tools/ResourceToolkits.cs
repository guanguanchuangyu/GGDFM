using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace GGCYUI.Tools
{
    /// <summary>
    /// Geometry辅助类
    /// </summary>
    public class ResourceToolkits
    {
        /// <summary>
        /// 通过key获取到资源字典的对应数据类型数据
        /// </summary>
        /// <param name="url">资源字典路径</param>
        /// <param name="key">资源对应的Key</param>
        /// <returns></returns>
        public static T GetGeometry<T>(string url,string key) where T:class
        {
            if (string.IsNullOrEmpty(url)|| string.IsNullOrEmpty(key))
            {
                return default(T);
            }
            Uri uri = new Uri(url,UriKind.Relative);
            //if (!File.Exists(uri.LocalPath))
            //{
            //    throw new FileNotFoundException($"当前文件:{url}不存在");
            //}
            //获取资源字典
            ResourceDictionary dictionary = new ResourceDictionary();
            dictionary.Source = uri;
            if (!dictionary.Contains(key))
            {
                return default(T);
            }
            var result = dictionary[key] as T;
            return result;
        }
    }
}
