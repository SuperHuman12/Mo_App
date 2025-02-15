﻿using SlideOverKit;
using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using Tulsi.Helpers;
using Tulsi.NavigationFramework;
using Tulsi.SharedService;
using Tulsi.ViewModels;
using Xamarin.Forms;

namespace Tulsi {
    public partial class DashboardPage : MenuContainerPage, IView {

        private readonly DashboardPageViewModel _viewModel;

        /// <summary>
        ///     ctor().
        /// </summary>
        public DashboardPage() {

            InitializeComponent();

            SlideMenu = new SideMenuView();

            BindingContext = _viewModel = new DashboardPageViewModel();

            SfChart chart = new SfChart();
            DoughnutSeries doughnutSeries = new DoughnutSeries() {
                ItemsSource = _viewModel.ChartData,
                XBindingPath = "Name",
                YBindingPath = "Value",
                DoughnutCoefficient = 0.7,
                ExplodeIndex = 0,
            };
            List<Color> colors = new List<Color>()
            {
                Color.FromHex("#82DA69"),
                Color.FromHex("#E47132"),
                Color.FromHex("#9EE5FC"),
            };

            doughnutSeries.ColorModel.Palette = ChartColorPalette.Custom;
            doughnutSeries.ColorModel.CustomBrushes = colors;
            chart.WidthRequest = 180;
            chart.HeightRequest = 180;
            chart.Series.Add(doughnutSeries);

            chart.Title.TextColor = Color.FromHex("#cccccc");
            chart.HorizontalOptions = LayoutOptions.Center;
            chart.VerticalOptions = LayoutOptions.Center;
            chart.BackgroundColor = Color.Transparent;
            ChartGrid.Children.Add(chart);

            StackLayout MiddleStack = new StackLayout() {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Transparent
            };
            Label MiddleText1 = new Label() {
                Text = "23%",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold
            };
            Label MiddleText2 = new Label() {
                Text = "mobile",
                FontSize = 10,
                FontAttributes = FontAttributes.Bold
            };

            MiddleStack.Children.Add(MiddleText1);
            MiddleStack.Children.Add(MiddleText2);
            ChartGrid.Children.Add(MiddleStack);
        }

        private void ShowMenuCommand(object sender, EventArgs e) {
            ShowMenu();
        }

        private void TranslateViewTapped(object sender, EventArgs e) {
            int displayHeight = DependencyService.Get<IDisplaySize>().GetHeight();
            welcome.TranslateTo(0, -displayHeight, 700);

            SetPlatformPadding();

            Device.StartTimer(TimeSpan.FromSeconds(2), () => {

                tempLabel.IsVisible = false;

                return false;
            });
        }

        private void SetPlatformPadding() {
            switch (Device.RuntimePlatform) {
                case Device.iOS:
                    this.Padding = new Thickness(0, 20, 0, 0);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Make some visual changes of current page through navigating process (hide side menu or smt...)
        /// </summary>
        public void ApplyVisualChangesWhileNavigating() {
            SlideMenu.HideWithoutAnimations();
        }

        /// <summary>
        ///     Occurs only for Android (not for iOS).
        ///     False navigate out from page, true - staying in this page.
        /// </summary>
        /// <returns></returns>
        protected override bool OnBackButtonPressed() {
            Dispose();
            return false;
        }

        public void Dispose() {
            _viewModel.Dispose();
            ((IView)(SlideMenu)).Dispose();
        }
    }
}
