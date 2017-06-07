using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrismUnityApp2.ViewModels
{
    public class LoadingPageViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;

        public LoadingPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            //var fooI = (await AppData.DataService.GetTravelExpensesCategoryAsync()).ToList();
            //AppData.AllTravelExpensesCategory = fooI;
            await Task.Delay(500);

            await _navigationService.NavigateAsync("xf:///LoginPage");
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }
}
