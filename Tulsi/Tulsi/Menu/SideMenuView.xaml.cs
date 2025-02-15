﻿using SlideOverKit;
using System;
using Tulsi.NavigationFramework;
using Tulsi.SharedService;
using Tulsi.ViewModels.Menu;
using Xamarin.Forms;

namespace Tulsi {
    public partial class SideMenuView : SlideMenuView, IView {

        private readonly SideMenuViewModel _viewModel;

        /// <summary>
        ///     ctor().
        /// </summary>
        public SideMenuView() {
            InitializeComponent();

            int wd = DependencyService.Get<IDisplaySize>().GetWidthDiP();
            WidthRequest = wd * 0.65;

            MenuOrientations = MenuOrientation.LeftToRight;

            IsFullScreen = true;
            AnimationDurationMillisecond = 250;

            BackgroundViewColor = GetPlatformColor();
            BackgroundColor = Color.FromHex("#ffffff");

            BindingContext = _viewModel = new SideMenuViewModel();
        }

        private void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
            menuItems.SelectedItem = null;
        }

        private void CloseCommand(object sender, EventArgs e) {
            this.HideWithoutAnimations();
        }

        private Color GetPlatformColor() {
            switch (Device.RuntimePlatform) {
                case Device.iOS:
                    return Color.FromHex("#33000000");
                case Device.Android:
                    return Color.FromHex("#33000000");
                default:
                    return Color.Accent;
            }
        }

        /// <summary>
        /// Make some visual changes of current page through navigating process (hide side menu or smt...)
        /// </summary>
        public void ApplyVisualChangesWhileNavigating() {

        }

        public void Dispose() {
            _viewModel.Dispose();
        }
    }
}