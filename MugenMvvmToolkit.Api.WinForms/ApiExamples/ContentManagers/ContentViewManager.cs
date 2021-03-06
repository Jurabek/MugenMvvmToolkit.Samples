﻿using System.Windows.Forms;
using MugenMvvmToolkit.Binding.Infrastructure;

namespace ApiExamples.ContentManagers
{
    public class ContentViewManager : ContentViewManagerBase<Control, Control>
    {
        #region Overrides of ContentViewManagerBase<Control,Control>

        protected override void SetContent(Control view, Control content)
        {
            if (content == null)
                view.Controls.Clear();
            else
            {
                view.Width = content.Width + 200;
                view.Height = content.Height + 200;
                view.Controls.Add(content);
                content.Left = (view.ClientSize.Width - content.Width)/2;
                content.Top = (view.ClientSize.Height - content.Height)/2;
                content.Anchor = AnchorStyles.None;
            }
        }

        #endregion
    }
}