using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SimpleClient
{
    class SimpleClient
    {
        private TcpClient tcpClient;
        private NetworkStream stream;
        private StreamWriter writer;
        private StreamReader reader;

        public SimpleClient()
        {
               tcpClient = new TcpClient();   
        }

        public bool Connect(string ipAddress, int port)
        {
            try
            {
                tcpClient.Connect(IPAddress.Parse(ipAddress), port);
                stream = tcpClient.GetStream();
                reader = new StreamReader(stream, Encoding.UTF8);
                writer = new StreamWriter(stream, Encoding.UTF8);
            }
            catch
            {
                Console.WriteLine("Exception: ");
                return false;
            }
            return true;
        }

        public void Run()
        {
            string userInput;

            Thread thread = new Thread(ProcessServerResponce);
            thread.Start();

            while ((userInput = Console.ReadLine()) != null)
            {
                writer.WriteLine(userInput); // < -- stoped here
                writer.Flush();

                if (userInput == "Shut Down")
                {
                    Console.WriteLine("Client shutting down");
                    break;
                }
                if (reader.Peek() != -1)
                {
                    Console.WriteLine("Server says: " + reader.ReadLine());
                }
            }
            tcpClient.Close();
            Console.ReadLine();
        }

        void ProcessServerResponce()
        {
            string testTemp;
            while (true)
            {
                testTemp = reader.ReadLine();
                Console.WriteLine("Server says: " + testTemp);
                if (testTemp == "Shut Down")
                {
                    break;
                }
            }

        }
    }
}
