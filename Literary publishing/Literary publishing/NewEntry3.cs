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
    public partial class NewEntry3 : Form
    {
        DataBase dataBase = new DataBase();
        public NewEntry3()
        {
            InitializeComponent();
        }

        private void textBox3_expenses_for_the_fee_for_artistic_and_graphic_works_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_material_costs_TextChanged(object sender, EventArgs e)
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
            var royalties_expenses = textBox3_royalties_expenses.Text;
            var expenses_for_the_free_for_artistic_and_graphic_works = textBox3_expenses_for_the_fee_for_artistic_and_graphic_works.Text;
            var printing_costs = textBox3_printing_costs.Text;
            var material_costs = textBox3_material_costs.Text;
            var editorial_expenses = textBox3_editorial_expenses.Text;
            var general_publishing_expenses = textBox3_general_publishing_expenses.Text;
            var selling_expenses = textBox3_selling_expenses.Text;
            var Expenses_from_loss_defect = textBox3_Expenses_from_loss_defect.Text;
            var Basic_income = textBox3_Basic_income.Text;
            var Secondary_income = textBox3_Secondary_income.Text;
            var Debts = textBox3_Debts.Text;
            var Taxes = textBox3_Taxes.Text;

                var addquery = $"insert into Accounting (royalties_expenses,expenses_for_the_fee_for_artistic_and_graphic_works,printing_costs,material_costs,editorial_expenses,general_publishing_expenses,selling_expenses,Expenses_from_loss_defect,Basic_income,Secondary_income,Debts,Taxes) values ('{royalties_expenses}','{expenses_for_the_free_for_artistic_and_graphic_works}','{printing_costs}','{material_costs}','{editorial_expenses}','{general_publishing_expenses}','{selling_expenses}','{Expenses_from_loss_defect}','{Basic_income}','{Secondary_income}','{Debts}','{Taxes}')";
                var command = new SqlCommand(addquery, dataBase.GetConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно создана!", "Запись записана", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
            string path = "C:\\Users\\1290743\\Desktop\\Literary publishing\\Debug\\User_action.txt";
            using (StreamWriter fileStream = new StreamWriter(path, true))
            {
                fileStream.WriteLine(DateTime.Now);
                fileStream.WriteLine("Запись успешно создана - Бухгалтерский Учёт");
                fileStream.Close();
            }
                dataBase.closeConnection();

                Debug.Indent();
                Debug.WriteLine("Запись Сохранена - Бухгалтерский Учёт");
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3_royalties_expenses.Text = "";
            textBox3_expenses_for_the_fee_for_artistic_and_graphic_works.Text = "";
            textBox3_printing_costs.Text = "";
            textBox3_material_costs.Text = "";
            textBox3_editorial_expenses.Text = "";
            textBox3_general_publishing_expenses.Text = "";
            textBox3_selling_expenses.Text = "";
            textBox3_Expenses_from_loss_defect.Text = "";
            textBox3_Basic_income.Text = "";
            textBox3_Secondary_income.Text = "";
            textBox3_Debts.Text = "";
            textBox3_Taxes.Text = "";
        }
    }
}
