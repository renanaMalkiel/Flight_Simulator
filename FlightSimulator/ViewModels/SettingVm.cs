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
    class SettingVM
    {
        private ICommand _settingComand;
        public ICommand SettingCommand
        {
            get
            {
                return _settingComand ?? (_settingComand =
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
    }
}
