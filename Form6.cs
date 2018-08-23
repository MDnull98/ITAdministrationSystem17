using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using System.Net.Sockets;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Xml;

namespace WindowsFormsApplication5
{
    public partial class Form6 : Form
    {
        int port = 587; // порт smtp-сервера (в случае mail.ru это 587)
        bool enableSSL = true;
        string emailFrom = "xxxxxx @ mail.ru"; // адрес почты отправителя письма
        string password = "xxxxxx"; // пароль почты отправителя письма
        string emailTo = "xxxxxx @ xxxx.xx"; // адрес почты получателя письма
        string subject = "Привет."; // тема письма
        string body = "Привет. Это мое первое письмо!"; // текст письма
        string smtpAddress = "smtp.mail.ru"; // адрес smtp-сервера
        MailMessage mail = new MailMessage();
        public Form6()
        {
            InitializeComponent();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            textBox10.Visible = false;
            textBox9.Visible = false;
            label11.Visible = false;
            label15.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            button13.Visible = false;
            label12.Text += textBox10.Text+label11.Text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            body = textBox6.Text;
            emailFrom = textBox10.Text + label11.Text;
            password = textBox9.Text;
            emailTo = textBox7.Text;
            subject = textBox8.Text;
            mail.From = new MailAddress(emailFrom);
            mail.To.Add(emailTo);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true; 
            using (SmtpClient smtp = new SmtpClient(smtpAddress, port))
            {

                smtp.Credentials = new NetworkCredential(emailFrom, password);
                smtp.EnableSsl = enableSSL;
                try
                {
                    smtp.Send(mail); // отправка сообщения
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString()); // для вывода ошибки в консоль
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
