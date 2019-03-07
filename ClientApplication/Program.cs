using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace ClientApplication
{
   class Program
   {
      static void Main(string[] args)
      {
         Console.WriteLine("Press Esc to stop application ");
         Console.WriteLine("Press any other key to connect to server");

         while (true)
         {
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.Escape)
            {
               break;
            }
            else
            {
               // Make a new connection
               TcpClient client = new TcpClient("127.0.0.1", 12345);
               NetworkStream networkStream = client.GetStream();

               byte[] abyString = Encoding.ASCII.GetBytes("Hello from client");
               networkStream.Write(abyString, 0, abyString.GetLength(0) );



            }
         }
      }
   }
}
