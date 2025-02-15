﻿using Xamarin.Forms;

namespace Tulsi.Controls.PrimitiveSegmentControl {
    public partial class FramedLabelSegmentItem : PrimitiveSegmentItemBase {

        /// <summary>
        ///     ctor().
        /// </summary>
        public FramedLabelSegmentItem() {
            InitializeComponent();

            BaseViewForTap = baseView_Frame;
        }

        public override string Label {
            get => outputText_Label.Text;
            set => outputText_Label.Text = value;
        }

        public override void Deselect() {
            baseView_Frame.BackgroundColor = Color.White;
            outputText_Label.TextColor = Color.FromHex("#AAAAAA");
        }

        public override void Select() {
            baseView_Frame.BackgroundColor = Color.FromHex("#2793F5");
            outputText_Label.TextColor = Color.White;
        }
    }
}
