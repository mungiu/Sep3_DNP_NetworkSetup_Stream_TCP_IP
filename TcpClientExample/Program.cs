using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace TcpClientExample
{
   class Program
   {
      static void Main(string[] args)
      {
         byte[] data = new byte[1024];
         string input, stringData;
         TcpClient client;

         try
         {
            client = new TcpClient("127.0.0.1", 12345 );
         }
         catch ( SocketException )
         {
            Console.WriteLine("Unable to connect to server");
            return;
         }

         NetworkStream ns = client.GetStream();

         Console.WriteLine("Connected to server");
         Console.WriteLine("Type a message to the server or exit to stop");
       
         while ( true )
         {
            input = Console.ReadLine();
            if (input == "exit")
               break;
            ns.Write(Encoding.ASCII.GetBytes(input), 0, input.Length);
            ns.Flush();

            data = new byte[1024];
            int recv = ns.Read(data, 0, data.Length);
            stringData = Encoding.ASCII.GetString(data, 0, recv);
            Console.WriteLine(stringData);
         }
         Console.WriteLine("Disconnecting from server...");
         ns.Close();
         client.Close();
       
      }
   }
}
