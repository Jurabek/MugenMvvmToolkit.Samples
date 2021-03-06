using System;
using ApiExamples;
using ApiExamples.ViewModels;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Attributes;
using MugenMvvmToolkit.Infrastructure;
using MugenMvvmToolkit.Interfaces;

[assembly: Bootstrapper(typeof(Setup))]

namespace ApiExamples
{
    public class Setup : AndroidBootstrapperBase
    {
        #region Overrides of AndroidBootstrapperBase

        protected override IIocContainer CreateIocContainer()
        {
            return new AutofacContainer();
        }

        protected override Type GetMainViewModelType()
        {
            return typeof(MainViewModel);
        }

        #endregion
    }
}