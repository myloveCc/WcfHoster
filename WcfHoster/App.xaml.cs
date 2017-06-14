using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WcfHoster
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public EventWaitHandle ProgramStarted { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {

            //只允许运行一个实例
            bool createNew;
            ProgramStarted = new EventWaitHandle(false, EventResetMode.AutoReset, "WcfHoster", out createNew);

            if (!createNew)
            {
                MessageBox.Show("The application is running");
                App.Current.Shutdown();
                Environment.Exit(0);
                return;
            }

            //设置模板色彩
            AppearanceManager.Current.AccentColor = Color.FromRgb(0xfa, 0x68, 0x00);

            base.OnStartup(e);
            var bootstrapper = new Bootstrapper();
            bootstrapper.Run();
        }
    }
}
