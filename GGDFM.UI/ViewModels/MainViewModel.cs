using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGDFM.UI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            InitialData();
        }
        /// <summary>
        /// 初始化页面数据
        /// </summary>
        private void InitialData()
        {
            Menu = GetMenuData();
        }
        /// <summary>
        /// 获取菜单数据
        /// </summary>
        /// <returns></returns>
        private MenuViewModel GetMenuData()
        {
            return new MenuViewModel();
        }

        private MenuViewModel menu;
        /// <summary>
        /// 菜单视图
        /// </summary>
        public MenuViewModel Menu
        {
            get
            {
                if (menu == null)
                {
                    menu = new MenuViewModel();
                }
                return menu;
            }
            set
            {
                menu = value;
                RaisePropertyChanged();
            }
        }
    }
}
