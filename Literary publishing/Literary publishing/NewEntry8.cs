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
    public partial class NewEntry8 : Form
    {
        DataBase dataBase = new DataBase();
        public NewEntry8()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void NewEntry8_Load(object sender, EventArgs e)
        {

        }

        private void button2_save_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            var Type_of_printed_products = textBox8_Type_of_printed_products.Text;
            var addquery = $"insert into Type_of_printed_products (Type_of_printed_products) values ('{Type_of_printed_products}')";
            var command = new SqlCommand(addquery, dataBase.GetConnection());
            command.ExecuteNonQuery();
            MessageBox.Show("Запись успешно создана!", "Запись записана", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataBase.closeConnection();
            Debug.Indent();
            Debug.WriteLine("Запись Сохранена - Тип Печатной Продукции");
        }

        private void button1_clear_Click(object sender, EventArgs e)
        {
            textBox8_Type_of_printed_products.Text = "";
        }
    }
}
