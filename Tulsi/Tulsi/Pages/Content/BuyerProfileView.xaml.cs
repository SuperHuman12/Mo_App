﻿using Tulsi.NavigationFramework;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tulsi.Pages.Content {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuyerProfileView : ContentView, IView {
        
        /// <summary>
        ///     ctor().
        /// </summary>
        public BuyerProfileView() {
            InitializeComponent();
        }

        public void ApplyVisualChangesWhileNavigating() { }
    }
}