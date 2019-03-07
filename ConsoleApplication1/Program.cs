using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace ConsoleApplication1
{
   class Program
   {
      static void Main(string[] args)
      {
         //byte[] adr = { 127, 0, 0, 1 };
         //IPAddress ipAdr = new IPAddress(adr);

         //System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient();
         //client.Connect(new IPEndPoint(ipAdr, 134));

         //System.Net.Sockets.NetworkStream networkStream = s.GetStream();

         //byte[] abyString = Encoding.ASCII.GetBytes("HEJ");
         //networkStream.Write(abyString, 0, 3);

         byte[] adr = { 127, 0, 0, 1 };
         IPAddress ipAdr = new IPAddress(adr);

         System.Net.Sockets.TcpListener listen = new System.Net.Sockets.TcpListener(ipAdr, 12345);
         listen.Start();
         System.Net.Sockets.TcpClient client = listen.AcceptTcpClient();
         System.Net.Sockets.NetworkStream networkStream = client.GetStream();

         while (true)
         {
            byte[] abyString;
            // networkStream.r
            // byte[] abyString = Encoding.ASCII.GetBytes("HEJ");
           // networkStream.Write(abyString, 0, 3);
         }
         Console.ReadKey();
      }
   }
}
