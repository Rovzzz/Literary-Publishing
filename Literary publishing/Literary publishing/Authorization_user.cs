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
            string path = "X:\\Literary publishing\\Debug\\User_action.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                DateTime now = DateTime.Now;
                writer.WriteLineAsync($"Debug: {now.ToString("F")}");
                    if (table.Rows.Count == 1)
                    {
                        Debug.Indent();

                        writer.WriteLineAsync("Вы успешно вошли!");
                        Debug.WriteLine("Вы успешно вошли!");
                        MessageBox.Show("Вы успешно вошли!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load load = new load();
                        this.Hide();
                        load.ShowDialog();

                    }
                    else
                    {
                        writer.WriteLineAsync("Такого аккаунта не существует!");
                        Debug.Indent();
                        Debug.WriteLine("Такого аккаунта не существует!");
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
