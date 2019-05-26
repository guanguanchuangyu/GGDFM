using GGCYUI.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace GGCYUI.Tools
{
    /// <summary>
    /// 栅格化布局
    /// </summary>
    public class ColLayout : MarkupExtension
    {
        /// <summary>
        /// 列的最大列数量
        /// </summary>
        public static readonly int ColMaxCelCount = 24;
        /// <summary>
        /// 栅格化行为：水平排列，开始堆叠在一起
        /// 手机、平板
        /// 阀值最大宽度768px
        /// </summary>
        public static readonly int XsMaxWidth = 768;
        /// <summary>
        /// 当大于这些阀值时将变为水平排列
        /// 桌面显示器
        /// 阀值最大宽度992px
        /// </summary>
        public static readonly int SmMaxWidth = 992;
        /// <summary>
        /// 当大于这些阀值时将变为水平排列
        /// 阀值最大宽度1200px
        /// </summary>
        public static readonly int MdMaxWidth = 1200;
        /// <summary>
        /// 当大于这些阀值时将变为水平排列
        /// 阀值最大宽度1920px
        /// </summary>
        public static readonly int LgMaxWidth = 1920;
        /// <summary>
        /// 当大于这些阀值时将变为水平排列
        /// 阀值最大宽度2560px
        /// </summary>
        public static readonly int XlMaxWidth = 2560;
        #region 列数属性
        /// <summary>
        /// 超小列数-24
        /// </summary>
        public int Xs { get; set; } = 24;
        /// <summary>
        /// 小列数-12
        /// </summary>
        public int Sm { get; set; } = 12;
        /// <summary>
        /// 中等列数-8
        /// </summary>
        public int Md { get; set; } = 8;
        /// <summary>
        /// 大列数-6
        /// </summary>
        public int Lg { get; set; } = 6;
        /// <summary>
        /// 超大列数-4
        /// </summary>
        public int Xl { get; set; } = 4;
        /// <summary>
        /// 加大列数-2
        /// </summary>
        public int Xxl { get; set; } = 2;
        #endregion
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new ColLayout
            {
                Xs = Xs,
                Sm = Sm,
                Md = Md,
                Xl = Xl,
                Xxl = Xxl
            };
        }
        public static ColLayoutStatus GetLayoutStatus(double width)
        {
            if (width < MdMaxWidth)
            {
                if (width < SmMaxWidth)
                {
                    if (width < XsMaxWidth)
                    {
                        return ColLayoutStatus.Xs;
                    }
                    return ColLayoutStatus.Sm;
                }
                return ColLayoutStatus.Md;
            }
            if (width < XlMaxWidth)
            {
                if (width < LgMaxWidth)
                {
                    return ColLayoutStatus.Lg;
                }
                return ColLayoutStatus.Xl;
            }
            return ColLayoutStatus.Xxl;
        }
    }
}
