using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using System.Net.Sockets;
using System.Data.SqlClient;
using System.Net.Mail;

namespace WindowsFormsApplication5
{
    public partial class Form5 : Form
    {
        //чат
        private bool done = true;
        private UdpClient client;
        private IPAddress groupAddress;
        private int localPort;
        private int remotePort;
        private int ttl;

        private IPEndPoint remoteEP;
        private UnicodeEncoding encoding = new UnicodeEncoding();
        public string name;
        private string message;
        public Form5(string loginchat)
        {
            name=loginchat;
            InitializeComponent();
            try
            {
                //Считываем конфигурационный файл приложения 
                NameValueCollection configuration = System.Configuration.ConfigurationSettings.AppSettings;
                groupAddress = IPAddress.Parse(configuration["groupAddress"]);
                localPort = int.Parse(configuration["LocalPort"]);
                remotePort = int.Parse(configuration["RemotePort"]);
                ttl = int.Parse(configuration["TTL"]);
            }
            catch
            {
                MessageBox.Show(this, "Ошибка в конфигурационном файле!", "Ошибка",
MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                // Присоединяемся к группе рассылки 
                client = new UdpClient(localPort);
                client.JoinMulticastGroup(groupAddress, ttl);

                remoteEP = new IPEndPoint(groupAddress, remotePort);
                Thread receiver = new Thread(new ThreadStart(Listener));
                receiver.IsBackground = true;
                receiver.Start();

                byte[] data = encoding.GetBytes("Пользователь " + name + " присоединился к чату");
                client.Send(data, data.Length, remoteEP);
                buttonSend.Enabled = true;
            }

            catch (SocketException ex)
            {
                MessageBox.Show(this, ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void Listener()
        {
            done = false;
            try
            {
                while (!done)
                {
                    IPEndPoint ep = null;
                    byte[] buffer = client.Receive(ref ep);
                    message = encoding.GetString(buffer);

                    this.Invoke(new MethodInvoker(DisplayReceivedMessage));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Ошибка!", MessageBoxButtons.OK,
MessageBoxIcon.Error);
            }
        }

        private void DisplayReceivedMessage()
        {
            string time = DateTime.Now.ToString("t");
            textMessages.Text = time + " " + message + "\r\n" + textMessages.Text;
            //statusBar.Text = "Последнее сообщение " + time; 
        }
        private void StopListener()
        {
            //Отправляем группе сообщение о выходе 
            byte[] data = encoding.GetBytes(name + " покинул чат");
            client.Send(data, data.Length, remoteEP);

            //Покидаем группу 
            client.DropMulticastGroup(groupAddress);
            client.Close();
            //Останавливаем поток, получающий сообщения 
            done = true;
            buttonSend.Enabled = false;
        }
        private void button11_Click(object sender, EventArgs e)
        {
            StopListener();
            Close();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            try
            {
                //Отправляем сообщение группе 
                byte[] data = encoding.GetBytes(name + " ["+remoteEP+"] " + ": " + textMessage.Text);
                client.Send(data, data.Length, remoteEP);
                textMessage.Clear();
                textMessage.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Ошибка!", MessageBoxButtons.OK,
MessageBoxIcon.Error);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textMessages.Clear();
        }
    }
}
