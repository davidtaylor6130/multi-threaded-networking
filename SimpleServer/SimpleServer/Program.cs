using System;

namespace SimpleServer
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip = "127.0.0.1";
            int port = 4444;

            SimpleServer server = new SimpleServer(ip, port);

            server.Start();
            server.Stop();
        }
    }
}
