using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;

namespace Literary_publishing
{
    public partial class NewEntry5 : Form
    {
        DataBase dataBase = new DataBase();
        public NewEntry5()
        {
            InitializeComponent();
        }

        private void textBox5_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void textBox5_Surname_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_save_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            var Surname = textBox5_Surname.Text;
            var Name = textBox5_Name.Text;
            var Patronymic = textBox5_Patronymic.Text;
            var Phone_number = textBox5_Phone_number.Text;
            var Mail = textBox5_Mail.Text;

                var addquery = $"insert into Information_about_the_authors (Surname,Name,Patronymic,Phone_number,Mail) values ('{Surname}','{Name}','{Patronymic}','{Phone_number}','{Mail}')";
                var command = new SqlCommand(addquery, dataBase.GetConnection());
                command.ExecuteNonQuery();
            MessageBox.Show("Запись успешно создана!", "Запись записана", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dataBase.closeConnection();

            Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
            string path = "C:\\Users\\1290743\\Desktop\\Literary publishing\\Debug\\User_action.txt";
            using (StreamWriter fileStream = new StreamWriter(path, true))
            {
                Debug.Indent();
                Debug.WriteLine("Запись Сохранена - Сведения Об Авторах");
                fileStream.WriteLine(DateTime.Now);
                fileStream.WriteLine("Запись успешно создана - Сведения Об Авторах");
                fileStream.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox5_Surname.Text = "";
            textBox5_Name.Text = "";
            textBox5_Patronymic.Text = "";
            textBox5_Phone_number.Text = "";
            textBox5_Mail.Text = "";

        }
    }
}

