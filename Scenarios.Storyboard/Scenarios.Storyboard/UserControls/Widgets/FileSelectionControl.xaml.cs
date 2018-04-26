using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Scenarios.Storyboard.UserControls.Widgets
{
    /// <summary>
    /// Interaction logic for FileSelectionControl.xaml
    /// </summary>
    public partial class FileSelectionControl : UserControl
    {
        //protected readonly FileSelectionControlViewModel _viewModel;

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(FileSelectionControl));

        public static readonly DependencyProperty FilePathProperty =
            DependencyProperty.Register("FilePath", typeof(string), typeof(FileSelectionControl));

        //public static readonly DependencyProperty FilePathProperty =
        //    DependencyProperty.Register("FilePath", 
        //                                typeof(string),
        //                                typeof(FileSelectionControl),
        //                                new PropertyMetadata("", OnFilePathSet));

        public FileSelectionControl()
        {
            InitializeComponent();
            //_viewModel = (FileSelectionControlViewModel)DataContext;
        }

        //private static void OnFilePathSet(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    ((FileSelectionControl)d)._viewModel.FilePath = e.NewValue as string;
        //}

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);

            set => SetValue(CommandProperty, value);
        }

        public string FilePath
        {
            get => (string)GetValue(FilePathProperty);

            set => SetValue(FilePathProperty, value);
        }
    }
}
