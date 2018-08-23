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
    public partial class Form1 : Form
    {
        Connection sql1 = new Connection();
        public Form1()
        {
            InitializeComponent();
            sql1.connect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                sql1.Open();
            }
            catch { MessageBox.Show("Не удается установить соединение! Проверьте Ваше подключение! :)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }//Проверка наличия соединения

            {
                SqlCommand thisCommand = sql1.sql1.CreateCommand();
                thisCommand.CommandText = @"select [ФИО] from Users where Login='" + textBox1.Text + "'";
                SqlDataReader thisReader = thisCommand.ExecuteReader();
                while (thisReader.Read())
                {
                    label4.Text += thisReader["ФИО"].ToString();
                }
                thisReader.Close();
                thisCommand.CommandText = @"select [Добавление проекта] from Users where Login='" + textBox1.Text + "'";
                thisReader = thisCommand.ExecuteReader();
                while (thisReader.Read())
                {
                    label5.Text = thisReader["Добавление проекта"].ToString();
                }
                thisReader.Close();
                thisCommand.CommandText = @"select [Добавление отдела] from Users where Login='" + textBox1.Text + "'";
                thisReader = thisCommand.ExecuteReader();
                while (thisReader.Read())
                {
                    label6.Text = thisReader["Добавление отдела"].ToString();
                }
                thisReader.Close();
                thisCommand.CommandText = @"select [Добавление сотрудника] from Users where Login='" + textBox1.Text + "'";
                thisReader = thisCommand.ExecuteReader();
                while (thisReader.Read())
                {
                    label7.Text = thisReader["Добавление сотрудника"].ToString();
                }
                thisReader.Close();
                thisCommand.CommandText = @"select [Создание пользователя] from Users where Login='" + textBox1.Text + "'";
                thisReader = thisCommand.ExecuteReader();
                while (thisReader.Read())
                {
                    label8.Text = thisReader["Создание пользователя"].ToString();
                }
                thisReader.Close();
                thisCommand.CommandText = @"select [Отображение отчёта] from Users where Login='" + textBox1.Text + "'";
                thisReader = thisCommand.ExecuteReader();
                while (thisReader.Read())
                {
                    label9.Text = thisReader["Отображение отчёта"].ToString();
                }
                thisReader.Close();
                thisCommand.CommandText = @"select [Добавление клиента] from Users where Login='" + textBox1.Text + "'";
                thisReader = thisCommand.ExecuteReader();
                while (thisReader.Read())
                {
                    label10.Text = thisReader["Добавление клиента"].ToString();
                }
                thisReader.Close();
                sql1.Close();
            }// Формирование sql-запроса в label4
            SqlDataAdapter sql2 = new SqlDataAdapter("Select Count(*) From Users where Login='" + textBox1.Text + "' and Password='" + textBox2.Text + "'", sql1.sql1);
            DataTable dt = new DataTable();
            sql2.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                Form loading = new Form2(label4.Text, textBox1.Text, label5.Text, label6.Text, label7.Text, label8.Text, label9.Text, label10.Text);
                loading.Show();
            }
            else
            {
                MessageBox.Show("Вы ошиблись! Возможно Логин или пароль неверны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBox2.Clear();
            label4.Text = "";
        }
    }
}
