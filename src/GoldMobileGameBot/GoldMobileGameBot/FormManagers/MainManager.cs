using GM.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoldMobileGameBot.FormManagers
{
    public class MainManager : IMainManager
    {
        IProcessHelper _processHelper;
        Timer virtualMachineTimer;
        public MainManager(IProcessHelper processHelper)
        {
            _processHelper = processHelper;
            virtualMachineTimer = new Timer();
            
        }
        public void CheckRunVirtualMachine(Label label)
        {
            var result = _processHelper.CheckRunProgramName("HD-Player");
            if (result == false)
            {
                virtualMachineTimer.Interval = 1000;
                virtualMachineTimer.Start();
                virtualMachineTimer.Tick += (object sender, EventArgs e)=> {

                    virtualMachineTimer.Stop();

                    var reCheck = _processHelper.CheckRunProgramName("HD-Player");
                    if (reCheck == false)
                    {
                        if (label.BackColor == System.Drawing.Color.Firebrick)
                        {
                            label.BackColor = System.Drawing.SystemColors.Control;
                            label.ForeColor = Color.Black;
                        }
                        else
                        {
                            label.BackColor = System.Drawing.Color.Firebrick;
                            label.ForeColor = Color.White;
                        }

                        label.Text = "BlueStack Not Run Click Run";
                        virtualMachineTimer.Start();
                    }
                    else
                    {
                        label.BackColor = System.Drawing.Color.Green;
                        label.ForeColor = Color.Black;
                        label.Text = "BlueStack Run";
                        virtualMachineTimer.Stop();
                    }
                  


                   
                };
            }
            else
            {
                label.BackColor = Color.Green;
                label.Text = "BlueStack Run OK";
            }
        }


    }
    public interface IMainManager
    {
        void CheckRunVirtualMachine(Label label);
    }
}
