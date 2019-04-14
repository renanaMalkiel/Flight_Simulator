﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace FlightSimulator.Model
{
    class CommandsChannel
    {
        private TcpClient _client;

        public CommandsChannel()
        {
            ConnectClient();
        }
        //private ApplicationSettingsModel settingsModel;
        public void ConnectClient()
        {        
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ApplicationSettingsModel.Instance.FlightServerIP),
            ApplicationSettingsModel.Instance.FlightCommandPort);
            _client = new TcpClient();
            _client.Connect(ep);
            Console.WriteLine("You are connected");
        }

        static void send(TcpClient _client)
        {
            NetworkStream ns = _client.GetStream();
            using (NetworkStream stream = _client.GetStream())
            using (StreamReader reader = new StreamReader(stream))
            using (StreamWriter writer = new StreamWriter(stream))
            {

                while (true)
                {
                    // Send data to server
                    Console.Write("Please enter a number: ");
                    string num = Console.ReadLine();
                    num += "\r\n";
                    writer.Write(num);
                    writer.Flush();
                    // Get result from server
                    string result = reader.ReadLine();
                    Console.WriteLine("Result = {0}", result);
                }

            }
            _client.Close();
        } 
    }
}