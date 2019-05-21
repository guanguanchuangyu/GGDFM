using GalaSoft.MvvmLight;

namespace GGDFM.UI.ViewModels
{
    /// <summary>
    /// 菜单子项视图
    /// </summary>
    public class MenuItemViewModel : ViewModelBase
        {
            private string _MenuItemName;
            /// <summary>
            /// 菜单子项名称
            /// </summary>
            public string MenuItemName
            {
                get
                {
                    return _MenuItemName;
                }

                set
                {
                    this._MenuItemName = value;
                    RaisePropertyChanged(() => this.MenuItemName);
                }
            }
            /// <summary>
            /// 菜单对应内容
            /// </summary>
            public object Content
            {
                get
                {
                    return _Content;
                }

                set
                {
                    this._Content = value;
                    RaisePropertyChanged(() => this.Content);
                }
            }
            /// <summary>
            /// 菜单项图标
            /// </summary>
            public string MenuItemIcon
            {
                get
                {
                    return _MenuItemIcon;
                }

                set
                {
                    this._MenuItemIcon = value;
                    RaisePropertyChanged(() => this.MenuItemIcon);
                }
            }

            private object _Content;
            private string _MenuItemIcon;
        }
}
