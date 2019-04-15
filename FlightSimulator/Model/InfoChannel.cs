using System;
using System.Threading;
using System.Text;

using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

namespace FlightSimulator.Model
{
    class InfoChannel
    {
        private static InfoChannel m_Instance = null;
        TcpClient _client;
        double lon, lat;

        public double Lon {
            set { lon = value; }
            get { return lon; }
        }

        public double Lat
        {
            set { lat = value; }
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

        private InfoChannel() { }
       
        public void connectServer()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ApplicationSettingsModel.Instance.FlightServerIP), 
            ApplicationSettingsModel.Instance.FlightInfoPort);
            TcpListener listener = new TcpListener(ep);
            listener.Start();
            Console.WriteLine("Waiting for client connections...");
            _client = listener.AcceptTcpClient();
            Console.WriteLine("Info channel: Client connected");

            Thread thread = new Thread(() => listen(_client));
            thread.Start();
        }

        public void listen(TcpClient _client)
        {
            Byte[] bytes;
            NetworkStream ns = _client.GetStream();

            while (true)
            {
                if (_client.ReceiveBufferSize > 0)
                {
                    bytes = new byte[_client.ReceiveBufferSize];
                    ns.Read(bytes, 0, _client.ReceiveBufferSize);
                    string msg = Encoding.ASCII.GetString(bytes); //the message incoming
                    splitMsg(msg);
                }
            }
        }

        // solit the info to lon and lat
        public void splitMsg(string msg)
        {
            string[] splitMs = msg.Split(',');
            lon = double.Parse(splitMs[0]);
            lat = double.Parse(splitMs[1]);
        }
    }
}