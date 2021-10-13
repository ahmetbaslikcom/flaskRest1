using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using Newtonsoft.Json;
using System.Net.Http;
using System.IO.Ports;

namespace WindowsFormsApp20
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort1.PortName = "COM3"; // seri haberleşme portu için com3 seçimi
            serialPort1.BaudRate = 9600; // seri haberleşme hızı seçimi
            serialPort1.Open(); // haberleşmeyi aç
            button2.Enabled = false;
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.Write("1"); // 1 bilgisi gönder
            telegram(textBox1.Text, "LED Yandı"); // telegrama mesaj gönder
            label1.Text = "LED Yandı";
            button1.Enabled = false;
            button2.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Write("0"); // 1 bilgisi gönder
            telegram(textBox1.Text, "LED Söndü"); // telegrama mesaj gönder
            label1.Text = "LED Söndü";
            button1.Enabled = true;
            button2.Enabled = false;
        }
        
        void telegram(string nick, string message)
        {
            var client = new RestClient("http://127.0.0.1:5000/telegram?nick="+nick+"&bot_message="+message);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
    }
}
