using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication5
{
    public partial class Form3 : Form
    {
        SqlConnection sql1 = new SqlConnection(@"Data Source=10.10.10.34;Initial Catalog=15T-2-MakarevichD;Persist Security Info=True;User ID=MakarevichD;Password=impossible356"); // Адрес соединения
        byte proekt = 0;
        byte otdel = 0;
        byte worker = 0;
        byte users = 0;
        byte otchet = 0;
        byte clients = 0;
        public Form3()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) { proekt = 1; } if (checkBox2.Checked == true) { otdel = 1; } if (checkBox3.Checked == true) { worker = 1; } if (checkBox4.Checked == true) { users = 1; } if (checkBox5.Checked == true) { otchet = 1; } if (checkBox6.Checked == true) { clients = 1; }
            // Задание значений прав
            if (textBox1.Text.Length<4 & textBox2.Text.Length<4 & textBox3.Text.Length<10) { MessageBox.Show("Поля пусты или имеют длину менее 4 символов","Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Information); }
            else 
          {
              sql1.Open();
              SqlCommand thisCommand = sql1.CreateCommand();
              thisCommand.CommandText = @"INSERT INTO Users(ФИО,Login,Password,[Добавление проекта],[Добавление отдела],[Добавление сотрудника],[Создание пользователя],[Отображение отчёта],[Добавление клиента])
              VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + proekt + "','" + otdel + "','" + worker + "','" + users + "','" + otchet + "','" + clients + "')";
              SqlDataReader thisReader = thisCommand.ExecuteReader();
              thisReader.Close();
              sql1.Close();
          }
            proekt = 0; otdel = 0; worker = 0; users = 0; otchet = 0; clients = 0; // Обнулирование переменных checkBox
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear();
            checkBox1.Checked = false; checkBox2.Checked = false; checkBox3.Checked = false;
            checkBox4.Checked = false; checkBox5.Checked = false; checkBox6.Checked = false;// Обнулирование checkBox
            MessageBox.Show("Данный пользователь добавлен в систему!","Операция успешно завершена",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); 
            checkBox1.Checked = false; checkBox2.Checked = false; checkBox3.Checked = false;
            checkBox4.Checked = false; checkBox5.Checked = false; checkBox6.Checked = false;// Обнулирование checkBox
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void NameTextFIO(object sender, EventArgs e)
        {
            if (textBox1.Text == "ФИО") { textBox1.Text = ""; }
        }

        private void NameTextLogin(object sender, EventArgs e)
        {
            if (textBox2.Text == "Login") { textBox2.Text = ""; }
        }
        private void NameTextPass(object sender, EventArgs e)
        {
            if (textBox3.Text == "Password") { textBox3.Text = ""; }
            textBox3.PasswordChar = '*';
        }
    }
}
