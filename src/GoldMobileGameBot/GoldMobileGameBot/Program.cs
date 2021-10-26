using GM.Helpers;
using GoldMobileGameBot.FormManagers;
using LightInject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoldMobileGameBot
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = new ServiceContainer();
            ServiceContainerBase.serviceContainer = container;
            container.Register<IProcessHelper, ProcessHelper>();
            container.Register<IMainManager, MainManager>();
        

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BaseForm());
        }
    }
}
