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
        // the paths to the componants in the xml
        private string rudderSet = "set controls/flight/rudder";
        private string throttleSet = "set controls/engines/current-engine/throttle";
        private string AileronSet = "set controls/flight/aileron";
        private string ElevatorSet = "set controls/flight/elevator";

        /*/////$$$$$/////////$$$$$$$$$$$//////////////$$$$$$$$$$$$$$$$$$$/////////////
         * 
         * all of the properties below get the value from the view class and sends to the plane
         * through the commandchannel that was opened
         * 
         *//////$$$$$/////////$$$$$$$$$$$//////////////$$$$$$$$$$$$$$$$$$$/////////////

        public double Rudder
        {
            set
            {
                string msg = rudderSet + " " + value + " " + "\r\n";
                CommandsChannel.Instance.send(msg);
            }
        }

        public double Throttle
        {
            set
            {
                string msg = throttleSet + " " + value + " " + "\r\n";
                CommandsChannel.Instance.send(msg);
            }
        }

        public double Elevator
        {
            set
            {
                string msg = ElevatorSet + " " + value + " " + "\r\n";
                CommandsChannel.Instance.send(msg);
              
            }
        }

        public double Aileron
        {
            set
            {
                string msg = AileronSet + " " + value + " " + "\r\n";
                CommandsChannel.Instance.send(msg);
            }
        }
    }
}
