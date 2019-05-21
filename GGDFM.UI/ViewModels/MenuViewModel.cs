using GalaSoft.MvvmLight;
using System.Collections.Generic;

namespace GGDFM.UI.ViewModels
{
    public class MenuViewModel:ViewModelBase
    {
        private List<MenuItemViewModel> dataSource;

        public List<MenuItemViewModel> DataSource
        {
            get
            {
                if (dataSource == null)
                {
                    dataSource = new List<MenuItemViewModel>();
                }
                return dataSource;
            }
            set
            {
                dataSource = value;
                RaisePropertyChanged();
            }
        }
    }
}
