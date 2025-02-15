﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tulsi.Helpers;
using Tulsi.Model.DataContainers;
using Tulsi.Model.DataContainers.DataItems;
using Tulsi.MVVM.Core;
using Tulsi.NavigationFramework;
using Xamarin.Forms;

namespace Tulsi.ViewModels {
    public class ReportsViewModel : ViewModelBase, IViewModel {

        private readonly ReportsMenuContainer _menuContainer;

        List<ReportsMenuItem> _menuItems;
        public List<ReportsMenuItem> MenuItems {
            get { return _menuItems; }
            set { SetProperty(ref _menuItems, value); }
        }

        ReportsMenuItem _selectedMenuItem;
        public ReportsMenuItem SelectedMenuItem {
            get { return _selectedMenuItem; }
            set {
                if (SetProperty(ref _selectedMenuItem, value) && value != null) {

                    //
                    // TODO: add possibility to interact with action bar of each page so we don't need 
                    // to use Intermediate page and we can remove all content duplicates of some pages.
                    //
                    if (value.ViewType == ViewType.AddReportAccessPage) {
                        BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(value.ViewType);
                    }
                    else {
                        BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.ReportsIntermediatePage);
                        BaseSingleton<NavigationObserver>.Instance.OnNavigatedContent(value.Name, value.ViewType);
                    }

                    SelectedMenuItem = null;
                }
            }
        }

        public ICommand DisplaySearchPageCommand { get; private set; }

        public ReportsViewModel() {
            _menuContainer = new ReportsMenuContainer();

            MenuItems = _menuContainer.BuildReportsMenuItems();

            DisplaySearchPageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage));
        }

        public void Dispose() {
            MenuItems.Clear();
        }
    }
}
