﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Tulsi.ViewModels;
using Tulsi.NavigationFramework;

namespace Tulsi {
    public partial class GrowerProfilePage : ContentPage, IView {

        private readonly GrowerProfileViewModel _viewModel;

        public GrowerProfilePage() {
            InitializeComponent();

            BindingContext = _viewModel = new GrowerProfileViewModel();

            TapGestureRecognizer CloseTap = new TapGestureRecognizer();
            CloseTap.Tapped += (s, e) => {
                Application.Current.MainPage.Navigation.PopAsync();
            };
            Close.GestureRecognizers.Add(CloseTap);
        }

        private void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
            menuItems.SelectedItem = null;
        }
    }
}
