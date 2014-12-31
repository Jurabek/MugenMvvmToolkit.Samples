﻿using MugenMvvmToolkit;
using Xamarin.Forms;

namespace Binding.Views
{
    public partial class AttachedMemberView : ContentPage
    {
        #region Constructors

        public AttachedMemberView()
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