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
            var Name = textBox5_Name;
            var Patronymic = textBox5_Patronymic.Text;
            var Phone_number = textBox5_Phone_number.Text;
            var Mail = textBox5_Mail;

            var addquery = $"insert into Infomation_about_the_autors (Surname,Name,Patronymic,Phone_number,Mail) values ('{Surname}','{Name}','{Patronymic}','{Phone_number}','{Mail}')";
            var command = new SqlCommand(addquery, dataBase.GetConnection());
            command.ExecuteNonQuery();

            dataBase.closeConnection();
            Debug.Indent();
            Debug.WriteLine("Запись Сохранена - Сведения Об Авторах");
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

