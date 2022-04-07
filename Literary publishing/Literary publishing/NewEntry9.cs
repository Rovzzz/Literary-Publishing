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
    public partial class NewEntry9 : Form
    {
        DataBase dataBase = new DataBase();
        public NewEntry9()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void NewEntry9_Load(object sender, EventArgs e)
        {

        }

        private void textBox9_Customer_type_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void textBox8_Type_of_printed_products_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_save_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            var Customer_type = textBox9_Customer_type.Text;
            var addquery = $"insert into Customer_type (Customer_type) values ('{Customer_type}')";
            var command = new SqlCommand(addquery, dataBase.GetConnection());
            command.ExecuteNonQuery();
            MessageBox.Show("Запись успешно создана!", "Запись записана", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataBase.closeConnection();
            Debug.Indent();
            Debug.WriteLine("Запись Сохранена - Типы Заказчиков");
        }

        private void button1_clear_Click(object sender, EventArgs e)
        {
            textBox9_Customer_type.Text = "";
        }
    }
}
