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
        private Mutex mutex;
        TcpClient _client;



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
        

        private CommandsChannel()
        {
           // Mutex m = new Mutex();
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
            string[] chunks = parseText(text);
         
            Thread thread = new Thread(() => sendThroughSocket(chunks,_client));
            thread.Start();
            
            
        }

        static void sendThroughSocket(string[] chunks, TcpClient _client)
        {
            NetworkStream ns = _client.GetStream();
            foreach (string chunk in chunks)
                {
               
                // Send data to server
                Console.Write("Please enter a number: ");
                    string command = chunk;
                    command += "\r\n";
                    byte[] buffWriter = Encoding.ASCII.GetBytes(command);
                    ns.Write(buffWriter, 0, buffWriter.Length);

                    // Get result from server
                    //string result = reader.ReadLine();
                    //Console.WriteLine("Result = {0}", result);
                }
                
            
           // _client.Close();
        }

        public string[] parseText(string txt)
        {
            string[] chunks;
            chunks = txt.Split(',');
            return chunks;
        }
    }

    
}