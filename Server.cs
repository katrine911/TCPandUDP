using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
namespace server
{
    class Server
    {
        static void Main(string[] args)
        {
            UdpClient socket = new UdpClient(1255);
            IPEndPoint senderEndPoint = null;
            Console.WriteLine("Сервер запущен");
            while (true) {
                byte[] buffer = socket.Receive(ref senderEndPoint);
                string filePath = Encoding.UTF8.GetString(buffer);
                Console.WriteLine("Запрошена информация о файле " + filePath);
                FileInfo file = new FileInfo(filePath);
               
                string response = file.Exists ? file.FullName + ":\nДата создания: " + file.CreationTime + "\nРазмер: " + file.Length + " байт": "Файл не найден";
                byte[] bytes = Encoding.UTF8.GetBytes(response);
                socket.Send(bytes, bytes.Length, senderEndPoint);
            }
            Console.ReadKey();
        }
    }
}
