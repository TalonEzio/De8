using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Threading;
namespace Server
{
    internal class Program
    {
        static int port = 10000;
        static IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        static bool stop = false;
        static void Main(string[] args)
        {
            Console.Title = "Server";

            var thread = new Thread(Output);
            thread.Start();
            Console.WriteLine("Server san sang!");
            while (true)
            {
                if (stop)
                {
                    break;
                }
            }
            Console.WriteLine("Bam phim bat ki de ket thuc chuong trinh");
            Console.ReadLine();
        }
        static void Output()
        {
            var server = new UdpClient(new IPEndPoint(ipAddress, port));
            while (true)
            {
                var dummy = new IPEndPoint(0, 0);

                var buffer = server.Receive(ref dummy);
                Console.WriteLine($"Nhan duoc du lieu tu {dummy}");
                char key = (char)buffer[0];
                if (key == (char)ConsoleKey.Escape)
                {
                    stop = true;
                    return;
                }
                Console.WriteLine($"Ky tu vua nhap: {key}");



            }
        }
    }
}
