using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using Client;

namespace SimpleClient
{
    public class SimpleClient
    {

        //-------------------------------------------------------------------------------------------------//
        //----------------------------------Desclration of public Verables---------------------------------//
        //-------------------------------------------------------------------------------------------------//

        public bool ShutDown = false;
        public int clientLocation = 11;
        private TcpClient tcpClient;
        private NetworkStream stream;
        private StreamWriter writer;
        private StreamReader reader;
        private Thread thread;
        private ClientForm messageForm;

        //-------------------------------------------------------------------------------------------------//
        //------------------Simple Client creates a new tcpClient for the client to use---------------------//
        //-------------------------------------------------------------------------------------------------//

        public SimpleClient()
        {
            tcpClient = new TcpClient();
            messageForm = new ClientForm(this);
        }

        //-------------------------------------------------------------------------------------------------//
        //---Connect passes in the idAdress and port of the server and trys to connect with UTF8 Encoding--//
        //------------if not possible to connect for any reasion it will output an error message-----------// 
        //-------------------------------------------------------------------------------------------------//

        public bool Connect(string ipAddress, int port)
        {
            try
            {
                tcpClient.Connect(IPAddress.Parse(ipAddress), port);
                stream = tcpClient.GetStream();
                reader = new StreamReader(stream, Encoding.UTF8);
                writer = new StreamWriter(stream, Encoding.UTF8);

                Application.Run(messageForm);
            }
            catch
            {
                Console.WriteLine("Cannot connect to:" + ipAddress + ":" + port + "sucsessfully");
                return false;
            }
            return true;
        }

        //-------------------------------------------------------------------------------------------------//
        //---Run Handels the Actual Loop of the client it sends the users input to the server and checks---//
        //-----------If the client runs the command Shut Down this exits the infinate while loop-----------//
        //-An Extra Thread is utalized to Prosees the servers random responses (like from public messages)-//
        //-------------------------------------------------------------------------------------------------//

        public void Run()
        {
            thread = new Thread(ProcessServerResponce);
            thread.Start();
        }

        public void Stop()
        {
            thread.Abort();
            tcpClient.Close();
        }

        public void InputName(string input)
        {
            input = "name " + input;
            writer.WriteLine(input);
            writer.Flush();
        }

        public void SendMessage(string input)
        {
            writer.WriteLine(input);
            writer.Flush();
        }

        //-------------------------------------------------------------------------------------------------//
        //----ProsessServerResponce Handels the unexspected output from the server like public messages----// 
        //-------------------------------------------------------------------------------------------------//

        void ProcessServerResponce()
        {
            string testTemp;
            while (ShutDown == false)
            {
                testTemp = reader.ReadLine();
                messageForm.UpdateChatWindow(testTemp);
            }
        }
    }
}
