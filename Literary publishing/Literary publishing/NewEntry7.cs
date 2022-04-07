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
    public partial class NewEntry7 : Form
    {
        DataBase dataBase = new DataBase();
        public NewEntry7()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
        }

        private void NewEntry7_Load(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
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
            var City = textBox7_Сity.Text;
            var District = textBox7_District.Text;
            var Street = textBox7_street.Text;
            var House = textBox7_house.Text;
            var addquery = $"insert into Addresses (City,District,street,house) values ('{City}','{District}','{Street}','{House}')";
            var command = new SqlCommand(addquery, dataBase.GetConnection());
            command.ExecuteNonQuery();
            MessageBox.Show("Запись успешно создана!", "Запись записана", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataBase.closeConnection();
            Debug.Indent();
            Debug.WriteLine("Запись Сохранена - Адреса");
        }

        private void button1_clear_Click(object sender, EventArgs e)
        {
            textBox7_Сity.Text = "";
            textBox7_District.Text = "";
            textBox7_street.Text = "";
            textBox7_house.Text = "";
        }
    }
}
