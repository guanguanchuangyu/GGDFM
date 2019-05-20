using GGCYUI.Datas;
using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shell;
using System.Windows.Input;
using GGCYUI.Tools;

namespace GGCYUI.Controls
{
    /// <summary>
    /// 自定义Window
    /// 模仿至HandyControl和DMSkin
    /// </summary>
    [TemplatePart(Name = ElementNoClientArea, Type = typeof(UIElement))]
    public class FWindow : Window
    {
        /// <summary>
        /// 预定部件的名称
        /// </summary>
        private const string ElementNoClientArea = "PART_NonClientArea";
        #region 私有变量
        private UIElement _NoClientArea;
        private Thickness _ActualBorderThinckness;
        private bool _ShowNoClientArea = true;
        private bool _IsFullScreen;
        private WindowStyle _TemplateWindowStyle;
        private ResizeMode _TempResizeMode;
        private WindowState _TemplateWindowState;
        private double _TemplateNoClientAreaHeight;
        #endregion
        #region 构造函数
        public FWindow()
        {
            #region 设定Windows的非客户端区域高度的Binding操作
            var chrome = new WindowChrome
            {
                CornerRadius = new CornerRadius(),
                GlassFrameThickness = new Thickness(1, 0, 0, 0)
            };
            BindingOperations.SetBinding(chrome, WindowChrome.CaptionHeightProperty, new Binding(NoClientAreaHeightProperty.Name) { Source = this });
            WindowChrome.SetWindowChrome(this, chrome);
            #endregion
            Loaded += (s, e) => OnLoaded(e);
        }
        #endregion
        #region 特有依赖属性
        #region NoClientAreaContent-#无内容客户区域内容
        /// <summary>
        /// 无内容客户区域内容
        /// </summary>
        public object NoClientAreaContent
        {
            get { return (object)GetValue(NoClientAreaContentProperty); }
            set { SetValue(NoClientAreaContentProperty, value); }
        }
        public static readonly DependencyProperty NoClientAreaContentProperty =
            DependencyProperty.Register("NoClientAreaContent", typeof(object), typeof(FWindow), new PropertyMetadata(default(object)));
        #endregion
        #region NoClientAreaForeground-#无内容客户区域前背景色
        /// <summary>
        /// 无内容客户区域前背景色
        /// </summary>
        public Brush NoClientAreaForeground
        {
            get { return (Brush)GetValue(NoClientAreaForegroundProperty); }
            set { SetValue(NoClientAreaForegroundProperty, value); }
        }
        public static readonly DependencyProperty NoClientAreaForegroundProperty =
            DependencyProperty.Register("NoClientAreaForeground", typeof(Brush), typeof(FWindow), new PropertyMetadata(default(Brush)));
        #endregion
        #region NoClientAreaBackground-#无内容客户区域后背景色
        /// <summary>
        /// 无内容客户区域前背景色
        /// </summary>
        public Brush NoClientAreaBackground
        {
            get { return (Brush)GetValue(NoClientAreaBackgroundProperty); }
            set { SetValue(NoClientAreaBackgroundProperty, value); }
        }
        public static readonly DependencyProperty NoClientAreaBackgroundProperty =
            DependencyProperty.Register("NoClientAreaBackground", typeof(Brush), typeof(FWindow), new PropertyMetadata(default(Brush)));
        #endregion
        #region NoClientAreaHeight-#无内容客户区域高度
        /// <summary>
        /// 无内容客户区域高度
        /// </summary>
        public double NoClientAreaHeight
        {
            get { return (double)GetValue(NoClientAreaHeightProperty); }
            set { SetValue(NoClientAreaHeightProperty, value); }
        }
        public static readonly DependencyProperty NoClientAreaHeightProperty =
            DependencyProperty.Register("NoClientAreaHeight", typeof(double), typeof(FWindow), new PropertyMetadata(28.0));
        #endregion
        #region ShowNoClientArea-#是否显示无内容区域
        /// <summary>
        /// 是否显示无内容区域
        /// </summary>
        public bool ShowNoClientArea
        {
            get { return (bool)GetValue(ShowNoClientAreaProperty); }
            set { SetValue(ShowNoClientAreaProperty, value); }
        }
        public static readonly DependencyProperty ShowNoClientAreaProperty =
            DependencyProperty.Register("ShowNoClientArea", typeof(bool), typeof(FWindow), new PropertyMetadata(ValueBoxes.TrueBox,OnShowNoClientAreaChanged));

        private static void OnShowNoClientAreaChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (FWindow)d;
            obj.SwitchShowNoClientArea((bool)e.NewValue);
        }
        #endregion
        #region IsFullScreen-#是否全屏显示
        /// <summary>
        /// 是否全屏显示
        /// </summary>
        public bool IsFullScreen
        {
            get { return (bool)GetValue(IsFullScreenProperty); }
            set { SetValue(IsFullScreenProperty, value); }
        }
        public static readonly DependencyProperty IsFullScreenProperty =
            DependencyProperty.Register("IsFullScreen", typeof(bool), typeof(FWindow), new PropertyMetadata(ValueBoxes.FalseBox,OnIsFullScreenChanged));

        private static void OnIsFullScreenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (FWindow)d;
            obj.SwitchIsFullScreen((bool)e.NewValue);
        }
        #endregion
        #region ShowTitle-#是否显示标题名
        public bool ShowTitle
        {
            get { return (bool)GetValue(ShowTitleProperty); }
            set { SetValue(ShowTitleProperty, value); }
        }

        public static readonly DependencyProperty ShowTitleProperty =
            DependencyProperty.Register("ShowTitle", typeof(bool), typeof(FWindow), new PropertyMetadata(ValueBoxes.TrueBox));
        #endregion

        #endregion
        #region 私有函数
        /// <summary>
        /// 窗体Loaded触发的事件
        /// </summary>
        /// <param name="args"></param>
        protected void OnLoaded(RoutedEventArgs args)
        {
            //获取边距
            _ActualBorderThinckness = BorderThickness;
            //当窗体状态为最大化时，设定当前Windows为无边框
            if (WindowState == WindowState.Maximized)
            {
                //此处是否有优化的地方-dq
                BorderThickness = new Thickness();
            }
            #region 构建添加Window命令绑定
            CommandBindings.Add(new CommandBinding(SystemCommands.MinimizeWindowCommand,
                 (s, e) => WindowState = WindowState.Minimized));
            CommandBindings.Add(new CommandBinding(SystemCommands.MaximizeWindowCommand,
                (s, e) => WindowState = WindowState.Maximized));
            CommandBindings.Add(new CommandBinding(SystemCommands.RestoreWindowCommand,
                (s, e) => WindowState = WindowState.Normal));
            CommandBindings.Add(new CommandBinding(SystemCommands.CloseWindowCommand, (s, e) => Close()));
            CommandBindings.Add(new CommandBinding(SystemCommands.ShowSystemMenuCommand, ShowSystemMenu));
            #endregion
            #region 设定模板的相关参数
            _TemplateNoClientAreaHeight = NoClientAreaHeight;
            _TemplateWindowState = WindowState;
            _TemplateWindowStyle = WindowStyle;
            _TempResizeMode = ResizeMode;
            #endregion
            SwitchIsFullScreen(_IsFullScreen);
            SwitchShowNoClientArea(_ShowNoClientArea);
            if (SizeToContent != SizeToContent.WidthAndHeight)
            {
                return;
            }
            SizeToContent = SizeToContent.Height;
            //通知UI变更属性设定
            Dispatcher.BeginInvoke(new Action(() => { SizeToContent = SizeToContent.WidthAndHeight; }));
        }
        /// <summary>
        /// 控制是否显示无客户区域回调函数
        /// </summary>
        /// <param name="showNoClientArea"></param>
        private void SwitchShowNoClientArea(bool showNoClientArea)
        {
            if (_NoClientArea == null)
            {
                _ShowNoClientArea = ShowNoClientArea;
                return;
            }
            if (ShowNoClientArea)
            {
                if (IsFullScreen)
                {
                    _NoClientArea.Show(false);
                    _TemplateNoClientAreaHeight = NoClientAreaHeight;
                    NoClientAreaHeight = 0;
                }
                else
                {
                    _NoClientArea.Show(true);
                    NoClientAreaHeight = _TemplateNoClientAreaHeight;
                }
            }
            else
            {
                _NoClientArea.Show(false);
                _TemplateNoClientAreaHeight = NoClientAreaHeight;
                NoClientAreaHeight = 0;
            }
        }

        /// <summary>
        /// 显示系统菜单
        /// </summary>
        /// <param name="sender">事件对象</param>
        /// <param name="e">事件参数</param>
        private void ShowSystemMenu(object sender, ExecutedRoutedEventArgs e)
        {
            //判定当前窗体是否最大化决定系统菜单显示的位置
            var point = WindowState == WindowState.Maximized ? new Point(0, NoClientAreaHeight) : new Point(Left, Top + NoClientAreaHeight);
            //设定系统菜单的位置
            SystemCommands.ShowSystemMenu(this, point);
        }

        /// <summary>
        /// 控制是否全屏显示的回调函数
        /// </summary>
        /// <param name="newValue">新的值</param>
        private void SwitchIsFullScreen(bool IsFullScreen)
        {
            if (_NoClientArea == null)
            {
                _IsFullScreen = IsFullScreen;
                return;
            }
            if (IsFullScreen)
            {
                _NoClientArea.Show(false);
                _TemplateNoClientAreaHeight = NoClientAreaHeight;
                NoClientAreaHeight = 0;
                _TemplateWindowState = WindowState;
                _TemplateWindowStyle = WindowStyle;
                _TempResizeMode = ResizeMode;
                WindowStyle = WindowStyle.None;
                #region 问题项
                //Handy作者提示不能更改-故意的
                WindowState = WindowState.Maximized;
                WindowState = WindowState.Minimized;
                WindowState = WindowState.Maximized;
                #endregion
            }
            else
            {
                //是否显示无用户区域
                if (ShowNoClientArea)
                {
                    _NoClientArea.Show(true);
                    NoClientAreaHeight = _TemplateNoClientAreaHeight;
                }
                else
                {
                    _NoClientArea.Show(false);
                    _TemplateNoClientAreaHeight = NoClientAreaHeight;
                    NoClientAreaHeight = 0;
                }

                WindowState = _TemplateWindowState;
                WindowStyle = _TemplateWindowStyle;
                ResizeMode = _TempResizeMode;
            }
        }
        #endregion
        #region 重写函数
        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            if (SizeToContent == SizeToContent.WidthAndHeight)
            {
                InvalidateMeasure();
            }
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _NoClientArea = GetTemplateChild(ElementNoClientArea) as UIElement;
            if (_NoClientArea != null)
            {
                _NoClientArea.MouseLeftButtonDown += _NoClientArea_MouseLeftButtonDown;
            }
        }

        private void _NoClientArea_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (_NoClientArea != null)
            {
                _NoClientArea.MouseLeftButtonDown -= _NoClientArea_MouseLeftButtonDown;
            }
        }
        #endregion
    }
}
