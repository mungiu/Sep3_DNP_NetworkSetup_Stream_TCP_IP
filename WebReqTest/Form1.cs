using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace WebReqTest
{
   public partial class Form1 : Form
   {
      public Form1()
      {
         InitializeComponent();
      }

      private void button1_Click(object sender, EventArgs e)
      {
         WebRequest rq = WebRequest.Create("http://www.insero.com");
         WebResponse rsp = rq.GetResponse();

         // Read the lines of the HTML page
         StreamReader r = new StreamReader(rsp.GetResponseStream());
         for (string line = r.ReadLine(); line != null; line = r.ReadLine())
            Console.WriteLine(line);

      }

      private void button2_Click(object sender, EventArgs e)
      {
          WebRequest rq = WebRequest.Create("http://www.insero.com");
         WebResponse rsp = rq.GetResponse();

         // Read the lines of the HTML page
         this.webBrowser1.Url = rsp.ResponseUri;
      }
   }
}
