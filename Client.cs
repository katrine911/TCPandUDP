using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    class Client
    {
        static void Main(string[] args)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp); 
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("7.31.197.143"), 1255); 
            while (true) {
                string filePath = Console.ReadLine();
                byte[] bytes = Encoding.UTF8.GetBytes(filePath);
                socket.SendTo(bytes, serverEndPoint);
                byte[] buffer = new byte[1024];
                int received = socket.Receive(buffer);
                Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, received) + "\n");
            }
            socket.Close();
        }
    }
}
