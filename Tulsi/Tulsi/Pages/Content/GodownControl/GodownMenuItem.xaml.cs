﻿using Tulsi.Controls;
using Xamarin.Forms.Xaml;

namespace Tulsi.Pages.Content.GodownControl {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GodownMenuItem : StackListItemBase {
        public GodownMenuItem() {
            InitializeComponent();
        }

        public override void Deselected() {
           
        }

        public override void Selected() {
            
        }
    }
}