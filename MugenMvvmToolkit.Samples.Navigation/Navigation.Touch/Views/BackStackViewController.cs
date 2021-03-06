﻿using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Views;
using Navigation.Portable.ViewModels;

namespace Navigation.Touch.Views
{
    [Register("BackStackViewController")]
    public class BackStackViewController : MvvmViewController
    {
        #region Overrides of MvvmViewController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            using (var set = new BindingSet<BackStackViewModel>())
            {
                var label = new UILabel(new RectangleF(0, 70, View.Frame.Width, 30));
                set.BindFromExpression(label, "Text 'Back stack depth ' + Depth");
                View.AddSubview(label);

                UIButton button = UIButton.FromType(UIButtonType.System);
                button.Frame = new RectangleF(0, 100, View.Frame.Width, 30);
                button.SetTitle("Navigate to next view", UIControlState.Normal);
                set.Bind(button, "Click").To(model => model.NavigateCommand);
                View.AddSubview(button);


                button = UIButton.FromType(UIButtonType.System);
                button.Frame = new RectangleF(0, 130, View.Frame.Width, 30);
                button.SetTitle("Navigate to main view model (Clear back stack)", UIControlState.Normal);
                set.Bind(button, "Click").To(model => model.NavigateClearBackStackCommand);
                View.AddSubview(button);
            }
        }

        #endregion
    }
}