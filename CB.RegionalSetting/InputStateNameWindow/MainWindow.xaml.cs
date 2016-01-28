using System.Windows;
using System.Windows.Input;


namespace InputStateNameWindow
{
    public partial class MainWindow
    {
        #region  Constructors & Destructor
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion


        #region Dependency Properties
        public static readonly DependencyProperty StateNameProperty = DependencyProperty.Register(
            nameof(StateName), typeof(string), typeof(MainWindow), new PropertyMetadata(default(string)));

        public string StateName
        {
            get { return (string)GetValue(StateNameProperty); }
            set { SetValue(StateNameProperty, value); }
        }
        #endregion


        #region Override
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            base.OnPreviewKeyDown(e);
            if (e.Key == Key.Escape) CloseCancel();
        }
        #endregion


        #region Event Handlers
        private void CmdCancel_OnClick(object sender, RoutedEventArgs e)
        {
            CloseCancel();
        }

        private void CmdOk_OnClick(object sender, RoutedEventArgs e)
        {
            CloseOk();
        }
        #endregion


        #region Implementation
        private void CloseCancel()
        {
            DialogResult = false;
            Close();
        }

        private void CloseOk()
        {
            DialogResult = true;
            Close();
        }
        #endregion
    }
}