﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FlightSimulator.Model;
using FlightSimulator.Views;

namespace FlightSimulator.ViewModels
{
    class SettingVM
    {
        private ICommand _settingsComand;
        private ICommand _connectComand;


        public ICommand SettingsCommand
        {
            get
            {
                return _settingsComand ?? (_settingsComand =
                new CommandHandler(() => OnClick()));
            }
            set
            {

            }
        }
        private void OnClick()
        {
            SettingPopup setting = new SettingPopup();
            setting.ShowDialog();
        }


        public ICommand ConnectCommand
        {
            get
            {
                return _connectComand ?? (_connectComand =
                new CommandHandler(() => OnClickConnect()));
            }
            set
            {

            }
        }
        private void OnClickConnect()
        {
            CommandsChannel commandsChannel = new CommandsChannel();
        }
    }

}

    
   

