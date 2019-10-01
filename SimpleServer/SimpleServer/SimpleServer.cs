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
        StreamReader reader;
        StreamWriter writer;
        NetworkStream stream;

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
            stream = new NetworkStream(socket);

            reader = new StreamReader(stream, Encoding.UTF8);
            writer = new StreamWriter(stream, Encoding.UTF8);

            writer.WriteLine("Connection Made....");
            writer.Flush();

            while ((receivedMessage = reader.ReadLine()) != null)
            {
                GetReturnMessage(receivedMessage);
                if (receivedMessage == "9")
                {
                    writer.WriteLine("Server shutting downs");
                    writer.Flush();
                    break;
                }

            }
            socket.Close();
        }

        void GetReturnMessage(string Code)
        {
            if (Code == "8")
            {
                writer.WriteLine("Good Bye .......");
                writer.Flush();
            }
        }

    }
}
