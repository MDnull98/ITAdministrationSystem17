using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;

namespace WindowsFormsApplication5
{
    public partial class Form2 : Form
    {
        public string fio11;
        Random rand = new Random();
        public Form2(string fio, string zapis, string proekt, string otdel, string worker, string users, string otchet, string clients)
        {
            InitializeComponent();
            string[] k = new string[4];
            k[0]= "https://news.tut.by/rss/index.rss";
            k[1] = "https://news.tut.by/rss/economics.rss";
            k[2] = "https://news.tut.by/rss/society.rss";
            k[3] = "https://news.tut.by/rss/world.rss";
            if (proekt == "False") { button5.Visible = false; }
            if (otdel == "False") { button4.Visible = false; }
            if (worker == "False") { button3.Visible = false; }
            if (users == "False") { button8.Visible = false;  }
            if (otchet == "False") { button9.Visible = false; }
            if (clients == "False") { button6.Visible = false; }
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(k[rand.Next(0,4)]);
            XmlElement xRoot = xDoc.DocumentElement;
            string s = xRoot["channel"]["item"]["title"].InnerText;
            textBox1.Text += s;
            label2.Text += (fio); label3.Text = zapis; fio11 = fio;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close(); label2.Text = "Здравствуйте, ";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form loading = new Form3();
            loading.Show();
            button8.BackColor = Color.YellowGreen;
            button3.BackColor = Color.Blue;
            button4.BackColor = Color.Blue;
            button5.BackColor = Color.Blue;
            button6.BackColor = Color.Blue;
            button7.BackColor = Color.Blue;
            button1.BackColor = Color.Blue;
            button9.BackColor = Color.Blue;
            button10.BackColor = Color.Blue;
            button11.BackColor = Color.Blue;
            button12.BackColor = Color.Blue;
            button13.BackColor = Color.Blue;
            button14.BackColor = Color.Blue;
        }// Новый пользователь

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form loading = new Form4(button7.Text,label3.Text);
            loading.Show();
            button7.BackColor = Color.YellowGreen;
            button3.BackColor = Color.Blue;
            button4.BackColor = Color.Blue;
            button5.BackColor = Color.Blue;
            button6.BackColor = Color.Blue;
            button1.BackColor = Color.Blue;
            button8.BackColor = Color.Blue;
            button9.BackColor = Color.Blue;
            button10.BackColor = Color.Blue;
            button11.BackColor = Color.Blue;
            button12.BackColor = Color.Blue;
            button13.BackColor = Color.Blue;
            button14.BackColor = Color.Blue;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form loading = new Form4(button6.Text, label3.Text);
            loading.Show();
            button6.BackColor = Color.YellowGreen;
            button3.BackColor = Color.Blue;
            button4.BackColor = Color.Blue;
            button5.BackColor = Color.Blue;
            button1.BackColor = Color.Blue;
            button7.BackColor = Color.Blue;
            button8.BackColor = Color.Blue;
            button9.BackColor = Color.Blue;
            button10.BackColor = Color.Blue;
            button11.BackColor = Color.Blue;
            button12.BackColor = Color.Blue;
            button13.BackColor = Color.Blue;
            button14.BackColor = Color.Blue;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form loading = new Form4(button4.Text, label3.Text);
            loading.Show();
            button4.BackColor = Color.YellowGreen;
            button3.BackColor = Color.Blue;
            button1.BackColor = Color.Blue;
            button5.BackColor = Color.Blue;
            button6.BackColor = Color.Blue;
            button7.BackColor = Color.Blue;
            button8.BackColor = Color.Blue;
            button9.BackColor = Color.Blue;
            button10.BackColor = Color.Blue;
            button11.BackColor = Color.Blue;
            button12.BackColor = Color.Blue;
            button13.BackColor = Color.Blue;
            button14.BackColor = Color.Blue;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form loading = new Form4(button9.Text, label3.Text);
            loading.Show();
            button9.BackColor = Color.YellowGreen;
            button3.BackColor = Color.Blue;
            button4.BackColor = Color.Blue;
            button5.BackColor = Color.Blue;
            button6.BackColor = Color.Blue;
            button7.BackColor = Color.Blue;
            button8.BackColor = Color.Blue;
            button1.BackColor = Color.Blue;
            button10.BackColor = Color.Blue;
            button11.BackColor = Color.Blue;
            button12.BackColor = Color.Blue;
            button13.BackColor = Color.Blue;
            button14.BackColor = Color.Blue;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form loading = new Form4(button5.Text, label3.Text);
            loading.Show();
            button5.BackColor = Color.YellowGreen;
            button3.BackColor = Color.Blue;
            button4.BackColor = Color.Blue;
            button1.BackColor = Color.Blue;
            button6.BackColor = Color.Blue;
            button7.BackColor = Color.Blue;
            button8.BackColor = Color.Blue;
            button9.BackColor = Color.Blue;
            button10.BackColor = Color.Blue;
            button11.BackColor = Color.Blue;
            button12.BackColor = Color.Blue;
            button13.BackColor = Color.Blue;
            button14.BackColor = Color.Blue;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form loading = new Form4(button3.Text, label3.Text);
            loading.Show();
            button3.BackColor = Color.YellowGreen;
            button1.BackColor = Color.Blue;
            button4.BackColor = Color.Blue;
            button5.BackColor = Color.Blue;
            button6.BackColor = Color.Blue;
            button7.BackColor = Color.Blue;
            button8.BackColor = Color.Blue;
            button9.BackColor = Color.Blue;
            button10.BackColor = Color.Blue;
            button11.BackColor = Color.Blue;
            button12.BackColor = Color.Blue;
            button13.BackColor = Color.Blue;
            button14.BackColor = Color.Blue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form loading = new Form4(button1.Text,fio11);
            loading.Show();
            button1.BackColor = Color.YellowGreen;
            button3.BackColor = Color.Blue;
            button4.BackColor = Color.Blue;
            button5.BackColor = Color.Blue;
            button6.BackColor = Color.Blue;
            button7.BackColor = Color.Blue;
            button8.BackColor = Color.Blue;
            button9.BackColor = Color.Blue;
            button10.BackColor = Color.Blue;
            button11.BackColor = Color.Blue;
            button12.BackColor = Color.Blue;
            button13.BackColor = Color.Blue;
            button14.BackColor = Color.Blue;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form loading = new Form5(label3.Text);
            loading.Show();
            button1.BackColor = Color.Blue;
            button3.BackColor = Color.Blue;
            button4.BackColor = Color.Blue;
            button5.BackColor = Color.Blue;
            button6.BackColor = Color.Blue;
            button7.BackColor = Color.Blue;
            button8.BackColor = Color.Blue;
            button9.BackColor = Color.Blue;
            button10.BackColor = Color.Blue;
            button11.BackColor = Color.YellowGreen;
            button12.BackColor = Color.Blue;
            button13.BackColor = Color.Blue;
            button14.BackColor = Color.Blue;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form6 loading = new Form6();
            loading.Show();
            button13.BackColor = Color.YellowGreen;
            button3.BackColor = Color.Blue;
            button4.BackColor = Color.Blue;
            button5.BackColor = Color.Blue;
            button6.BackColor = Color.Blue;
            button7.BackColor = Color.Blue;
            button8.BackColor = Color.Blue;
            button9.BackColor = Color.Blue;
            button10.BackColor = Color.Blue;
            button11.BackColor = Color.Blue;
            button12.BackColor = Color.Blue;
            button1.BackColor = Color.Blue;
            button14.BackColor = Color.Blue;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            button12.BackColor = Color.YellowGreen;
            button3.BackColor = Color.Blue;
            button4.BackColor = Color.Blue;
            button5.BackColor = Color.Blue;
            button6.BackColor = Color.Blue;
            button7.BackColor = Color.Blue;
            button8.BackColor = Color.Blue;
            button9.BackColor = Color.Blue;
            button10.BackColor = Color.Blue;
            button11.BackColor = Color.Blue;
            button1.BackColor = Color.Blue;
            button13.BackColor = Color.Blue;
            button14.BackColor = Color.Blue;
            int[] a1 = new int[25];
            a1[0] = 1;
            panel1.Visible = false;
            textBox2.Visible = true;
            button15.Visible = true;
            string data = string.Empty;
            string url = "https://dev.by/lenta/main/top-25-it-kompanii-s-rekordnymi-zarplatami-programmistov";
            string html = string.Empty;
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
            StreamReader myStreamReader = new StreamReader(myHttpWebResponse.GetResponseStream());
            html = myStreamReader.ReadToEnd();string n;string l="Топ-25 компания с самой высокой средней ЗП взято из dev.by :)" + Environment.NewLine;
            n = a1[0].ToString();
            var match1 = Regex.Match(html, @"" + n + ". (.*)</h2>$", RegexOptions.Multiline);
            l += match1.ToString() + Environment.NewLine;
            for (int i = 1; i < a1.Length; i++)
            {
                a1[i] = i + 1;
                n = a1[i].ToString();
                var match = Regex.Match(html, @""+n+". (.*)</h2>$", RegexOptions.Multiline);
                l += match.ToString()+ Environment.NewLine;
            }
            l = l.Replace("</h2>", "");
            textBox2.Text = l;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            button14.BackColor = Color.YellowGreen;
            button3.BackColor = Color.Blue;
            button4.BackColor = Color.Blue;
            button5.BackColor = Color.Blue;
            button6.BackColor = Color.Blue;
            button7.BackColor = Color.Blue;
            button8.BackColor = Color.Blue;
            button9.BackColor = Color.Blue;
            button10.BackColor = Color.Blue;
            button11.BackColor = Color.Blue;
            button12.BackColor = Color.Blue;
            button13.BackColor = Color.Blue;
            button1.BackColor = Color.Blue;
            Form7 loading = new Form7();
            loading.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            textBox2.Visible = false;
            button15.Visible = false;
        }
    }
}
