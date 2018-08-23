using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;


namespace WindowsFormsApplication5
{
    public partial class Form4 : Form
    {
        Connection sql1 = new Connection();
        public string CommandOtdel;
        public string CommandProject;
        public string CommandWorker;
        public string CommandClient;
        public string command;
        public string FIOakk;
        public string ShowInfoofWorker;
        public string DocofProject;
        decimal sum1 = 0;
        DataSet ds = new DataSet();
        DataSet ds11 = new DataSet();
        SqlDataAdapter sql2;
        SqlDataAdapter sql3;
        SqlDataAdapter sql4;
        SqlDataAdapter sql5;
        SqlDataAdapter sql6;
        SqlDataAdapter sql7;
        SqlDataAdapter sql8;
        SqlDataAdapter sql11;
        List<Person> persons = new List<Person>();
     //   SqlConnection sql1 = new SqlConnection(@"Data Source=10.10.10.34;Initial Catalog=15T-2-MakarevichD;Persist Security Info=True;User ID=MakarevichD;Password=impossible356"); // Адрес net соединения
        public Form4(string tablename, string loginUser)
        {
            InitializeComponent();
            sql1.connect();
            FIOakk = loginUser.ToString();
         ShowInfoofWorker = "SELECT Сотрудники.[№ сотрудника], Сотрудники.ФИО, Отделы.[Наименование отдела], Специализации.[Наименование специализации], Проекты.[№ проекта], Телефоны.[№ телефона], Сотрудники.Адрес FROM Сотрудники INNER JOIN Специализации ON Сотрудники.[№ специализации] = Специализации.[№ специализации] INNER JOIN Телефоны ON Сотрудники.[№ телефона] = Телефоны.[№ телефона] INNER JOIN Отделы ON Сотрудники.[№ отдела] = Отделы.[№ отдела] INNER JOIN Проекты ON Сотрудники.[№ проекта] = Проекты.[№ проекта] WHERE Сотрудники.ФИО='"+FIOakk+"'";
         DocofProject = "Select Проекты.[№ проекта],  [Типы проектов].[№ отдела],  [Типы проектов].[Название типа проекта],  Проекты.[Количество сотрудников],  Проекты.Сумма,  Проекты.[Дата выполнения],  Клиенты.[Наименование фирмы] FROM   Проекты INNER JOIN  [Типы проектов] ON  Проекты.[№ типа проекта] =  [Типы проектов].[№ типа проекта] INNER JOIN  Клиенты ON  Проекты.[№ клиента] =  Клиенты.[№ клиента]";
         CommandOtdel = @"INSERT INTO Отделы([№ отдела],[Наименование отдела],[№ главы отдела],[Количество сотрудников]) VALUES ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
         CommandProject = @"INSERT INTO Проекты([№ проекта],[№ типа проекта],[Количество сотрудников],[Дата выполнения],Сумма,[№ клиента]) VALUES ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')";
         CommandClient = "INSERT INTO Клиенты([№ клиента],[Наименование фирмы],email,[№ телефона]) VALUES ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
         CommandWorker = @"INSERT INTO Сотрудники([№ сотрудника],ФИО,[№ отдела],[№ проекта],[№ специализации],[№ должности],[№ телефона],Адрес) VALUES ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "',,'" + textBox8.Text + "')";
            switch (tablename)
            {
                case "Показать информацию о проектах":
                    {
                        label1.Text = "Проекты1";
                        sql2 = new SqlDataAdapter("Select * From Проекты", sql1.sql1);
                        sql2.Fill(ds, "" + label1.Text + "");
                        dataGridView1.DataSource = ds.Tables["" + label1.Text + ""]; 
                        button4.Visible = false; button3.Visible = false; button1.Visible = false;
                        listBox1.Visible = true; listBox1.Visible = false;
                    } break;
                case "Добавить клиента":
                    {
                        label1.Text = "Клиенты";
                        if (ds.Tables["" + label1.Text + ""] != null) { ds.Tables["" + label1.Text + ""].Clear(); }
                        dataGridView1.DataSource = null;
                        if (dataGridView1.RowCount > 0)
                        { dataGridView1.Rows.Clear(); }
                        sql3 = new SqlDataAdapter("Select * From "+label1.Text+"", sql1.sql1);
                        sql3.Fill(ds, "" + label1.Text + "");
                        dataGridView1.DataSource = ds.Tables["" + label1.Text + ""]; button4.Visible = false;
                        listBox1.Visible = false;
                    }
                    break;
                case "Добавить отдел":
                    {
                        label1.Text = "Отделы";
                        if (ds.Tables["" + label1.Text + ""] != null) { ds.Tables["" + label1.Text + ""].Clear(); }
                        dataGridView1.DataSource = null;
                        if (dataGridView1.RowCount > 0)
                        { dataGridView1.Rows.Clear(); }
                        sql4 = new SqlDataAdapter("Select * From " + label1.Text + "", sql1.sql1);
                        sql4.Fill(ds, "" + label1.Text + "");
                        dataGridView1.DataSource = ds.Tables["" + label1.Text + ""]; button4.Visible = false;
                        listBox1.Visible = false;
                    } break;
                case "Отчёт по проектам":
                    {
                        label1.Text = "Проекты2";
                        sql5 = new SqlDataAdapter(DocofProject, sql1.sql1);
                        sql5.Fill(ds, "" + label1.Text +"");
                        dataGridView1.DataSource = ds.Tables["" + label1.Text + ""];
                        button4.Visible = false; button3.Visible = false; button1.Visible = false;
                        listBox1.Visible = true;
                    } break;
                case "Добавить проект":
                    {
                        label1.Text = "Проекты";
                        if (ds.Tables["" + label1.Text + ""]!=null) { ds.Tables["" + label1.Text + ""].Clear(); }
                        dataGridView1.DataSource = null;
                        if (dataGridView1.RowCount > 0)
                        { dataGridView1.Rows.Clear(); }
                        sql6 = new SqlDataAdapter("Select * From " + label1.Text + "", sql1.sql1);
                        sql6.Fill(ds, "" + label1.Text + "");
                        dataGridView1.DataSource = ds.Tables["" + label1.Text + ""]; button4.Visible = false;
                        listBox1.Visible = true;
                    } break;
                case "Добавить сотрудника":
                    {
                        label1.Text = "Сотрудники";
                        if (ds.Tables["" + label1.Text + ""] != null) { ds.Tables["" + label1.Text + ""].Clear(); }
                        dataGridView1.DataSource = null;
                        if (dataGridView1.RowCount > 0)
                        { dataGridView1.Rows.Clear(); }
                        sql7 = new SqlDataAdapter("Select * From " + label1.Text + "", sql1.sql1);
                        sql7.Fill(ds, "" + label1.Text + "");
                        dataGridView1.DataSource = ds.Tables["" + label1.Text + ""]; button4.Visible = false;
                        listBox1.Visible = false;
                    } break;
                case "Показать информацию о пользователе":
                    {
                        label1.Text = "Сотрудники1";
                        System.Text.Encoding.GetEncoding(1251);
                        Encoding enc = Encoding.GetEncoding(1251);
                        sql8 = new SqlDataAdapter("SELECT Сотрудники.[№ сотрудника], Сотрудники.ФИО, Отделы.[Наименование отдела], Специализации.[Наименование специализации], Проекты.[№ проекта], Телефоны.[№ телефона], Сотрудники.Адрес FROM Сотрудники INNER JOIN Специализации ON Сотрудники.[№ специализации] = Специализации.[№ специализации] INNER JOIN Телефоны ON Сотрудники.[№ телефона] = Телефоны.[№ телефона] INNER JOIN Отделы ON Сотрудники.[№ отдела] = Отделы.[№ отдела] INNER JOIN Проекты ON Сотрудники.[№ проекта] = Проекты.[№ проекта] WHERE Сотрудники.ФИО='"+FIOakk+"'", sql1.sql1);
                        sql8.Fill(ds, ""+label1.Text+"");
                        dataGridView1.DataSource = ds.Tables["" + label1.Text + ""];
                        button4.Visible = false; button3.Visible = false; button1.Visible = false;
                        button2.Visible = false; button7.Visible = false; button8.Visible = false;
                        button9.Visible = false; textBox1.Visible = false;listBox1.Visible = false; listBox1.Visible = false;
                    } break;
              }
            dataGridView1.ReadOnly = true;
            sql1.sql1.Open();
            string strSelectPersons = "Select * From Проекты"; 
            SqlCommand cmdSelectPersons = new SqlCommand(strSelectPersons,sql1.sql1);
            SqlDataReader personsDataReader = cmdSelectPersons.ExecuteReader();
            while (personsDataReader.Read())
            {
                int id = personsDataReader.GetInt32(0);
                DateTime Dataover = personsDataReader.GetDateTime(3);
                decimal sum = personsDataReader.GetDecimal(4);sum1 += sum;
                int client = personsDataReader.GetInt32(5);
                Person ps = new Person(id,Dataover,sum,client);
                persons.Add(ps);
            }
            sql1.Close();
            listBox1.Items.AddRange(new object[] {
            "Сумма :"});
            listBox1.Items.AddRange(new object[] {
            ""+sum1+""});
        }
        private void button5_Click(object sender, EventArgs e)
        {Close();} //Закрытие окна
        private void button7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            break;
                        }
            }
        }// Поиск по ключевому слову
        private void button8_Click(object sender, EventArgs e)
        { for (int i = 0; i < dataGridView1.Rows.Count - 1; i++) { dataGridView1.Rows[i].Visible = true; }}//отмена поиска
        private void текстовыйФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.IO.Stream myStream = null;
            SaveFileDialog saveTags = new SaveFileDialog();
            saveTags.Filter = "All file (*.*) | *.*| Text file |*.txt";
            saveTags.FilterIndex = 2;
            if (saveTags.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveTags.OpenFile()) != null)
                {
                    StreamWriter myWriter = new StreamWriter(myStream);
                    try
                    {
                        for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                        {
                            for (int j = 0; j < dataGridView1.ColumnCount; j++)
                            {
                                myWriter.Write(dataGridView1.Rows[i].Cells[j].Value.ToString());
                                if ((dataGridView1.ColumnCount - j) != 1) myWriter.Write("_");
                            }

                            if (((dataGridView1.RowCount - 1) - i - 1) != 0) myWriter.WriteLine();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        myWriter.Close();
                    }
                }
                myStream.Close();
            }
        }//сохранение в текстовый файл
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }//Exit
        private void вернутьсяВМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }//Закрытие окна
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == null) { }
                {
                    sql1.Open();
                    SqlCommand thisCommand = sql1.sql1.CreateCommand();
                    switch (label1.Text)
                    {
                        case "Отделы":
                            {
                                thisCommand.CommandText = CommandOtdel;
                            }
                            break;
                        case "Клиенты":
                            {
                                thisCommand.CommandText = CommandClient;
                            }
                            break;
                        case "Проекты":
                            {
                                thisCommand.CommandText = CommandProject;
                            }
                            break;
                        case "Сотрудники":
                            {
                                thisCommand.CommandText = CommandWorker;
                            }
                            break;
                    }
                    SqlDataReader thisReader = thisCommand.ExecuteReader();
                    thisReader.Close();
                    sql1.Close();
                    MessageBox.Show("Изменения в базе данных выполнены!",
                      "Уведомление о результатах", MessageBoxButtons.OK);
                }
           }
            catch (Exception)
            {
                MessageBox.Show("Изменения в базе данных выполнить не удалось!",
                  "Уведомление о результатах", MessageBoxButtons.OK); return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int c = 0; c < dataGridView1.Columns.Count; c++)
                {
                    if (dataGridView1.Rows[i].Selected == true)
                    {
                        dataGridView1.Rows[i].Selected = false;
                        break;
                    }
                }
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            /* int k = 0;
             for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
             {
                 if (dataGridView1.Rows[i].Selected == true)
                 {
                     sql1.Open();
                     SqlCommand thisCommand = sql1.CreateCommand();
                     thisCommand.CommandText = (@"Delete From " + label1.Text + " Where [" + dataGridView1.Columns[1].HeaderText + "]='" + dataGridView1.Rows[i].Cells[1].Value + "'");
                     SqlDataReader thisReader = thisCommand.ExecuteReader();
                     thisReader.Close(); sql1.Close();
                     dataGridView1.Rows.RemoveAt(dataGridView1.Rows[i].Cells[0].RowIndex);
                     MessageBox.Show("Строка успешно удалена!", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information); k = 1;
                     break;
                 }
                 if (k == 0) { MessageBox.Show("Удаление строки невозможно! Возможно она не выбрана либо отстутствует!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information); }
             }
             */
            if (dataGridView1.RowCount > 1)
            {
                int nomer1 = dataGridView1.SelectedCells[0].RowIndex;
                dataGridView1.Rows.RemoveAt(nomer1);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void обновитьТекущуюТаблицуToolStripMenuItem_Click(object sender, EventArgs e)
        {  if (label1.Text == "") { MessageBox.Show("Ошибка","Ошибка",MessageBoxButtons.OK); }
            else
            {if (ds11.Tables.Count > 0) { ds11.Tables[0].Clear(); }
                dataGridView1.DataSource = null;
                if (dataGridView1.RowCount > 0)
                { dataGridView1.Rows.Clear(); }
                sql11 = new SqlDataAdapter("Select * FROM " + label1.Text + "", sql1.sql1);
                sql11.Fill(ds11, "Table");
                dataGridView1.DataSource = ds11.Tables[0];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
        }

        private void правкаШрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                button1.Font = fontDialog1.Font;
                button2.Font = fontDialog1.Font;
                button3.Font = fontDialog1.Font;
                button4.Font = fontDialog1.Font;
                button5.Font = fontDialog1.Font;
                button6.Font = fontDialog1.Font;
                button7.Font = fontDialog1.Font;
                button8.Font = fontDialog1.Font;
                textBox1.Font = fontDialog1.Font;
                textBox2.Font = fontDialog1.Font;
                textBox3.Font = fontDialog1.Font;
                textBox4.Font = fontDialog1.Font;
                textBox5.Font = fontDialog1.Font;
                textBox6.Font = fontDialog1.Font;
                textBox7.Font = fontDialog1.Font;
                textBox8.Font = fontDialog1.Font;
                textBox9.Font = fontDialog1.Font;
                dataGridView1.Font = fontDialog1.Font;
            }
        }

        private void правкаЦветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Dispose();
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button1.BackColor = colorDialog1.Color;
                button2.BackColor = colorDialog1.Color;
                button3.BackColor = colorDialog1.Color;
                button4.BackColor = colorDialog1.Color;
                button5.BackColor = colorDialog1.Color;
                button6.BackColor = colorDialog1.Color;
                button7.BackColor = colorDialog1.Color;
                button8.BackColor = colorDialog1.Color;
                dataGridView1.BackgroundColor = colorDialog1.Color;
            }
        }

        private void скрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label2.Visible = false; label3.Visible = false; label4.Visible = false; label5.Visible = false;
            label6.Visible = false; label7.Visible = false; label8.Visible = false; label9.Visible = false;
            textBox2.Visible = false; textBox3.Visible = false; textBox4.Visible = false; textBox5.Visible = false;
            textBox6.Visible = false; textBox7.Visible = false; textBox8.Visible = false; textBox9.Visible = false;
            button4.Visible = false; dataGridView1.Height = 439;

        }

        private void вручнуюПоказатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button4.Visible = true;
            switch (label1.Text)
            {
                case "Проекты":
                    {
                        label2.Visible = true; label3.Visible = true; label4.Visible = true; label5.Visible = true;
                        label6.Visible = true; label7.Visible = true; label8.Visible = true; label9.Visible = true;
                        textBox2.Visible = true; textBox3.Visible = true; textBox4.Visible = true; textBox5.Visible = true;
                        textBox6.Visible = true; textBox7.Visible = true; textBox8.Visible = true; textBox9.Visible = true;
                    }
                    break;
                case "Клиенты":
                    {
                        label2.Text = "№ клиента"; label3.Text = "Наименование фирмы"; label4.Text = "email"; label5.Text = "№ телефона";
                        label2.Visible = true; label3.Visible = true; label4.Visible = true; label5.Visible = true;
                        textBox2.Visible = true; textBox3.Visible = true; textBox4.Visible = true; textBox5.Visible = true;
                    }
                    break;
                case "Отделы":
                    {
                        label2.Text = "№ отдела"; label3.Text = "Наименование отдела"; label4.Text = "№ главы отдела"; label5.Text = "Количество сотрудников";
                        label2.Visible = true; label3.Visible = true; label4.Visible = true; label5.Visible = true;
                        textBox2.Visible = true; textBox3.Visible = true; textBox4.Visible = true; textBox5.Visible = true;
                    }
                    break;
                case "Сотрудники":
                    {
                        label2.Text = "[№ сотрудника"; label3.Text = "ФИО"; label4.Text = "№ отдела";
                        label5.Text = "№ проекта"; label6.Text = "№ специализации"; label7.Text = "№ должности";
                        label8.Text = "№ телефона"; label9.Text = "Адрес";
                        label2.Visible = true; label3.Visible = true; label4.Visible = true; label5.Visible = true;
                        label6.Visible = true; label7.Visible = true; label8.Visible = true; label9.Visible = true;
                        textBox2.Visible = true; textBox3.Visible = true; textBox4.Visible = true; textBox5.Visible = true;
                        textBox6.Visible = true; textBox7.Visible = true; textBox8.Visible = true; textBox9.Visible = true;
                    }
                    break;
                default:
                    { MessageBox.Show("В данную таблицу невозможно внести данные"); }
                    break;
            }
            dataGridView1.Height = 337;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (label1.Text == "Проекты")
            {
                new SqlCommandBuilder(sql6);
                sql6.Update(ds, "" + label1.Text + "");
                sql6 = new SqlDataAdapter("Select * From Проекты", sql1.sql1);
                sql6.Fill(ds, "" + label1.Text + "");
                dataGridView1.DataSource = ds.Tables["" + label1.Text + ""];
            }
            if (label1.Text == "Клиенты")
            {
                new SqlCommandBuilder(sql3);
                sql3.Update(ds, ""+ label1.Text + "");
                sql3 = new SqlDataAdapter("Select * From "+ label1.Text + "", sql1.sql1);
                sql3.Fill(ds, "" + label1.Text + "");
                dataGridView1.DataSource = ds.Tables["" + label1.Text + ""];
            }
            if (label1.Text == "Отделы")
            {
                new SqlCommandBuilder(sql4);
                sql4.Update(ds, "" + label1.Text + "");
                sql4 = new SqlDataAdapter("Select * From "+ label1.Text + "", sql1.sql1);
                sql4.Fill(ds, "" + label1.Text + "");
                dataGridView1.DataSource = ds.Tables["" + label1.Text + ""];
            }
            if (label1.Text == "Сотрудники")
            {
                new SqlCommandBuilder(sql7);
                sql7.Update(ds, "" + label1.Text + "");
                sql7 = new SqlDataAdapter("Select * From "+ label1.Text + "", sql1.sql1);
                sql7.Fill(ds, "" + label1.Text + "");
                dataGridView1.DataSource = ds.Tables["" + label1.Text + ""];
            }
            MessageBox.Show("Таблица успешно изменена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void xMLФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
                if (ds11.Tables.Count > 0) { ds11.Tables[0].Clear(); }
                sql11 = new SqlDataAdapter("Select * FROM " + label1.Text + "", sql1.sql1);
                sql11.Fill(ds11, "Table");
                dataGridView1.DataSource = ds11.Tables[0];
                try
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Xml (*.xml)|*.xml";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        ds11.WriteXml(sfd.FileName);
                    }
                    MessageBox.Show("Файл сохранен", "Завершено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void соединениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true; textBox11.Visible = false;
            label1.Text = "Введите новый адрес соединения БД";
        }

        private void пользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;button9.Text = "OK "; textBox11.Visible = true;
            label1.Text = "Введите новый Логин и пароль к серверу БД (10.10.10.34)";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            if (button9.Text == "OK ") { sql1.connect(textBox10.Text, textBox11.Text);}
            if (button9.Text == "OK") { sql1.connect(textBox10.Text);  }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }
    }
}


