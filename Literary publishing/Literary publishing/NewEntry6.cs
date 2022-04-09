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
    public partial class NewEntry6 : Form
    {
        DataBase dataBase = new DataBase();

        public NewEntry6()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_save_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            var title_printing_houses = textBox6_title_printing_houses.Text;
            int id_Address;
            var Phone_number = textBox6_Phone_number.Text;
            var Mail = textBox6_Mail.Text;

                if (int.TryParse(textBox6_id_Address.Text, out id_Address))
                {
                    var addquery = $"insert into Information_about_printing_houses (title_printing_houses,id_Address,Phone_number,Mail) values ('{title_printing_houses}','{id_Address}','{Phone_number}','{Mail}')";
                    var command = new SqlCommand(addquery, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно создана!", "Запись записана", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
                string path = "C:\\Users\\1290743\\Desktop\\Literary publishing\\Debug\\User_action.txt";
                using (StreamWriter fileStream = new StreamWriter(path, true))
                {
                    fileStream.WriteLine(DateTime.Now);
                    fileStream.WriteLine("Запись успешно создана - Сведения О Типографии");
                    fileStream.Close();
                }
                }
                else
                {
                MessageBox.Show("Id адреса должно быть числовым форматом", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
                string path = "C:\\Users\\1290743\\Desktop\\Literary publishing\\Debug\\User_action.txt";
                using (StreamWriter fileStream = new StreamWriter(path, true))
                {
                    fileStream.WriteLine(DateTime.Now);
                    fileStream.WriteLine("Неправильно введены данные в (Id адреса) - Сведения О Типографии");
                    fileStream.Close();
                }
                }

                dataBase.closeConnection();
                Debug.Indent();
                Debug.WriteLine("Запись Сохранена - Сведения О Типографии");
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
         Form1 form1 = new Form1();
         form1.Show();
         this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox6_title_printing_houses.Text = "";
            textBox6_id_Address.Text = "";
            textBox6_Phone_number.Text = "";
            textBox6_Mail.Text = "";
        }
    }
}
