using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FlightSimulator.Model;
using FlightSimulator.Views;

namespace FlightSimulator.ViewModels
{
    class AutoPilotVM
    {
        private ICommand _clearComand;

        public ICommand ClearCommand
        {
            get
            {
                return _clearComand ?? (_clearComand =
                new CommandHandler(() => OnClick()));
            }
            set
            {

            }
        }
        private void OnClick()
        {
            AutoPilot autoPilot = new AutoPilot();
            //if (!string.IsNullOrEmpty(autoPilot.txtAutoPilot.Text))
                autoPilot.txtAutoPilot.Clear();
            //else
            //    Console.WriteLine("renaananaaaa");
        }
    }
}

