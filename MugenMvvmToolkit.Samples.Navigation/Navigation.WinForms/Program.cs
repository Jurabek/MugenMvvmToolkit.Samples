using System;
using System.Windows.Forms;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Infrastructure;
using Navigation.Portable.ViewModels;

namespace Navigation.WinForms
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var bootstrapper = new Bootstrapper<MainViewModel>(new AutofacContainer());
            bootstrapper.Start();
        }
    }
}