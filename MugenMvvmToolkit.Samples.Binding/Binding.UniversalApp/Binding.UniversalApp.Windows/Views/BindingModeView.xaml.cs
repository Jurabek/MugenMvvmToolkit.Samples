﻿using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Binding.UniversalApp.Views
{
    public sealed partial class BindingModeView : Page
    {
        #region Fields

        private readonly NavigationHelper _navigationHelper;

        #endregion

        #region Constructors

        public BindingModeView()
        {
            InitializeComponent();
            _navigationHelper = new NavigationHelper(this);
        }

        #endregion

        #region NavigationHelper registration

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedFrom(e);
        }

        #endregion
    }
}