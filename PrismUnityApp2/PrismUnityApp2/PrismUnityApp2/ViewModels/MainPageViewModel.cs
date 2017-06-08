using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismUnityApp2.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainPageViewModel()
        {

        }

        public DelegateCommand Btn1Command { get; private set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            Btn1Command = new DelegateCommand(登入);
        }

        private async void 登入()
        {
            var fooPara = new NavigationParameters();
            fooPara.Add("模式", "新增");
            //fooPara.Add("TravelExpense", new TravelExpense
            //{
            //    Account = AppData.Account,
            //    Category = "",
            //    Domestic = true,
            //    Expense = 0,
            //    HasDocument = false,
            //    Location = "",
            //    Memo = "",
            //    Title = "",
            //    TravelDate = DateTime.Now
            //});
            await _navigationService.NavigateAsync("ListPage", fooPara);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }
    }
}
