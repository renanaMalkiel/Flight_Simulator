using System;
using System.Threading;
using System.Text;

using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using FlightSimulator.ViewModels;

namespace FlightSimulator.Model
{
    class InfoChannel : BaseNotify
    {
        private static InfoChannel m_Instance = null;
        TcpClient _client;
        TcpListener _listener;
        double lon, lat;


        public bool shouldStop
        {
            set;
            get;
        }


        public double Lon
        {
            set
            {
                lon = value;
                NotifyPropertyChanged("Lon");

            }
            get { return lon; }
        }

        public double Lat
        {
            set
            {
                lat = value;
                NotifyPropertyChanged("Lat");
            }
            get { return lat; }
        }

        public static InfoChannel Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new InfoChannel();
                }
                return m_Instance;
            }
        }

        private InfoChannel()
        {

            shouldStop = false;
        }

        public void connectServer()
        {

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ApplicationSettingsModel.Instance.FlightServerIP),
        ApplicationSettingsModel.Instance.FlightInfoPort);
            _listener = new TcpListener(ep);
            _listener.Start();
            Console.WriteLine("Waiting for client connections...");
            _client = _listener.AcceptTcpClient();
            Console.WriteLine("Info channel: Client connected");


            Thread thread = new Thread(() => listen(_client, _listener));
            thread.Start();
        }

        public void listen(TcpClient _client, TcpListener _listener)
        {
            Byte[] bytes;
            NetworkStream ns = _client.GetStream();
            while (!shouldStop)
            {
                if (_client.ReceiveBufferSize > 0)
                {

                    bytes = new byte[_client.ReceiveBufferSize];
                    ns.Read(bytes, 0, _client.ReceiveBufferSize);
                    string msg = Encoding.ASCII.GetString(bytes); //the message incoming
                    splitMsg(msg);
                }
            }
            ns.Close();
            _client.Close();
            _listener.Stop();
        }

        // solit the info to lon and lat
        public void splitMsg(string msg)
        {
            string[] splitMs = msg.Split(',');
            if (msg.Contains(","))
            {
                Lon = double.Parse(splitMs[0]);
                Lat = double.Parse(splitMs[1]);
            }
            
        }
    }
}