using System;
using System.Windows.Controls;

namespace Scenarios.Storyboard.ViewModels
{
    public abstract class NavigablePageViewModel: PropertyChangedNotifier
    {
        public event EventHandler<Type> NavigationEvent;
        
        protected void NavigateTo<TPage>() where TPage : Page
        {
            NavigationEvent?.Invoke(this, typeof(TPage));
        }
    }
}
