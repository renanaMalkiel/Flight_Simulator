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
        private string AileronSet = "set controls/flight/aileron";
        private string ElevatorSet = "set controls/flight/elevator";

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
                //CommandsChannel.Instance.ConnectClient();
                CommandsChannel.Instance.send(msg);
            }
        }

        public double Elevator
        {
            set
            {
                string msg = ElevatorSet + " " + value + " " + "\r\n";
                //CommandsChannel.Instance.ConnectClient();
                CommandsChannel.Instance.send(msg);
                Console.WriteLine("jkdhjkfhdsjkf");
            }
        }

        public double Aileron
        {
            set
            {
                string msg = ElevatorSet + " " + value + " " + "\r\n";
                CommandsChannel.Instance.send(msg);
            }
        }
    }
}
