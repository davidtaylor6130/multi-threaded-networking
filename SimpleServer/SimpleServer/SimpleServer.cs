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

                if (receivedMessage == "Shut Down")
                {
                    break;
                }

            }
            socket.Close();
        }

        void GetReturnMessage(string input)
        {
            switch (input)
            {
                case "1":
                    ServerLog("1 Has Been Pressed");
                    break;
                case "2":
                    ServerLog("2 Has Been Pressed");
                    break;
                case "3":
                    ServerLog("3 Has Been Pressed");
                    break;
                case "4":
                    ServerLog("4 Has Been Pressed");
                    break;
                case "5":
                    ServerLog("5 Has Been Pressed");
                    break;
                case "6":
                    ServerLog("6 Has Been Pressed");
                    break;
                case "7":
                    ServerLog("7 Has Been Pressed");
                    break;
                case "8":
                    ServerLog("8 Has Been Pressed");
                    break;
                case "9":
                    ServerLog("9 Has Been Pressed");
                    break;

                    // <-------------------------------------COMMANDS SECTION----------------------------------->

                case "Shut Down":
                    ServerLog("Server Is Shutting itself down Now");
                    break;

                case "Clear ServerLog":
                    Console.Clear();
                    ServerLog("Logs have been cleared");
                    break;

                default :
                    ServerLog("Error With Transmittion / Exixuting command");
                        break;

            }
        }




        void ServerLog(string input)
        {
            Console.WriteLine("Message: " + input + " Message Sent At: " + DateTime.Now.ToString("h:mm:ss tt"));
            writer.WriteLine(input);
            writer.Flush();
        }


    }
}
