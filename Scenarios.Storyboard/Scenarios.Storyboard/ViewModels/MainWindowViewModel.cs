using Scenarios.Storyboard.Pages;
using System;

namespace Scenarios.Storyboard.ViewModels
{
    public class MainWindowViewModel: PropertyChangedNotifier
    {
        private IPageFactory _pageFactory;

        private NavigablePage _selectedPage;

        public MainWindowViewModel(IPageFactory pageFactory)
        {
            _pageFactory = pageFactory ?? 
                throw new ArgumentNullException(nameof(pageFactory));

            _selectedPage = pageFactory.CreateFrontPage();
        }

        public NavigablePage SelectedPage
        {
            get => _selectedPage;

            set
            {
                if (_selectedPage != null)
                {
                    _selectedPage.ViewModel.NavigationEvent -= Page_NavigationEvent;
                }

                _selectedPage = value;
                OnPropertyChanged();

                if (_selectedPage != null)
                {
                    _selectedPage.ViewModel.NavigationEvent += Page_NavigationEvent;
                }
            }
        }

        private void Page_NavigationEvent(object sender, Type targetType)
        {
            switch (targetType.Name)
            {
                case "FrontPage":
                    SelectedPage = _pageFactory.CreateFrontPage();
                    break;
                case "LoadStoryboardPage":
                    SelectedPage = _pageFactory.CreateLoadStoryboardPage();
                    break;
                case "StoryboardEditorPage":
                    SelectedPage = _pageFactory.CreateStoryboardEditorPage();
                    break;
                case "SettingsPage":
                    SelectedPage = _pageFactory.CreateSettingsPage();
                    break;
                default:
                    break;
            }
        }
    }
}
