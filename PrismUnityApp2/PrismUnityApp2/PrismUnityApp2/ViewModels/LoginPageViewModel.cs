﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using PrismUnityApp2.Helper;
using PrismUnityApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismUnityApp2.ViewModels
{
    public class LoginPageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;
        public readonly IPageDialogService _dialogService;

        #region Account
        private string account;
        /// <summary>
        /// Account
        /// </summary>
        public string Account
        {
            get { return this.account; }
            set { this.SetProperty(ref this.account, value); }
        }
        #endregion


        #region Password
        private string password;
        /// <summary>
        /// Password
        /// </summary>
        public string Password
        {
            get { return this.password; }
            set { this.SetProperty(ref this.password, value); }
        }
        #endregion

        public DelegateCommand 登入Command { get; private set; }

        public LoginPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;

            登入Command = new DelegateCommand(登入);

        }

        private async void 登入()
        {
            //var result = await AppData.DataService.PostAsync(new AuthUser
            //{
            //    Account = Account,
            //    Password = Password,
            //}, AppData.ApiLogin);

            //if (result. == true)
            if (false)
            {
                //AppData.Account = Account;
                //var fooItems = (await AppData.DataService.GetTravelExpensesAsync(AppData.Account)).ToList();
                //AppData.AllTravelExpense = fooItems;
                //AppData.正在執行功能 = 執行功能列舉.差旅費用申請;
                await _navigationService.NavigateAsync("xf:///NaviPage/MainPage");
            }
            else
            {
                await _dialogService.DisplayAlertAsync("錯誤", "帳號或者密碼錯誤", "確定");
            }
        }
    }
}
