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
      
        public AutoPilotVM()
        {
            text = "";
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
        }

        // when clicking on clear, will clear the text box and notify
        private void ClearClick()
        {
            text = "";
            NotifyPropertyChanged("Text");
        }

        // if the text is full will be pink
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

        // when clicking ok send commands to the plane and clear the textbox
        private void OKClick()
        {
            CommandsChannel.Instance.send(text);
            text = "";
            NotifyPropertyChanged("Text");
        }
    }

    
}
