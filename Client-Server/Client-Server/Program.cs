using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Client_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = Dns.GetHostEntry("localhost").AddressList[0];
            TcpListener server = new TcpListener(ip,8080);
            TcpClient client = default(TcpClient);


            try
            {
                server.Start();
                Console.WriteLine("Server started...");
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:"+ex.ToString());
                Console.Read();
            }

            while (true)
            {
                client = server.AcceptTcpClient();

                byte[] recivedBuffer = new byte[100];
                NetworkStream stream = client.GetStream();

                stream.Read(recivedBuffer, 0 ,recivedBuffer.Length);

                string msg = Encoding.ASCII.GetString(recivedBuffer, 0, recivedBuffer.Length);

                Console.WriteLine(msg);
                Console.Read();
            }
        }
    }
}
