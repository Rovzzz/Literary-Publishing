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
    public partial class NewEntry4 : Form
    {
        DataBase dataBase = new DataBase();
        public NewEntry4()
        {
            InitializeComponent();
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
            int id_Information_about_the_authors;
            var title = textBox4_title.Text;
            int Volume_in_printed_sheets;
            int Circulation;

                if (int.TryParse(textBox4_id_Information_about_the_authors.Text, out id_Information_about_the_authors) && int.TryParse(textBox4_Volume_in_printed_sheets.Text, out Volume_in_printed_sheets) && int.TryParse(textBox4_Circulation.Text, out Circulation))
                {
                    var addquery = $"insert into Information_about_publications (id_Information_about_the_authors,title,Volume_in_printed_sheets,Circulation) values ('{id_Information_about_the_authors}','{title}','{Volume_in_printed_sheets}','{Circulation}')";
                    var command = new SqlCommand(addquery, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно создана!", "Запись записана", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
                string path = "C:\\Users\\1290743\\Desktop\\Literary publishing\\Debug\\User_action.txt";
                using (StreamWriter fileStream = new StreamWriter(path, true))
                {
                    fileStream.WriteLine(DateTime.Now);
                    fileStream.WriteLine("Запись успешно создана - Сведения О Изданиях");
                    fileStream.Close();
                }
                }
                else if (!int.TryParse(textBox4_id_Information_about_the_authors.Text, out id_Information_about_the_authors))
                {
                Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
                MessageBox.Show("Неправильно введены данные в (ID сведения об авторах)", "Ошибка НЕ числовой формат", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                string path = "C:\\Users\\1290743\\Desktop\\Literary publishing\\Debug\\User_action.txt";
                using (StreamWriter fileStream = new StreamWriter(path, true))
                {
                    
                    fileStream.WriteLine(DateTime.Now);
                    fileStream.WriteLine("Неправильно введены данные в (ID сведения об авторах) - Сведения О Изданиях");
                    fileStream.Close();
                }
                }
                else if (!int.TryParse(textBox4_Volume_in_printed_sheets.Text, out Volume_in_printed_sheets))
                {
                    MessageBox.Show("Неправильно введены данные в (Объём в печатны страницах)", "Ошибка НЕ числовой формат", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
                string path = "C:\\Users\\1290743\\Desktop\\Literary publishing\\Debug\\User_action.txt";
                using (StreamWriter fileStream = new StreamWriter(path, true))
                {
                    fileStream.WriteLine(DateTime.Now);
                    fileStream.WriteLine("Неправильно введены данные в (Объём в печатны страницах) - Сведения О Изданиях");
                    fileStream.Close();
                }
                }
                else if (!int.TryParse(textBox4_Circulation.Text, out Circulation))
                {
                 MessageBox.Show("Неправильно введены данные в (Тираж)", "Ошибка  НЕ числовой формат", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
                string path = "C:\\Users\\1290743\\Desktop\\Literary publishing\\Debug\\User_action.txt";
                using (StreamWriter fileStream = new StreamWriter(path, true))
                {
                    fileStream.WriteLine(DateTime.Now);
                    fileStream.WriteLine("Неправильно введены данные в (Тираж) - Сведения О Изданиях");
                    fileStream.Close();
                }
                }
            dataBase.closeConnection();
            Debug.Indent();
            Debug.WriteLine("Запись Сохранена - Сведения О Изданиях");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4_id_Information_about_the_authors.Text = "";
            textBox4_title.Text = "";
            textBox4_Volume_in_printed_sheets.Text = "";
            textBox4_Circulation.Text = "";
        }
    }
}
