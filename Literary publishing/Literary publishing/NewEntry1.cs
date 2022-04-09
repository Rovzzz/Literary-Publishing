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
    public partial class NewEntry1 : Form
    {
        DataBase dataBase = new DataBase();
        public NewEntry1()
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

            int id_Accounting;
            int id_Information_about_Customers;
            int id_Type_of_printed_products;
            int id_Information_about_publications;
            int id_Information_about_printing_houses;
            var date_of_order_acceptance = textBox1_date_of_order_acceptance.Text;
            var Mark_of_completion = checkBox1_Mark_of_completion.Text;
            var Order_completion_date = textBox1_Order_completion_date.Text;
            var The_cost_of_the_order = textBox1_The_cost_of_the_order.Text;



                if (int.TryParse(textBox1_id_Accounting.Text, out id_Accounting) && int.TryParse(textBox1_id_Information_about_Customers.Text, out id_Information_about_Customers) && int.TryParse(textBox1_id_Type_of_printed_products.Text, out id_Type_of_printed_products) && int.TryParse(textBox1_id_Information_about_publications.Text, out id_Information_about_publications) && int.TryParse(textBox1_id_Information_about_printing_houses.Text, out id_Information_about_printing_houses))
                {
                    var addquery = $"insert into Information_about_orders (id_Accounting,id_Information_about_Customers,id_Type_of_printed_products,id_Information_about_publications,id_Information_about_printing_houses,date_of_order_acceptance,Mark_of_completion,Order_completion_date,The_cost_of_the_order) values ('{id_Accounting}','{id_Information_about_Customers}','{id_Type_of_printed_products}','{id_Information_about_publications}','{id_Information_about_printing_houses}','{date_of_order_acceptance}','{Mark_of_completion}','{Order_completion_date}','{The_cost_of_the_order}')";
                    var command = new SqlCommand(addquery, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно создана!", "Запись записана", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
                string path = "C:\\Users\\1290743\\Desktop\\Literary publishing\\Debug\\User_action.txt";
                using (StreamWriter fileStream = new StreamWriter(path, true))
                {
                    fileStream.WriteLine(DateTime.Now);
                    fileStream.WriteLine("Запись успешно создана - Сведения О Заказах");
                    fileStream.Close();
                }
                }
                else if (!int.TryParse(textBox1_id_Accounting.Text, out id_Accounting))
                {
                    MessageBox.Show("Неправильно введены данные в (ID Бухгалтерский учёт)", "Ошибка НЕ числовой формат", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
                string path = "C:\\Users\\1290743\\Desktop\\Literary publishing\\Debug\\User_action.txt";
                using (StreamWriter fileStream = new StreamWriter(path, true))
                {
                    fileStream.WriteLine(DateTime.Now);
                    fileStream.WriteLine("Неправильно введены данные в (ID Бухгалтерский учёт) - Сведения О Заказах");
                    fileStream.Close();
                }
                }
                else if (!int.TryParse(textBox1_id_Information_about_Customers.Text, out id_Information_about_Customers))
                {
                    MessageBox.Show("Неправильно введены данные в (ID Сведения О Заказчике)", "Ошибка НЕ числовой формат", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
                string path = "C:\\Users\\1290743\\Desktop\\Literary publishing\\Debug\\User_action.txt";
                using (StreamWriter fileStream = new StreamWriter(path, true))
                {
                    fileStream.WriteLine(DateTime.Now);
                    fileStream.WriteLine("Неправильно введены данные в (ID Сведения О Заказчике) - Сведения О Заказах");
                    fileStream.Close();
                }
                }
                else if (!int.TryParse(textBox1_id_Type_of_printed_products.Text, out id_Type_of_printed_products))
                {
                    MessageBox.Show("Неправильно введены данные в (ID Тип Печатной Продукции)", "Ошибка  НЕ числовой формат", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
                string path = "C:\\Users\\1290743\\Desktop\\Literary publishing\\Debug\\User_action.txt";
                using (StreamWriter fileStream = new StreamWriter(path, true))
                {
                    fileStream.WriteLine(DateTime.Now);
                    fileStream.WriteLine("Неправильно введены данные в (ID Тип Печатной Продукции) - Сведения О Заказах");
                    fileStream.Close();
                }
                }
                else if (!int.TryParse(textBox1_id_Information_about_publications.Text, out id_Information_about_publications))
                {
                    MessageBox.Show("Неправильно введены данные в (ID Сведения О Издании)", "Ошибка  НЕ числовой формат", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
                string path = "C:\\Users\\1290743\\Desktop\\Literary publishing\\Debug\\User_action.txt";
                using (StreamWriter fileStream = new StreamWriter(path, true))
                {
                    fileStream.WriteLine(DateTime.Now);
                    fileStream.WriteLine("Неправильно введены данные в (ID Сведения О Издании) - Сведения О Заказах");
                    fileStream.Close();
                }
                }
                else if (!int.TryParse(textBox1_id_Information_about_printing_houses.Text, out id_Information_about_printing_houses))
                {
                    MessageBox.Show("Неправильно введены данные в (ID Свдения О Типографии)", "Ошибка  НЕ числовой формат", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
                string path = "C:\\Users\\1290743\\Desktop\\Literary publishing\\Debug\\User_action.txt";
                using (StreamWriter fileStream = new StreamWriter(path, true))
                {
                    fileStream.WriteLine(DateTime.Now);
                    fileStream.WriteLine("Неправильно введены данные в (ID Свдения О Типографии) - Сведения О Заказах");
                    fileStream.Close();
                }
                }

                dataBase.closeConnection();

                Debug.Indent();
                Debug.WriteLine("Запись Сохранена - Сведения О Заказах");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1_id_Accounting.Text = "";
            textBox1_id_Information_about_Customers.Text = "";
            textBox1_id_Type_of_printed_products.Text = "";
            textBox1_id_Information_about_publications.Text = "";
            textBox1_id_Information_about_printing_houses.Text = "";
            textBox1_date_of_order_acceptance.Text = "";
            checkBox1_Mark_of_completion.Text = "";
            textBox1_Order_completion_date.Text = "";
            textBox1_The_cost_of_the_order.Text = "";
        }

        private void NewEntry1_Load(object sender, EventArgs e)
        {

        }
    }
}
