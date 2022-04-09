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
            var Сity = textBox7_Сity.Text;
            var District = textBox7_District.Text;
            var Street = textBox7_street.Text;
            var House = textBox7_house.Text;
            var addquery = $"insert into Addresses (Сity,District,street,house) values ('{Сity}','{District}','{Street}','{House}')";
            var command = new SqlCommand(addquery, dataBase.GetConnection());
            command.ExecuteNonQuery();
            MessageBox.Show("Запись успешно создана!", "Запись записана", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataBase.closeConnection();

            Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
            string path = "C:\\Users\\1290743\\Desktop\\Literary publishing\\Debug\\User_action.txt";
            using (StreamWriter fileStream = new StreamWriter(path, true))
            {
            Debug.Indent();
            Debug.WriteLine("Запись Сохранена - Адреса");
            fileStream.WriteLine(DateTime.Now);
            fileStream.WriteLine("Запись успешно создана - Адреса");
            fileStream.Close();
            }
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
