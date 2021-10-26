using System;
using System.Windows.Forms;
using GoldMobileGameBot.FormManagers;
using LightInject;
namespace GoldMobileGameBot
{
    public partial class BaseForm : Form
    {
        IMainManager _mainManager;
        public BaseForm()
        {
            _mainManager = ServiceContainerBase.serviceContainer.GetInstance<IMainManager>();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            _mainManager.CheckRunVirtualMachine(lblBlueStackRun);
        

        }
    }
}
