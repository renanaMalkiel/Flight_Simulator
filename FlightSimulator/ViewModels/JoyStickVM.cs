using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model.Interface;
using FlightSimulator.Model;

namespace FlightSimulator.ViewModels
{
    class JoyStickVM
    {
        private string rudderSet = "set controls/flight/rudder";
        private string throttleSet = "set controls/engines/current-engine/throttle";

        public float Rudder
        {
            set
            {
                string msg = rudderSet + " " + value + " " + "\r\n";
                CommandsChannel.Instance.send(msg);
            }
        }

        public float Throttle
        {
            set
            {
                string msg = throttleSet + " " + value + " " + "\r\n";
                CommandsChannel.Instance.send(msg);
            }
        }


    }
}
