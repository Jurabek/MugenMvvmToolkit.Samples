﻿using MugenMvvmToolkit;
using Xamarin.Forms;

namespace Navigation.Views
{
    public partial class BackStackView : ContentPage
    {
        #region Constructors

        public BackStackView()
        {
            InitializeComponent();
        }

        #endregion

        #region Overrides of Page

        protected override bool OnBackButtonPressed()
        {
            return this.HandleBackButtonPressed();
        }

        #endregion
    }
}