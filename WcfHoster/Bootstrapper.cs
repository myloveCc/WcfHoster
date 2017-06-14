using Microsoft.Practices.Unity;
using Prism.Unity;
using WcfHoster.Views;
using System.Windows;

namespace WcfHoster
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }
    }
}
