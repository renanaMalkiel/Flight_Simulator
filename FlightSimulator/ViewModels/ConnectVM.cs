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
    class ConnectVM
    {
        private ICommand _connectComand;

        public ICommand ConnectCommand
        {
            get
            {
                return _connectComand ?? (_connectComand =
                new CommandHandler(() => OnClick()));
            }
            set
            {

            }
        }
        private void OnClick()
        {
            CommandsChannel commandsChannel = new CommandsChannel();
        }
    }

}

