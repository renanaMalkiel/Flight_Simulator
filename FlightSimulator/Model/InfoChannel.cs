﻿using System;
using System.Threading;
using System.Text;

using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

namespace FlightSimulator.Model
{
    class InfoChannel
    {
        TcpClient _client;

        public InfoChannel()
        {
            connect();
            Thread thread = new Thread(() => listen(_client));
            thread.Start();
            
        }
        public void connect()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ApplicationSettingsModel.Instance.FlightServerIP), 
            ApplicationSettingsModel.Instance.FlightInfoPort);
            TcpListener listener = new TcpListener(ep);
            listener.Start();
            //Console.WriteLine("Waiting for client connections...");
            _client = listener.AcceptTcpClient();
            Console.WriteLine("Info channel: Client connected");

        }

        public static void listen(TcpClient _client)
        {
            Byte[] bytes;
            string[] splitMsg = new string[23];
            string lon, lat;
            NetworkStream ns = _client.GetStream();

            while (true)
            {
                if (_client.ReceiveBufferSize > 0)
                {
                    bytes = new byte[_client.ReceiveBufferSize];
                    ns.Read(bytes, 0, _client.ReceiveBufferSize);
                    string msg = Encoding.ASCII.GetString(bytes); //the message incoming
                    splitMsg = msg.Split(',');
                    lon = splitMsg[0];//TODO
                    lat = splitMsg[1];
                    Console.WriteLine(msg);

                }
            }
        }
    }
}