using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using FlightSimulator.Model;
using FlightSimulator.Model.Interface;

namespace FlightSimulator.ViewModels
{
    class AutoPilotVM : BaseNotify
    {
        private string text;
        private ICommand _clearCommand;
        private ICommand _OKCommand;
        private IClientModel commandChannel;

        public AutoPilotVM()
        {
            text = "";
            commandChannel = CommandsChannel.Instance;
        }

        public string Text
        {
            get
            {
                // change color if needed
                NotifyPropertyChanged("ChangeColor");
                return text;
            }
            set
            {
                text = value;
            }
        }

        public ICommand ClearCommand
        {
            get
            {
                return _clearCommand ?? (_clearCommand =
                new CommandHandler(() => ClearClick()));
            }
            set
            {

            }
        }

        private void ClearClick()
        {
            text = "";
            NotifyPropertyChanged("Text");
        }

        public string ChangeColor
        {
            get { return (text == "") ? "White" : "Pink"; }
        }


        public ICommand OKCommand
        {
            get
            {
                return _OKCommand ?? (_OKCommand =
                new CommandHandler(() => OKClick()));
            }
        }

        private void OKClick()
        {
            commandChannel.send(text);
            text = "";
            NotifyPropertyChanged("Text");
        }
    }

    
}
