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
    public partial class NewEntry2 : Form
    {
        DataBase dataBase = new DataBase();
        public NewEntry2()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_Mail_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button2_save_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            int id_Customer_type;
            var Surname = textBox2_Surname.Text;
            var Name = textBox2_Name.Text;
            var Patronymic = textBox2_Patronymic.Text;
            int id_Address;
            var Phone_number = textBox2_Phone_number.Text;
            var Mail = textBox2_Mail.Text;
            if (int.TryParse(textBox2_id_Customer_type.Text, out id_Customer_type) && int.TryParse(textBox2_id_Address.Text, out id_Address))
            {
                var addquery = $"insert into Infomation_about_Customers (id_Customer_type,Surname,Name,Patronymic,id_Address,Phone_number,Mail) values ('{id_Customer_type}','{Surname}','{Name}','{Patronymic}','{id_Address}','{Phone_number}','{Mail}')";
                var command = new SqlCommand(addquery, dataBase.GetConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно создана!", "Запись записана", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!int.TryParse(textBox2_id_Customer_type.Text, out id_Customer_type))
            {
                MessageBox.Show("ID Тип Заказчика должен быть числовым форматом", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!int.TryParse(textBox2_id_Address.Text, out id_Address))
            {
                MessageBox.Show("ID Адреса должен быть числовым форматом", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            dataBase.closeConnection();

            Debug.Indent();
            Debug.WriteLine("Запись Сохранена - Сведения О Заказчиках");

        }

        private void textBox2_id_Customer_type_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2_id_Customer_type.Text = "";
            textBox2_Surname.Text = "";
            textBox2_Name.Text = "";
            textBox2_Patronymic.Text = "";
            textBox2_id_Address.Text = "";
            textBox2_Phone_number.Text = "";
            textBox2_Mail.Text = "";
        }
    }
}
