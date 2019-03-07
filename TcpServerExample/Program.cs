using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace TcpServerExample
{
   class Program
   {
      static void Main(string[] args)
      {
         int recv;
         byte[] data = new byte[1024];

         byte[] adr = { 127, 0, 0, 1 };
         IPAddress ipAdr = new IPAddress(adr);
         TcpListener newsock = new TcpListener( ipAdr, 12345 );
         newsock.Start();
         Console.WriteLine("Waiting for a client...");

         TcpClient client = newsock.AcceptTcpClient();
         NetworkStream ns = client.GetStream();

         string welcome = "Welcome to the DNPI1 test server";
         data = Encoding.ASCII.GetBytes(welcome);
         ns.Write(data, 0, data.Length);

         while (true)
         {
            data = new byte[1024];
            try
            {
               recv = ns.Read(data, 0, data.Length);
            }
            catch (IOException)
            {
               break;
            }

            if (recv == 0)
               break;

            Console.WriteLine( Encoding.ASCII.GetString(data, 0, recv) );

            byte[] response = new byte[1024];
            response = Encoding.ASCII.GetBytes( "Your last message to the server was:" );
            ns.Write(response, 0, response.Length);

            ns.Write( data, 0, recv );
         }
         ns.Close();
         client.Close();
         newsock.Stop();
      }
   }
}
