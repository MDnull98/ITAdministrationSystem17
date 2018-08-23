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
using System.Text.RegularExpressions;


namespace WindowsFormsApplication5
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://10.22.2.46/");
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Console.WriteLine("Содержимое сервера:");

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            listBox1.Items.Clear();

            String line;
            while ((line = reader.ReadLine()) != null)
            {
                String name = null;
                Regex regex = new Regex(@"\d+.*(\w+.txt)");
                MatchCollection matches = regex.Matches(line);
                foreach (Match match in matches)
                {
                    name = match.Value;
                    Console.WriteLine(name);
                }
                listBox1.Items.Add(line);
            }
            reader.Close();
            responseStream.Close();
            response.Close();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }


        private void button3_Click_1(object sender, EventArgs e)
        {

            String name = null;
            Regex regex = new Regex(@"\w+.txt");
            MatchCollection matches = regex.Matches(listBox1.SelectedItem.ToString());
            foreach (Match match in matches)
            {
                name = match.Value;
                Console.WriteLine(name);
            }

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://10.22.2.46/" + name);

            // Устанавливаем метод на загрузку файлов
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            // Если требуется логин и пароль, устанавливаем их
            //request.Credentials = new NetworkCredential("login", "password");
            //request.EnableSsl = true; // если используется ssl

            // Получаем ответ от сервера в виде объекта FtpWebResponse
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            // Получаем поток ответа
            Stream responseStream = response.GetResponseStream();

            // Сохраняем файл в дисковой системе
            // Создаем поток для сохранения файла

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            FileStream fs = new FileStream(filename, FileMode.Create);

            // Буфер для считываемых данных
            byte[] buffer = new byte[64];
            int size = 0;

            while ((size = responseStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                fs.Write(buffer, 0, size);
            }

            fs.Close();
            response.Close();

            Console.WriteLine("Загрузка и сохранение файла завершены");
            Console.Read();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            string filenane2 = Path.GetFileName(filename);

            // Создаем объект FtpWebRequest - он указывает на файл, который будет создан (на стороне сервера).
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://10.22.2.46/" + filenane2.Replace(" ", "_"));
            // Устанавливаем в свойстве Method, созданного объекта, тип операции (в данном случае – закачка файла на сервер).
            request.Method = WebRequestMethods.Ftp.UploadFile;
            // Создаем поток для загрузки файла
            FileStream fs = new FileStream(filename, FileMode.Open);
            byte[] fileContents = new byte[fs.Length];
            fs.Read(fileContents, 0, fileContents.Length);
            fs.Close();
            request.ContentLength = fileContents.Length;
            // Пишем считанный в массив байтов файл в выходной поток.
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();
            // Получаем ответ от сервера в виде объекта FtpWebResponse.
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            MessageBox.Show("Загрузка файлов завершена. Статус: {0}", response.StatusDescription);
            response.Close();
            Console.Read();
            request = (FtpWebRequest)WebRequest.Create("ftp://10.22.2.46/");
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            response = (FtpWebResponse)request.GetResponse();
            Console.WriteLine("Содержимое сервера:");

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            listBox1.Items.Clear();

            String line;
            while ((line = reader.ReadLine()) != null)
            {
                String name = null;
                Regex regex = new Regex(@"\d+.*(\w+.txt)");
                MatchCollection matches = regex.Matches(line);
                foreach (Match match in matches)
                {
                    name = match.Value;
                    Console.WriteLine(name);
                }
                listBox1.Items.Add(line);
            }
            reader.Close();
            responseStream.Close();
            response.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
