﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPTP3.Views.ViewModels
{
    public class UserCheckPageViewModel : ViewModelBase
    {
        private INavigationService navigationService;

        public UserCheckPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
    }
}
