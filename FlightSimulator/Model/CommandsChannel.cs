using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Threading;
using FlightSimulator.Model.Interface;

namespace FlightSimulator.Model
{
    class CommandsChannel
    {
        private static CommandsChannel m_Instance = null;
        private Mutex _mutex;
        TcpClient _client;
        bool _isConnected;

        
        public static CommandsChannel Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new CommandsChannel();
                }
                return m_Instance;
            }
        }
        

        private CommandsChannel()
        {
           _mutex = new Mutex();
           _isConnected = false;
        }

        //connecting to the flightgear as a client
        public void ConnectClient()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ApplicationSettingsModel.Instance.FlightServerIP),
            ApplicationSettingsModel.Instance.FlightCommandPort);
            _client = new TcpClient();
            _client.Connect(ep);
            Console.WriteLine("Command channel :You are connected");
            _isConnected = true;
            
        }

        // gets all the info from the user and splits into commands and sends to flightgear
        public void send(string text)
        {
            string[] chunks = parseText(text);
            _mutex.WaitOne();
            Thread thread = new Thread(() => sendThroughSocket(chunks,_client));
            thread.Start();
            _mutex.ReleaseMutex();
        }

        // sending the commands to the plane in a seprate thread
        public void sendThroughSocket(string[] chunks, TcpClient _client)
        {
            if (!_isConnected) return;
            NetworkStream ns = _client.GetStream();
            //sending command to plane every 2 secconds 
            foreach (string chunk in chunks)
            { 
                // Send data to server
                string command = chunk;
                command += "\r\n";
                byte[] buffWriter = Encoding.ASCII.GetBytes(command);
                ns.Write(buffWriter, 0, buffWriter.Length);
                System.Threading.Thread.Sleep(2000);
            }
                
        }

        // splitting the text to commands by \n
        public string[] parseText(string txt)
        {
            string[] chunks;
            chunks = txt.Split('\n');
            return chunks;
        }
    }

    
}