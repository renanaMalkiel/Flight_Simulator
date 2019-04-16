using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FlightSimulator.Model;
using FlightSimulator.Views;
using FlightSimulator.Model.Interface;
using System.Threading;

namespace FlightSimulator.ViewModels
{
    class Set_And_Connect_Vm
    {
        private ICommand _settingsComand;
        private ICommand _connectComand;
        private ICommand _disConnectComand;

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
        public ICommand DisConnectCommand
        {
            get
            {
                return _disConnectComand ?? (_disConnectComand =
                new CommandHandler(() => disConnectClick()));
            }
            set
            {

            }
        }
        //closes the info and command sockets
        private void disConnectClick()
        {
            InfoChannel.Instance.shouldStop = true;
            CommandsChannel.Instance.disConnect();
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
            if (!CommandsChannel.Instance.isConnected)
            {
                new Thread(() =>
                {
                    InfoChannel.Instance.connectServer();
                    CommandsChannel.Instance.ConnectClient();
                }).Start();

            }
            else
            {
                new Thread(() =>
                {
                    CommandsChannel.Instance.disConnect();
                    CommandsChannel.Instance.ConnectClient();
                }).Start();
            }

        }
    }

}
