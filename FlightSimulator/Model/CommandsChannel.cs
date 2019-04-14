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
    class CommandsChannel : IClientModel
    {
        private static IClientModel m_Instance = null;
        private TcpClient _client;

      
        #region Singleton
        
        public static IClientModel Instance
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
        #endregion

        private CommandsChannel()
        {
            ConnectClient();
        }

        public void ConnectClient()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ApplicationSettingsModel.Instance.FlightServerIP),
            ApplicationSettingsModel.Instance.FlightCommandPort);
            _client = new TcpClient();
            _client.Connect(ep);
            Console.WriteLine("Command channel :You are connected");
        }

        public void send(string text)
        {
            Thread thread = new Thread(() => sendThroughSocket(_client));
            thread.Start();
        }

        static void sendThroughSocket(TcpClient _client)
        {
            NetworkStream ns = _client.GetStream();
            using (NetworkStream stream = _client.GetStream())
            using (StreamReader reader = new StreamReader(stream))
            using (StreamWriter writer = new StreamWriter(stream))
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
           // _client.Close();
        }

        public List<string> parseText(string txt)
        {
            return new List<string>();
        }
    }

    
}