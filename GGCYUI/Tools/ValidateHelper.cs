using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGCYUI.Tools
{
    /// <summary>
    /// 校验辅助类
    /// </summary>
    public class ValidateHelper
    {
        /// <summary>
        ///     是否在正浮点数范围内
        /// </summary>
        /// <param name="value">当前值</param>
        /// <param name="includeZero">是否包含0.0</param>
        /// <returns></returns>
        public static bool IsInRangeOfPosDouble(object value, bool includeZero = false)
        {
            var v = (double)value;
            return !(double.IsNaN(v) || double.IsInfinity(v)) && (includeZero ? v >= 0 : v > 0);
        }
    }
}
