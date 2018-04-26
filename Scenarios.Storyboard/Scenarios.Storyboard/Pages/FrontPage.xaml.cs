using Scenarios.Storyboard.ViewModels;
using Scenarios.Storyboard.ViewModels.Pages;
using System;
using System.Windows.Controls;

namespace Scenarios.Storyboard.Pages
{
    /// <summary>
    /// Interaction logic for FrontPage.xaml
    /// </summary>
    public partial class FrontPage : NavigablePage
    {
        public FrontPage(FrontPageViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            DataContext = ViewModel;
        }
    }
}
