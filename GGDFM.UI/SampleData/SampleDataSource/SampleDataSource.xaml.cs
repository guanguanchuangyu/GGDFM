//   *********  请勿修改此文件   *********
//   此文件由设计工具再生成。更改
//   此文件可能会导致错误。
namespace Expression.Blend.SampleData.SampleDataSource
{
    using System; 
    using System.ComponentModel;

// 若要在生产应用程序中显著减小示例数据涉及面，则可以设置
// DISABLE_SAMPLE_DATA 条件编译常量并在运行时禁用示例数据。
#if DISABLE_SAMPLE_DATA
    internal class SampleDataSource { }
#else

    public class SampleDataSource : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public SampleDataSource()
        {
            try
            {
                Uri resourceUri = new Uri("/GGDFM.UI;component/SampleData/SampleDataSource/SampleDataSource.xaml", UriKind.RelativeOrAbsolute);
                System.Windows.Application.LoadComponent(this, resourceUri);
            }
            catch
            {
            }
        }

        private Menu_DataSource _Menu_DataSource = new Menu_DataSource();

        public Menu_DataSource Menu_DataSource
        {
            get
            {
                return this._Menu_DataSource;
            }
        }
    }

    public class Menu_DataSource : System.Collections.ObjectModel.ObservableCollection<Menu_DataSourceItem>
    { 
    }

    public class Menu_DataSourceItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string _MenuItemIcon = string.Empty;

        public string MenuItemIcon
        {
            get
            {
                return this._MenuItemIcon;
            }

            set
            {
                if (this._MenuItemIcon != value)
                {
                    this._MenuItemIcon = value;
                    this.OnPropertyChanged("MenuItemIcon");
                }
            }
        }

        private string _MenuItemName = string.Empty;

        public string MenuItemName
        {
            get
            {
                return this._MenuItemName;
            }

            set
            {
                if (this._MenuItemName != value)
                {
                    this._MenuItemName = value;
                    this.OnPropertyChanged("MenuItemName");
                }
            }
        }

        private string _Content = string.Empty;

        public string Content
        {
            get
            {
                return this._Content;
            }

            set
            {
                if (this._Content != value)
                {
                    this._Content = value;
                    this.OnPropertyChanged("Content");
                }
            }
        }
    }
#endif
}
