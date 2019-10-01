using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Net;
using System.Net.Sockets;

namespace SimpleServer
{
    class SimpleServer
    {
        TcpListener tcpListener = null;
        public SimpleServer(string ipAddress, int port)
        {
            tcpListener = new TcpListener(IPAddress.Parse(ipAddress), port);

        }

        public void Start()
        {
            tcpListener.Start();
            Socket socket = tcpListener.AcceptSocket();

            Console.WriteLine("Connection Established");

            SocketMethod(socket);
        }

         public void Stop()
        {
            tcpListener.Stop();
        }

        void SocketMethod(Socket socket)
        {
            string receivedMessage;
            NetworkStream stream = new NetworkStream(socket);

            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);

            writer.WriteLine("Connection Made....");
            writer.Flush();

            while ((receivedMessage = reader.ReadLine()) != null)
            {
                string input = null;
                GetReturnMessage(input);
                if (input == "9")
                {
                    break;
                }
            }
            socket.Close();
        }

        void GetReturnMessage(string Code)
        {

        }

    }
}
