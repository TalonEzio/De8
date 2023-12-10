using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    internal class Program
    {
        static int port = 10000;
        static IPAddress serverIpAddress = IPAddress.Parse("127.0.0.1");
        static bool stop = false;
        static void Main(string[] args)
        {
            Console.Title = "Client";

            var thread = new Thread(Input);

            thread.Start();
            while(true)
            {
                if (stop)
                {
                    break;
                }
            }
            Console.WriteLine("Bam phim bat ki de ket thuc chuong trinh");
            Console.ReadLine();
            
        }
        static void Input()
        {
           while(true)
            {
                Console.Write("Ky tu: ");
                var key = Console.ReadKey();

                Console.WriteLine();
                SendToServer(key.KeyChar);
                
                if (key.Key == ConsoleKey.Escape)
                {
                    stop = true;
                    return;
                }

                //Console.WriteLine($"\nKy tu vua nhap: {key.KeyChar}");

            }
        }

        private static void SendToServer(char keyChar)
        {
            var client = new UdpClient();
            
            client.Connect(serverIpAddress, port);

            var sendByte = Encoding.ASCII.GetBytes(keyChar.ToString());

            client.Send(sendByte,sendByte.Length);

            Console.WriteLine("Gui du lieu thanh cong");
        }
    }
}
