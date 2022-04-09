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
    public partial class Authorization_user : Form
    {
        DataBase dataBase = new DataBase();
        
        public Authorization_user()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Authorization_user_Load(object sender, EventArgs e)
        {
            textBox_password.PasswordChar = '●';
            pictureBox2.Visible = false;
            textBox_login.MaxLength = 50;
            textBox_password.MaxLength = 50;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var loginUser = textBox_login.Text;
            var passwordUser = textBox_password.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querstring = $"select id_user, login_user, password_user from register where login_user = '{loginUser}' and password_user = '{passwordUser}' ";

            SqlCommand command = new SqlCommand(querstring, dataBase.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
            string path = "C:\\Users\\1290743\\Desktop\\Literary publishing\\Debug\\User_action.txt";
            using (StreamWriter fileStream = new StreamWriter(path, true))
            {
                if (table.Rows.Count == 1)
                {
                    Debug.Indent();
                    Debug.WriteLine("Вы успешно вошли!");
                    fileStream.WriteLine(DateTime.Now);
                    fileStream.WriteLine("Вы успешно вошли!");
                    fileStream.Close();
                    MessageBox.Show("Вы успешно вошли!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load load = new load();
                    this.Hide();
                    load.ShowDialog();
                }
                else
                {
                    Debug.Indent();
                    Debug.WriteLine("Такого аккаунта не существует!");
                    fileStream.WriteLine(DateTime.Now);
                    fileStream.WriteLine("Такого аккаунта не существует!");
                    fileStream.Close();
                    MessageBox.Show("Такого аккаунта не существует!", "Аккаунта не существует", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration_user registration_User = new Registration_user();
            registration_User.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox_login.Text = "";
            textBox_password.Text = "";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox_password.UseSystemPasswordChar = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox_password.UseSystemPasswordChar = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = false;
        }

        private void textBox_password_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
