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

namespace FlightSimulator.Model
{
    class CommandsChannel
    {
        //private ApplicationSettingsModel settingsModel;
        static void ExecuteClient()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ApplicationSettingsModel.Instance.FlightServerIP), 
                ApplicationSettingsModel.Instance.FlightCommandPort);
            TcpClient client = new TcpClient();
            client.Connect(ep);
            Console.WriteLine("You are connected");
            NetworkStream ns = client.GetStream();
            using (NetworkStream stream = client.GetStream())
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
            client.Close();

        }
    }
} 