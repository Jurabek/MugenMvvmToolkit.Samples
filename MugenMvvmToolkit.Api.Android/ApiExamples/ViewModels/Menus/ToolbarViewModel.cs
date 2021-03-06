using MugenMvvmToolkit.Interfaces.Presenters;

namespace ApiExamples.ViewModels.Menus
{
    public class ToolbarViewModel : MenuViewModel
    {
        #region Constructors

        public ToolbarViewModel(IToastPresenter toastPresenter)
            : base(toastPresenter)
        {
        }

        #endregion

        #region Properties

        public string TopToolbarTitle
        {
            get { return "Top Toolbar"; }
        }

        public string BottomToolbarTitle
        {
            get { return "Bottom Toolbar"; }
        }

        #endregion
    }
}