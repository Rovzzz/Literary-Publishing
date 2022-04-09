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
    public partial class Registration_user : Form
    {
        DataBase dataBase = new DataBase();
        public Registration_user()
        {
            InitializeComponent();
        }

        private void Registration_user_Load(object sender, EventArgs e)
        {
            textBox_password2.PasswordChar = '●';
            pictureBox3.Visible = false;
        }

        private void bCreate_Click(object sender, EventArgs e)
        {

            if (checkUser())

            {
                return;
            }

            var login = textBox_login2.Text;
            var password = textBox_password2.Text;
            string querystring = $"insert into register(login_user,password_user) values('{login}','{password}')";
            SqlCommand sqlCommand = new SqlCommand(querystring, dataBase.GetConnection());
            dataBase.openConnection();

            Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
            string path = "C:\\Users\\1290743\\Desktop\\Literary publishing\\Debug\\User_action.txt";
            using (StreamWriter fileStream = new StreamWriter(path, true))
            {
                if (sqlCommand.ExecuteNonQuery() == 1)
                {
                    Debug.Indent();
                    Debug.WriteLine("Аккаунт Успешно Создан");
                    fileStream.WriteLine(DateTime.Now);
                    fileStream.WriteLine("Аккаунт Успешно Создан");
                    fileStream.Close();
                    MessageBox.Show("Аккаунт Успешно Создан", "Аккаунт Создан!");
                    Authorization_user authorization_User = new Authorization_user();
                    this.Hide();
                    authorization_User.ShowDialog();
                }
                else
                {
                    Debug.Indent();
                    Debug.WriteLine("Аккаунт не создан");
                    MessageBox.Show("Аккаунт не создан");
                    fileStream.WriteLine(DateTime.Now);
                    fileStream.WriteLine("Аккаунт не создан");
                    fileStream.Close();
                }
                dataBase.closeConnection();
            }
        }


              

        private Boolean checkUser()
        {
            var loginUser = textBox_login2.Text;
            var passwordUser = textBox_password2.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string quertyString = $"select id_user,login_user,password_user from register where login_user = '{loginUser}' and password_user = '{passwordUser}'";
            SqlCommand command = new SqlCommand(quertyString, dataBase.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
            string path = "C:\\Users\\1290743\\Desktop\\Literary publishing\\Debug\\User_action.txt";
            using (StreamWriter fileStream = new StreamWriter(path, true))
            {
                if (table.Rows.Count > 0)
                {
                    Debug.Indent();
                    fileStream.WriteLine(DateTime.Now);
                    fileStream.WriteLine("Пользователь уже существует!");
                    fileStream.Close();
                    Debug.WriteLine("Пользователь уже существует!");
                    MessageBox.Show("Пользователь уже существует!");
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox_login2.Text = "";
            textBox_password2.Text = "";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox_password2.UseSystemPasswordChar = true;
            pictureBox3.Visible = true;
            pictureBox2.Visible = false;

            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox_password2.UseSystemPasswordChar = false;
            pictureBox3.Visible = false;
            pictureBox2.Visible = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Authorization_user authorization_User = new Authorization_user();
            authorization_User.Show();
            this.Hide();
        }
    }
}
