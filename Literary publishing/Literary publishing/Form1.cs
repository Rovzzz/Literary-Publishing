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
    enum RowState
    { 
        Existed,
        Row,
        Modified,
        ModifiedNew,
        Deleted
    }

    public partial class Form1 : Form
    {
        DataBase dataBase = new DataBase();
            int selectedRow;
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            
        }
        private void CreateColumns9()
        {
            dataGridView9.Columns.Add("id_Customer_type", "ID");
            dataGridView9.Columns.Add("Customer_type", "Тип Заказчика");
            dataGridView9.Columns.Add("IsNew", String.Empty);
        }
        private void CreateColumns8()
        {
            dataGridView8.Columns.Add("id_Type_of_printed_products", "ID");
            dataGridView8.Columns.Add("Type_of_printed_products", "Тип Печатной Продукции");
            dataGridView8.Columns.Add("IsNew", String.Empty);
        }

        private void CreateColumns7()
        {
            dataGridView7.Columns.Add("id_Address", "ID");
            dataGridView7.Columns.Add("Сity", "Город");
            dataGridView7.Columns.Add("District", "Район");
            dataGridView7.Columns.Add("street", "Улица");
            dataGridView7.Columns.Add("house", "Дом");
            dataGridView7.Columns.Add("IsNew", String.Empty);
        }

        private void CreateColumns6()
        {
            dataGridView6.Columns.Add("id_Information_about_printing_houses", "ID");
            dataGridView6.Columns.Add("title_printing_houses", "Название Типографии");
            dataGridView6.Columns.Add("id_Address", "ID Адреса");
            dataGridView6.Columns.Add("Phone_number", "Номер Телефона");
            dataGridView6.Columns.Add("Mail", "Электронная Почта");
            dataGridView6.Columns.Add("IsNew", String.Empty);
        }

        private void CreateColumns5()
        {
            dataGridView5.Columns.Add("id_Information_about_the_authors", "ID");
            dataGridView5.Columns.Add("Surname", "Фамилия");
            dataGridView5.Columns.Add("Name", "Имя");
            dataGridView5.Columns.Add("Patronymic", "Отчество");
            dataGridView5.Columns.Add("Phone_number", "Номер Телефона");
            dataGridView5.Columns.Add("Mail", "Электронная Почта");
            dataGridView5.Columns.Add("IsNew", String.Empty);
        }

        private void CreateColumns4()
        {
            dataGridView4.Columns.Add("id_Information_about_publications", "ID");
            dataGridView4.Columns.Add("id_Information_about_the_authors", "ID Сведения об Авторах");
            dataGridView4.Columns.Add("title", "Название");
            dataGridView4.Columns.Add("Volume_in_printed_sheets", "Кол-во страниц");
            dataGridView4.Columns.Add("Circulation", "Тираж");
            dataGridView4.Columns.Add("IsNew", String.Empty);
        }

        private void CreateColumns3()
        {
            dataGridView3.Columns.Add("id_Accounting", "ID");
            dataGridView3.Columns.Add("royalties_expenses", "Расходы На Авторский Гонорар");
            dataGridView3.Columns.Add("expenses_for_the_fee_for_artistic_and_graphic_works", "Расходы На Гонорар За Художественно  Графические Работы");
            dataGridView3.Columns.Add("printing_costs", "Расходы На Полиграфические Работы");
            dataGridView3.Columns.Add("material_costs", "Расходы На Материалы");
            dataGridView3.Columns.Add("editorial_expenses", "Редакционные Расходы");
            dataGridView3.Columns.Add("general_publishing_expenses", "Общеиздательские Расходы");
            dataGridView3.Columns.Add("selling_expenses", "Расходы На Продажу");
            dataGridView3.Columns.Add("Expenses_from_loss_defect", "Расходы От Потери Брака");
            dataGridView3.Columns.Add("Basic_income", "Основные Доходы");
            dataGridView3.Columns.Add("Secondary_income", "Второстепенные Доходы");
            dataGridView3.Columns.Add("Debts", "Долги");
            dataGridView3.Columns.Add("Taxes", "Налоги");
            dataGridView3.Columns.Add("IsNew", String.Empty);
        }

        private void CreateColumns2()
        {
            dataGridView2.Columns.Add("id_Information_about_Customers", "ID");
            dataGridView2.Columns.Add("id_Customer_type", "ID Тип Заказчика");
            dataGridView2.Columns.Add("Surname", "Фамилия");
            dataGridView2.Columns.Add("Name", "Имя");
            dataGridView2.Columns.Add("Patronymic", "Отчество");
            dataGridView2.Columns.Add("id_Address", "ID Адреса");
            dataGridView2.Columns.Add("Phone_number", "Номер Телефона");
            dataGridView2.Columns.Add("Mail", "Электронная Почта");
            dataGridView2.Columns.Add("IsNew", String.Empty);
        }

        private void CreateColumns1()
        {
            dataGridView1.Columns.Add("id_Information_about_orders", "ID");
            dataGridView1.Columns.Add("id_Accounting", "ID Бухгалтерский Учет");
            dataGridView1.Columns.Add("id_Information_about_Customers", "ID Тип Заказчика");
            dataGridView1.Columns.Add("id_Type_of_printed_products", "ID Тип Печатной Продукции");
            dataGridView1.Columns.Add("id_Information_about_publications", "ID Сведения о издании");
            dataGridView1.Columns.Add("id_Information_about_printing_houses", "ID Сведения о Типографии");
            dataGridView1.Columns.Add("date_of_order_acceptance", "Дата Принятия Заказа");
            dataGridView1.Columns.Add("Mark_of_completion", "Отметка о Выполнении");
            dataGridView1.Columns.Add("Order_completion_date", "Дата Выполнения Заказа");
            dataGridView1.Columns.Add("The_cost_of_the_order", "Стоимость Заказа");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSingleRow9(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), RowState.ModifiedNew);
        }
        private void ReadSingleRow8(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), RowState.ModifiedNew);
        }

        private void ReadSingleRow7(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), RowState.ModifiedNew);
        }

        private void ReadSingleRow6(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2), record.GetString(3), record.GetString(4), RowState.ModifiedNew);
        }

        private void ReadSingleRow5(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(4), RowState.ModifiedNew);
        }

        private void ReadSingleRow4(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetString(2), record.GetInt32(3), record.GetInt32(4), RowState.ModifiedNew);
        }

        private void ReadSingleRow3(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetString(6), record.GetString(7), record.GetString(8), record.GetString(9), record.GetString(10), record.GetString(11), record.GetString(12), RowState.ModifiedNew);
        }

        private void ReadSingleRow2(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetInt32(5), record.GetString(6), record.GetString(7), RowState.ModifiedNew);
        }

        private void ReadSingleRow1(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetInt32(2), record.GetInt32(3), record.GetInt32(4), record.GetInt32(5), record.GetDateTime(6), record.GetBoolean(7), record.GetDateTime(8), record.GetString(9), RowState.ModifiedNew);
        }

        private void RefreshDataGrid9(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string querystring = $"select * from Customer_type";
            SqlCommand command = new SqlCommand(querystring, dataBase.GetConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow9(dgw, reader);
            }
            reader.Close();
        }
        private void RefreshDataGrid8(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string querystring = $"select * from Type_of_printed_products";
            SqlCommand command = new SqlCommand(querystring, dataBase.GetConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow8(dgw, reader);
            }
            reader.Close();
        }

        private void RefreshDataGrid7(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string querystring = $"select * from Addresses";
            SqlCommand command = new SqlCommand(querystring, dataBase.GetConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow7(dgw, reader);
            }
            reader.Close();
        }

        private void RefreshDataGrid6(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string querystring = $"select * from Information_about_printing_houses";
            SqlCommand command = new SqlCommand(querystring, dataBase.GetConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow6(dgw, reader);
            }
            reader.Close();
        }

        private void RefreshDataGrid5(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string querystring = $"select * from Information_about_the_authors";
            SqlCommand command = new SqlCommand(querystring, dataBase.GetConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow5(dgw, reader);
            }
            reader.Close();
        }

        private void RefreshDataGrid4(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string querystring = $"select * from Information_about_publications";
            SqlCommand command = new SqlCommand(querystring, dataBase.GetConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow4(dgw, reader);
            }
            reader.Close();
        }

        private void RefreshDataGrid3(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string querystring = $"select * from Accounting";
            SqlCommand command = new SqlCommand(querystring, dataBase.GetConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow3(dgw, reader);
            }
            reader.Close();
        }

        private void RefreshDataGrid2(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string querystring = $"select * from Information_about_Customers";
            SqlCommand command = new SqlCommand(querystring, dataBase.GetConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow2(dgw, reader);
            }
            reader.Close();
        }

        private void RefreshDataGrid1(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string querystring = $"select * from Information_about_orders";
            SqlCommand command = new SqlCommand(querystring, dataBase.GetConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow1(dgw, reader);
            }
            reader.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateColumns9();
            RefreshDataGrid9(dataGridView9);

            CreateColumns8();
            RefreshDataGrid8(dataGridView8);

            CreateColumns7();
            RefreshDataGrid7(dataGridView7);

            CreateColumns6();
            RefreshDataGrid6(dataGridView6);

            CreateColumns5();
            RefreshDataGrid5(dataGridView5);

            CreateColumns4();
            RefreshDataGrid4(dataGridView4);

            CreateColumns3();
            RefreshDataGrid3(dataGridView3);

            CreateColumns2();
            RefreshDataGrid2(dataGridView2);

            CreateColumns1();
            RefreshDataGrid1(dataGridView1);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void ClearFields2()
        {
            textBox2_id.Text = "";
            textBox2_id_Customer_type.Text = "";
            textBox2_Surname.Text = "";
            textBox2_Name.Text = "";
            textBox2_Patronymic.Text = "";
            textBox2_id_Address.Text = "";
            textBox2_Phone_number.Text = "";
            textBox2_Mail.Text = "";
        }

        private void button2_clear_Click(object sender, EventArgs e)
        {
            ClearFields2();
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка ластик в форме - Сведения о Заказчиках");


        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Search1(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string SearchString = $"select * from Information_about_orders where concat (id_Information_about_orders,id_Accounting,id_Information_about_Customers,id_Type_of_printed_products,id_Information_about_publications,id_Information_about_printing_houses,date_of_order_acceptance,Mark_of_completion,Order_completion_date,The_cost_of_the_order) like '%" + textBox1_search.Text + "%'";
            SqlCommand com = new SqlCommand(SearchString, dataBase.GetConnection());
            dataBase.openConnection();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ReadSingleRow1(dgw, read);
            }
            read.Close();
        }

        private void textBox1_search_TextChanged(object sender, EventArgs e)
        {
            Search1(dataGridView1);
        }

        private void pictureBox1_search_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_refresh_Click(object sender, EventArgs e)
        {
            Debug.Indent();
            Debug.WriteLine("Поля обновлены в форме - Сведения о заказах");
            RefreshDataGrid1(dataGridView1);
        }

        private void ClearFields1()
        {
            textBox1_id.Text = "";
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

        private void button1_clear_Click(object sender, EventArgs e)
        {
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка ластик в форме - Сведения о заказах");
            ClearFields1();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void panel20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Search2(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string SearchString = $"select * from Information_about_Customers where concat (id_Information_about_Customers,id_Customer_type,Surname,Name,Patronymic,id_Address,Phone_number,Mail) like '%" + textBox2_search.Text + "%'";
            SqlCommand com = new SqlCommand(SearchString, dataBase.GetConnection());
            dataBase.openConnection();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ReadSingleRow2(dgw, read);
            }
            read.Close();
        }

        private void textBox2_search_TextChanged(object sender, EventArgs e)
        {
            Search2(dataGridView2);
        }

        private void pictureBox2_search_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_refresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid2(dataGridView2);
            Debug.Indent();
            Debug.WriteLine("Поля обновлены в форме - Сведения о Заказчиках");
        }

        private void label62_Click(object sender, EventArgs e)
        {

        }

        private void panel21_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Search3(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string SearchString = $"select * from Accounting where concat (id_Accounting,royalties_expenses,expenses_for_the_fee_for_artistic_and_graphic_works,printing_costs,material_costs,editorial_expenses,general_publishing_expenses,selling_expenses,Expenses_from_loss_defect,Basic_income,Secondary_income,Debts,Taxes) like '%" + textBox3_search.Text + "%'";
            SqlCommand com = new SqlCommand(SearchString, dataBase.GetConnection());
            dataBase.openConnection();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ReadSingleRow3(dgw, read);
            }
            read.Close();
        }

        private void textBox3_search_TextChanged(object sender, EventArgs e)
        {
            Search3(dataGridView3);
        }

        private void pictureBox3_search_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_refresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid3(dataGridView3);
        }

        private void ClearFields3()
        {
            textBox3_id.Text = "";
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

        private void button3_clear_Click(object sender, EventArgs e)
        {
            ClearFields3();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void panel22_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Search4(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string SearchString = $"select * from Information_about_publications where concat (id_Information_about_publications,id_Information_about_the_authors,title,Volume_in_printed_sheets,Circulation) like '%" + textBox4_search.Text + "%'";
            SqlCommand com = new SqlCommand(SearchString, dataBase.GetConnection());
            dataBase.openConnection();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ReadSingleRow4(dgw, read);
            }
            read.Close();
        }

        private void textBox4_search_TextChanged(object sender, EventArgs e)
        {
            Search4(dataGridView4);
        }

        private void pictureBox4_search_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_refresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid4(dataGridView4);
        }

        private void ClearFields4 ()
        {
            textBox4_id.Text = "";
            textBox4_id_Information_about_the_authors.Text = "";
            textBox4_title.Text = "";
            textBox4_Volume_in_printed_sheets.Text = "";
            textBox4_Circulation.Text = "";
        }

        private void button4_clear_Click(object sender, EventArgs e)
        {
            ClearFields4();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void panel23_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Search5(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string SearchString = $"select * from Information_about_the_authors where concat (id_Information_about_the_authors,Surname,Name,Patronymic,Phone_number,Mail) like '%" + textBox5_search.Text + "%'";
            SqlCommand com = new SqlCommand(SearchString, dataBase.GetConnection());
            dataBase.openConnection();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ReadSingleRow5(dgw, read);
            }
            read.Close();
        }

        private void textBox5_search_TextChanged(object sender, EventArgs e)
        {
            Search5(dataGridView5);
        }

        private void pictureBox5_search_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_refresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid5(dataGridView5);
        }

        private void ClearFields5()
        {
            textBox5_id.Text = "";
            textBox5_Surname.Text = "";
            textBox5_Name.Text = "";
            textBox5_Patronymic.Text = "";
            textBox5_Phone_number.Text = "";
            textBox5_Mail.Text = "";
        }

        private void button5_clear_Click(object sender, EventArgs e)
        {
            ClearFields5();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void panel24_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Search6(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string SearchString = $"select * from Information_about_printing_houses where concat (id_Information_about_printing_houses,title_printing_houses,id_Address,Phone_number,Mail) like '%" + textBox6_search.Text + "%'";
            SqlCommand com = new SqlCommand(SearchString, dataBase.GetConnection());
            dataBase.openConnection();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ReadSingleRow6(dgw, read);
            }
            read.Close();
        }

        private void textBox6_search_TextChanged(object sender, EventArgs e)
        {
            Search6(dataGridView6);
        }

        private void pictureBox6_search_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_refresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid6(dataGridView6);
        }

        private void button6_clear_Click(object sender, EventArgs e)
        {
            ClearFields6();
        }

        private void ClearFields6()
        {
            textBox6_id.Text = "";
            textBox6_title_printing_houses.Text = "";
            textBox6_id_Address.Text = "";
            textBox6_Phone_number.Text = "";
            textBox6_Mail.Text = "";
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void panel25_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Search7(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string SearchString = $"select * from Addresses where concat (id_Address,Сity,District,street,house) like '%" + textBox7_search.Text + "%'";
            SqlCommand com = new SqlCommand(SearchString, dataBase.GetConnection());
            dataBase.openConnection();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ReadSingleRow7(dgw, read);
            }
            read.Close();
        }

        private void textBox7_search_TextChanged(object sender, EventArgs e)
        {
            Search7(dataGridView7);
        }

        private void pictureBox7_search_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_refresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid7(dataGridView7);
        }

        private void ClearFields7()
        {
            textBox7_id.Text = "";
            textBox7_Сity.Text = "";
            textBox7_District.Text = "";
            textBox7_street.Text = "";
            textBox7_house.Text = "";
        }


        private void button7_clear_Click(object sender, EventArgs e)
        {
            ClearFields7();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void panel26_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Search8(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string SearchString = $"select * from Type_of_printed_products where concat (id_Type_of_printed_products,Type_of_printed_products) like '%" + textBox8_search.Text + "%'";
            SqlCommand com = new SqlCommand(SearchString, dataBase.GetConnection());
            dataBase.openConnection();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ReadSingleRow8(dgw, read);
            }
            read.Close();
        }

        private void textBox8_search_TextChanged(object sender, EventArgs e)
        {
            Search8(dataGridView8);
        }

        private void pictureBox8_clear_Click(object sender, EventArgs e)
        {

        }

        private void button8_refresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid8(dataGridView8);
        }

        private void ClearFields8()
        {
            textBox8_id.Text = "";
            textBox8_Type_of_printed_products.Text = "";
        }

        private void button8_clear_Click(object sender, EventArgs e)
        {
            ClearFields8();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void tabPage9_Click(object sender, EventArgs e)
        {

        }

        private void panel27_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void panel19_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Save9()
        {
            dataBase.openConnection();
            for (int index = 0; index < dataGridView9.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView9.Rows[index].Cells[2].Value;
                if (rowState == RowState.Existed)
                    continue;
            if(rowState == RowState.Deleted)
            {
                    var id_Customer_type = Convert.ToInt32(dataGridView9.Rows[index].Cells[0].Value);
                    var deleteQuerry = $"delete from Customer_type where id_Customer_type = {id_Customer_type}";
                    var command = new SqlCommand(deleteQuerry, dataBase.GetConnection());
                    command.ExecuteNonQuery();
            }
            if(rowState == RowState.Modified)
                {
                    var id_Customer_type = dataGridView9.Rows[index].Cells[0].Value.ToString();
                    var Customer_type = dataGridView9.Rows[index].Cells[1].Value.ToString();
                    var ChangeQuerry = $"update Customer_type set Customer_type = '{Customer_type}' where id_Customer_type = '{id_Customer_type}'";
                    var command = new SqlCommand(ChangeQuerry, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }
        private void button9_Save_Click(object sender, EventArgs e)
        {
            Save9();
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Сохранить запись в форме - Типы Заказчиков");
        }

        private void Change9()
        {
            var SelectRowIndex = dataGridView9.CurrentCell.RowIndex;
            var id = textBox9_id.Text;
            var Customer_type = textBox9_Customer_type.Text;
            if (dataGridView9.Rows[SelectRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridView9.Rows[SelectRowIndex].SetValues(id, Customer_type);
                dataGridView9.Rows[SelectRowIndex].Cells[2].Value = RowState.Modified;
            }
        }
            
        private void button9_Change_Click(object sender, EventArgs e)
        {
            Change9();
            ClearFields9();
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Изменить запись в форме - Типы Заказчиков");
        }

        private void DeleteRow9 ()
        {
            int Index = dataGridView9.CurrentCell.RowIndex;
            dataGridView9.Rows[Index].Visible = false;
            if(dataGridView9.Rows[Index].Cells[0].Value.ToString()==string.Empty)
            {
                dataGridView9.Rows[Index].Cells[2].Value = RowState.Deleted;
                return;
            }
            dataGridView9.Rows[Index].Cells[2].Value = RowState.Deleted;
        }

        private void button9_Delete_Click(object sender, EventArgs e)
        {
            DeleteRow9();
            ClearFields9();
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Удалить запись в форме - Типы Заказчиков");
        }

        private void button9_NewEntry_Click(object sender, EventArgs e)
        {
            NewEntry9 newEntry9 = new NewEntry9();
            newEntry9.Show();
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Новая запись в форме - Типы Заказчиков");
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView9_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Search9(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string SearchString = $"select * from Customer_type where concat (id_Customer_type,Customer_type) like '%" + textBox9_search.Text + "%'";
            SqlCommand com = new SqlCommand(SearchString, dataBase.GetConnection());
            dataBase.openConnection();
            SqlDataReader read = com.ExecuteReader();
            while(read.Read())
            {
                ReadSingleRow9(dgw, read);
            }
            read.Close();
        }

        private void textBox9_search_TextChanged(object sender, EventArgs e)
        {
            Search9(dataGridView9);
        }

        private void pictureBox9_search_Click(object sender, EventArgs e)
        {
            
        }

        private void button9_refresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid9(dataGridView9);
        }

        private void ClearFields9()
        {
            textBox9_id.Text = "";
            textBox9_Customer_type.Text = "";
        }

        private void button9_clear_Click(object sender, EventArgs e)
        {
            ClearFields9();
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_Customer_type_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_Type_of_printed_products_TextChanged(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_Сity_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_District_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_street_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_house_TextChanged(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_title_printing_houses_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_id_Address_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_Phone_number_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_Mail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void label53_Click(object sender, EventArgs e)
        {

        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void label47_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_Surname_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_Patronymic_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_Phone_number_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_Mail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label48_Click(object sender, EventArgs e)
        {

        }

        private void label49_Click(object sender, EventArgs e)
        {

        }

        private void label50_Click(object sender, EventArgs e)
        {

        }

        private void label51_Click(object sender, EventArgs e)
        {

        }

        private void label52_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_id_Information_about_the_authors_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_title_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_Volume_in_printed_sheets_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_Circulation_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void label54_Click(object sender, EventArgs e)
        {

        }

        private void label55_Click(object sender, EventArgs e)
        {

        }

        private void label56_Click(object sender, EventArgs e)
        {

        }

        private void label57_Click(object sender, EventArgs e)
        {

        }

        private void label58_Click(object sender, EventArgs e)
        {

        }

        private void label59_Click(object sender, EventArgs e)
        {

        }

        private void label60_Click(object sender, EventArgs e)
        {

        }

        private void label61_Click(object sender, EventArgs e)
        {

        }

        private void label63_Click(object sender, EventArgs e)
        {

        }

        private void label64_Click(object sender, EventArgs e)
        {

        }

        private void label65_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_royalties_expenses_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_expenses_for_the_fee_for_artistic_and_graphic_works_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_material_costs_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_printing_costs_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_general_publishing_expenses_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_editorial_expenses_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_selling_expenses_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_Expenses_from_loss_defect_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_Basic_income_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_Debts_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_Secondary_income_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_Taxes_TextChanged(object sender, EventArgs e)
        {

        }

        private void label66_Click(object sender, EventArgs e)
        {

        }

        private void label67_Click(object sender, EventArgs e)
        {

        }

        private void label68_Click(object sender, EventArgs e)
        {

        }

        private void label69_Click(object sender, EventArgs e)
        {

        }

        private void label70_Click(object sender, EventArgs e)
        {

        }

        private void label71_Click(object sender, EventArgs e)
        {

        }

        private void label72_Click(object sender, EventArgs e)
        {

        }

        private void label73_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_id_Customer_type_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_Surname_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_Patronymic_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_Phone_number_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_id_Address_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_Mail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label74_Click(object sender, EventArgs e)
        {

        }

        private void label75_Click(object sender, EventArgs e)
        {

        }

        private void label76_Click(object sender, EventArgs e)
        {

        }

        private void label77_Click(object sender, EventArgs e)
        {

        }

        private void label78_Click(object sender, EventArgs e)
        {

        }

        private void label79_Click(object sender, EventArgs e)
        {

        }

        private void label80_Click(object sender, EventArgs e)
        {

        }

        private void label81_Click(object sender, EventArgs e)
        {

        }

        private void label82_Click(object sender, EventArgs e)
        {

        }

        private void label83_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_Mark_of_completion_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_id_Accounting_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_id_Information_about_Customers_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_id_Information_about_publications_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_id_Type_of_printed_products_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_id_Information_about_printing_houses_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_date_of_order_acceptance_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Order_completion_date_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_The_cost_of_the_order_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Save8()
        {
            dataBase.openConnection();
            for (int index = 0; index < dataGridView8.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView8.Rows[index].Cells[2].Value;
                if (rowState == RowState.Existed)
                    continue;
                if (rowState == RowState.Deleted)
                {
                    var id_Type_of_printed_products = Convert.ToInt32(dataGridView8.Rows[index].Cells[0].Value);
                    var deleteQuerry = $"delete from Type_of_printed_products where id_Type_of_printed_products = {id_Type_of_printed_products}";
                    var command = new SqlCommand(deleteQuerry, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                }
                if (rowState == RowState.Modified)
                {
                    var id_Type_of_printed_products = dataGridView8.Rows[index].Cells[0].Value.ToString();
                    var Type_of_printed_products = dataGridView8.Rows[index].Cells[1].Value.ToString();
                    var ChangeQuerry = $"update Type_of_printed_products set Type_of_printed_products = '{Type_of_printed_products}' where id_Type_of_printed_products = '{id_Type_of_printed_products}'";
                    var command = new SqlCommand(ChangeQuerry, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }
        private void button8_Save_Click(object sender, EventArgs e)
        {
            Save8();
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Сохранить запись в форме - Тип Печатной Продукции");
        }

        private void Change8()
        {
            var SelectRowIndex = dataGridView8.CurrentCell.RowIndex;
            var id = textBox8_id.Text;
            var Type_of_printed_products = textBox8_Type_of_printed_products.Text;
            if (dataGridView8.Rows[SelectRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridView8.Rows[SelectRowIndex].SetValues(id, Type_of_printed_products);
                dataGridView8.Rows[SelectRowIndex].Cells[2].Value = RowState.Modified;
            }
        }

        private void button8_Change_Click(object sender, EventArgs e)
        {
            Change8();
            ClearFields8();
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Изменить запись в форме - Тип Печатной Продукции");
        }

        private void DeleteRow8()
        {
            int Index = dataGridView8.CurrentCell.RowIndex;
            dataGridView8.Rows[Index].Visible = false;
            if (dataGridView8.Rows[Index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView8.Rows[Index].Cells[2].Value = RowState.Deleted;
                return;
            }
            dataGridView8.Rows[Index].Cells[2].Value = RowState.Deleted;
        }

        private void button8_Delete_Click(object sender, EventArgs e)
        {
            DeleteRow8();
            ClearFields8();
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Удалить запись в форме - Тип Печатной Продукции");
        }

        private void button8_NewEntry_Click(object sender, EventArgs e)
        {
            NewEntry8 newEntry8 = new NewEntry8();
            newEntry8.Show();
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Новая запись в форме - Тип Печатной Продукции");
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Save7()
        {
            dataBase.openConnection();
            for (int index = 0; index < dataGridView7.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView7.Rows[index].Cells[5].Value;
                if (rowState == RowState.Existed)
                    continue;
                if (rowState == RowState.Deleted)
                {
                    var id_Address = Convert.ToInt32(dataGridView7.Rows[index].Cells[0].Value);
                    var deleteQuerry = $"delete from Addresses where id_Address = {id_Address}";
                    var command = new SqlCommand(deleteQuerry, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                }
                if (rowState == RowState.Modified)
                {
                    var id_Address = dataGridView7.Rows[index].Cells[0].Value.ToString();
                    var Сity = dataGridView7.Rows[index].Cells[2].Value.ToString();
                    var District = dataGridView7.Rows[index].Cells[3].Value.ToString();
                    var street = dataGridView7.Rows[index].Cells[4].Value.ToString();
                    var house = dataGridView7.Rows[index].Cells[5].Value.ToString();
                    var ChangeQuerry = $"update Addresses set Сity = '{Сity}',District = '{District}',street = '{street}',house = '{house}' where id_Address = '{id_Address}'";
                    var command = new SqlCommand(ChangeQuerry, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }
        private void button7_Save_Click(object sender, EventArgs e)
        {
            Save7();
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Сохранить запись в форме - Адреса");
        }

        private void Change7()
        {
            var SelectRowIndex = dataGridView7.CurrentCell.RowIndex;
            var id = textBox7_id.Text;
            var Сity = textBox7_Сity.Text;
            var District = textBox7_District.Text;
            var street = textBox7_street.Text;
            var house = textBox7_house.Text;
            if (dataGridView7.Rows[SelectRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridView7.Rows[SelectRowIndex].SetValues(id, Сity, District, street, house);
                dataGridView7.Rows[SelectRowIndex].Cells[5].Value = RowState.Modified;
            }
        }

        private void button7_Change_Click(object sender, EventArgs e)
        {
            Change7();
            ClearFields7();
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Изменить запись в форме - Адреса");
        }

        private void DeleteRow7()
        {
            int Index = dataGridView7.CurrentCell.RowIndex;
            dataGridView7.Rows[Index].Visible = false;
            if (dataGridView7.Rows[Index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView7.Rows[Index].Cells[5].Value = RowState.Deleted;
                return;
            }
            dataGridView7.Rows[Index].Cells[5].Value = RowState.Deleted;
        }
        private void button7_Delete_Click(object sender, EventArgs e)
        {
            DeleteRow7();
            ClearFields7();
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Удалить запись в форме - Адреса");
        }

        private void button7_NewEntry_Click(object sender, EventArgs e)
        {
            NewEntry7 newEntry7 = new NewEntry7();
            newEntry7.Show();
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Новая запись в форме - Адреса");
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Save6()
        {
            dataBase.openConnection();
            for (int index = 0; index < dataGridView6.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView6.Rows[index].Cells[5].Value;
                if (rowState == RowState.Existed)
                    continue;
                if (rowState == RowState.Deleted)
                {
                    var id_Information_about_printing_houses = Convert.ToInt32(dataGridView6.Rows[index].Cells[0].Value);
                    var deleteQuerry = $"delete from Information_about_printing_houses where id_Information_about_printing_houses = {id_Information_about_printing_houses}";
                    var command = new SqlCommand(deleteQuerry, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                }
                if (rowState == RowState.Modified)
                {
                    var id_Information_about_printing_houses = dataGridView6.Rows[index].Cells[0].Value.ToString();
                    var title_printing_houses = dataGridView6.Rows[index].Cells[1].Value.ToString();
                    var id_Address = dataGridView6.Rows[index].Cells[2].Value.ToString();
                    var Phone_number = dataGridView6.Rows[index].Cells[3].Value.ToString();
                    var Mail = dataGridView6.Rows[index].Cells[4].Value.ToString();
                    var ChangeQuerry = $"update Addresses set  title_printing_houses= '{title_printing_houses}', id_Address= '{id_Address}', Phone_number= '{Phone_number}', Mail= '{Mail}' where id_Information_about_printing_houses = '{id_Information_about_printing_houses}'";
                    var command = new SqlCommand(ChangeQuerry, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }
        private void button6_Save_Click(object sender, EventArgs e)
        {
            Save6();
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Сохранить запись в форме - Сведения об Типографии");
        }

        private void Change6()
        {
            var SelectRowIndex = dataGridView6.CurrentCell.RowIndex;
            var id = textBox6_id.Text;
            var title_printing_houses = textBox6_title_printing_houses.Text;
            int id_Address;
            var Phone_number = textBox6_Phone_number.Text;
            var Mail = textBox6_Mail.Text;
            if (dataGridView6.Rows[SelectRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if (int.TryParse(textBox6_id_Address.Text, out id_Address))
                {
                    dataGridView6.Rows[SelectRowIndex].SetValues(id, title_printing_houses, id_Address, Phone_number, Mail);
                    dataGridView6.Rows[SelectRowIndex].Cells[5].Value = RowState.Modified;
                }
                else
                {
                MessageBox.Show("ID Адреса должен быть в числовом формате!");
                }
            }
            
        }
        private void button6_Change_Click(object sender, EventArgs e)
        {
            Change6();
            ClearFields6();
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Изменить запись в форме - Сведения об Типографии");
        }

        private void DeleteRow6()
        {
            int Index = dataGridView6.CurrentCell.RowIndex;
            dataGridView6.Rows[Index].Visible = false;
            if (dataGridView6.Rows[Index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView6.Rows[Index].Cells[5].Value = RowState.Deleted;
                return;
            }
            dataGridView6.Rows[Index].Cells[5].Value = RowState.Deleted;
        }
        private void button6_Delete_Click(object sender, EventArgs e)
        {
            DeleteRow6();
            ClearFields6();
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Удалить запись в форме - Сведения об Типографии");
        }

        private void button6_NewEntry_Click(object sender, EventArgs e)
        {
            NewEntry6 newEntry6 = new NewEntry6();
            newEntry6.Show();
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Новая запись в форме - Сведения об Типографии");
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Save5()
        {
            dataBase.openConnection();
            for (int index = 0; index < dataGridView5.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView5.Rows[index].Cells[6].Value;
                if (rowState == RowState.Existed)
                    continue;
                if (rowState == RowState.Deleted)
                {
                    var id_Information_about_the_authors = Convert.ToInt32(dataGridView5.Rows[index].Cells[0].Value);
                    var deleteQuerry = $"delete from Information_about_the_authors where id_Information_about_the_authors = {id_Information_about_the_authors}";
                    var command = new SqlCommand(deleteQuerry, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                }
                if (rowState == RowState.Modified)
                {
                    var id_Information_about_the_authors = dataGridView5.Rows[index].Cells[0].Value.ToString();
                    var Surname = dataGridView5.Rows[index].Cells[1].Value.ToString();
                    var Name = dataGridView5.Rows[index].Cells[2].Value.ToString();
                    var Patronymic = dataGridView5.Rows[index].Cells[3].Value.ToString();
                    var Phone_number = dataGridView5.Rows[index].Cells[4].Value.ToString();
                    var Mail = dataGridView5.Rows[index].Cells[5].Value.ToString();
                    var ChangeQuerry = $"update Information_about_the_authors set  Surname= '{Surname}', Name= '{Name}', Patronymic= '{Patronymic}', Phone_number= '{Phone_number}', Mail = '{Mail}' where id_Information_about_the_authors = '{id_Information_about_the_authors}'";
                    var command = new SqlCommand(ChangeQuerry, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }
        private void button5_Save_Click(object sender, EventArgs e)
        {
            Save5();
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Сохранить запись в форме - Сведения об Авторах");
        }

        private void Change5()
        {
            var SelectRowIndex = dataGridView5.CurrentCell.RowIndex;
            var id = textBox5_id.Text;
            var Surname = textBox5_Surname.Text;
            var Name = textBox5_Name.Text;
            var Patronymic = textBox5_Patronymic.Text;
            var Phone_number = textBox5_Phone_number.Text;
            var Mail = textBox5_Mail.Text;
            if (dataGridView5.Rows[SelectRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
               
                    dataGridView5.Rows[SelectRowIndex].SetValues(id, Surname, Name,Patronymic, Phone_number, Mail);
                    dataGridView5.Rows[SelectRowIndex].Cells[6].Value = RowState.Modified;
            }
        }

           private void button5_Change_Click(object sender, EventArgs e)
           {
            Change5();
            ClearFields5();
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Изменить запись в форме - Сведения об Авторах");
        }

        private void DeleteRow5()
        {
            int Index = dataGridView5.CurrentCell.RowIndex;
            dataGridView5.Rows[Index].Visible = false;
            if (dataGridView5.Rows[Index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView5.Rows[Index].Cells[6].Value = RowState.Deleted;
                return;
            }
            dataGridView5.Rows[Index].Cells[6].Value = RowState.Deleted;
        }
        private void button5_Delete_Click(object sender, EventArgs e)
        {
            DeleteRow5();
            ClearFields5();
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Удалить запись в форме - Сведения об Авторах");
        }

        private void button5_NewEntry_Click(object sender, EventArgs e)
        {
            NewEntry5 newEntry5 = new NewEntry5();
            newEntry5.Show();
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Новая запись в форме - Сведения об Авторах");
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Save4()
        {
            dataBase.openConnection();
            for (int index = 0; index < dataGridView4.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView4.Rows[index].Cells[5].Value;
                if (rowState == RowState.Existed)
                    continue;
                if (rowState == RowState.Deleted)
                {
                    var id_Information_about_publications = Convert.ToInt32(dataGridView4.Rows[index].Cells[0].Value);
                    var deleteQuerry = $"delete from Information_about_publications where id_Information_about_publications = {id_Information_about_publications}";
                    var command = new SqlCommand(deleteQuerry, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                }
                if (rowState == RowState.Modified)
                {
                    var id_Information_about_publications = dataGridView4.Rows[index].Cells[0].Value.ToString();
                    var id_Information_about_the_authors = dataGridView4.Rows[index].Cells[1].Value.ToString();
                    var title = dataGridView4.Rows[index].Cells[2].Value.ToString();
                    var Volume_in_printed_sheets = dataGridView4.Rows[index].Cells[3].Value.ToString();
                    var Circulation = dataGridView4.Rows[index].Cells[4].Value.ToString();
                    var ChangeQuerry = $"update Information_about_publications set  id_Information_about_the_authors= '{id_Information_about_the_authors}', title= '{title}', Volume_in_printed_sheets= '{Volume_in_printed_sheets}', Circulation= '{Circulation}' where id_Information_about_publications = '{id_Information_about_publications}'";
                    var command = new SqlCommand(ChangeQuerry, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }
        private void button4_Save_Click(object sender, EventArgs e)
        {
            Save4();
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Сохранить запись в форме - Сведения о Издании");
        }

        private void Change4()
        {
            var SelectRowIndex = dataGridView4.CurrentCell.RowIndex;
            var id = textBox4_id.Text;
            int id_Information_about_the_authors;
            var title = textBox4_title.Text;
            int Volume_in_printed_sheets;
            int Circulation;
            if (dataGridView4.Rows[SelectRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if (int.TryParse(textBox4_id_Information_about_the_authors.Text, out id_Information_about_the_authors) && int.TryParse(textBox4_Volume_in_printed_sheets.Text, out Volume_in_printed_sheets) && int.TryParse(textBox4_Circulation.Text, out Circulation))
                {
                    dataGridView4.Rows[SelectRowIndex].SetValues(id, id_Information_about_the_authors, title, Volume_in_printed_sheets, Circulation);
                    dataGridView4.Rows[SelectRowIndex].Cells[5].Value = RowState.Modified;
                }
                else if (!int.TryParse(textBox4_id_Information_about_the_authors.Text, out id_Information_about_the_authors))
                {
                    MessageBox.Show("Неправильно введены данные в (ID сведения об авторах)", "Ошибка НЕ числовой формат");
                }
                else if (!int.TryParse(textBox4_Volume_in_printed_sheets.Text, out Volume_in_printed_sheets))
                {
                    MessageBox.Show("Неправильно введены данные в (Объём в печатны страницах)", "Ошибка НЕ числовой формат");
                }
                else if (!int.TryParse(textBox4_Circulation.Text, out Circulation))
                {
                    MessageBox.Show("Неправильно введены данные в (Тираж)", "Ошибка  НЕ числовой формат");
                }
            }
        }

        private void button4_Change_Click(object sender, EventArgs e)
        {
            Change4();
            ClearFields4();
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Изменить запись в форме - Сведения о Издании");
        }

        private void DeleteRow4()
        {
            int Index = dataGridView4.CurrentCell.RowIndex;
            dataGridView4.Rows[Index].Visible = false;
            if (dataGridView4.Rows[Index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView4.Rows[Index].Cells[5].Value = RowState.Deleted;
                return;
            }
            dataGridView4.Rows[Index].Cells[5].Value = RowState.Deleted;
        }
        private void button4_Delete_Click(object sender, EventArgs e)
        {
            DeleteRow4();
            ClearFields4();
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Удалить запись в форме - Сведения о Издании");
        }

        private void button4_NewEntry_Click(object sender, EventArgs e)
        {
            NewEntry4 newEntry4 = new NewEntry4();
            newEntry4.Show();
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Новая запись в форме - Сведения о Издании");
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Save3()
        {
            dataBase.openConnection();
            for (int index = 0; index < dataGridView3.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView3.Rows[index].Cells[13].Value;
                if (rowState == RowState.Existed)
                    continue;
                if (rowState == RowState.Deleted)
                {
                    var id_Accounting = Convert.ToInt32(dataGridView3.Rows[index].Cells[0].Value);
                    var deleteQuerry = $"delete from Accounting where id_Accounting = {id_Accounting}";
                    var command = new SqlCommand(deleteQuerry, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                }
                if (rowState == RowState.Modified)
                {
                    var id_Accounting = dataGridView3.Rows[index].Cells[0].Value.ToString();
                    var royalties_expenses = dataGridView3.Rows[index].Cells[1].Value.ToString();
                    var expenses_for_the_fee_for_artistic_and_graphic_works = dataGridView3.Rows[index].Cells[2].Value.ToString();
                    var printing_costs = dataGridView3.Rows[index].Cells[3].Value.ToString();
                    var material_costs = dataGridView3.Rows[index].Cells[4].Value.ToString();
                    var editorial_expenses = dataGridView3.Rows[index].Cells[5].Value.ToString();
                    var general_publishing_expenses = dataGridView3.Rows[index].Cells[6].Value.ToString();
                    var selling_expenses = dataGridView3.Rows[index].Cells[7].Value.ToString();
                    var Expenses_from_loss_defect = dataGridView3.Rows[index].Cells[8].Value.ToString();
                    var Basic_income = dataGridView3.Rows[index].Cells[9].Value.ToString();
                    var Secondary_income = dataGridView3.Rows[index].Cells[10].Value.ToString();
                    var Debts = dataGridView3.Rows[index].Cells[11].Value.ToString();
                    var Taxes = dataGridView3.Rows[index].Cells[12].Value.ToString();
                    var ChangeQuerry = $"update Accounting set  royalties_expenses= '{royalties_expenses}', expenses_for_the_fee_for_artistic_and_graphic_works = '{expenses_for_the_fee_for_artistic_and_graphic_works}', printing_costs= '{printing_costs}', material_costs= '{material_costs}',editorial_expenses = '{editorial_expenses}', general_publishing_expenses= '{general_publishing_expenses}',selling_expenses = '{selling_expenses}', Expenses_from_loss_defect= '{Expenses_from_loss_defect}',Basic_income = '{Basic_income}',Secondary_income = '{Secondary_income}',Debts = '{Debts}',Taxes = '{Taxes}' where id_Accounting = '{id_Accounting}'";
                    var command = new SqlCommand(ChangeQuerry, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }
        private void button3_Save_Click(object sender, EventArgs e)
        {
            Save3();
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Сохранить запись в форме - Бухгалтерский Учет");
        }

        private void Change3()
        {
            var SelectRowIndex = dataGridView3.CurrentCell.RowIndex;
            var id = textBox3_id.Text;
            var royalties_expenses = textBox3_royalties_expenses.Text;
            var expenses_for_the_fee_for_artistic_and_graphic_works = textBox3_expenses_for_the_fee_for_artistic_and_graphic_works.Text;
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
            if (dataGridView3.Rows[SelectRowIndex].Cells[0].Value.ToString() != string.Empty)
            {

                dataGridView3.Rows[SelectRowIndex].SetValues(id, royalties_expenses, expenses_for_the_fee_for_artistic_and_graphic_works, printing_costs, material_costs, editorial_expenses, general_publishing_expenses, selling_expenses, Expenses_from_loss_defect, Basic_income, Secondary_income, Debts, Taxes);
                dataGridView3.Rows[SelectRowIndex].Cells[13].Value = RowState.Modified;
            }
        }

        private void button3_Change_Click(object sender, EventArgs e)
        {
            Change3();
            ClearFields3();
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Изменить запись в форме - Бухгалтерский Учет");
        }

        private void DeleteRow3()
        {
            int Index = dataGridView3.CurrentCell.RowIndex;
            dataGridView3.Rows[Index].Visible = false;
            if (dataGridView3.Rows[Index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView3.Rows[Index].Cells[13].Value = RowState.Deleted;
                return;
            }
            dataGridView3.Rows[Index].Cells[13].Value = RowState.Deleted;
        }
        private void button3_Delete_Click(object sender, EventArgs e)
        {
            DeleteRow3();
            ClearFields3();
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Удалить запись в форме - Бухгалтерский Учет");
        }

        private void button3_NewEntry_Click(object sender, EventArgs e)
        {
            NewEntry3 newEntry3 = new NewEntry3();
            newEntry3.Show();
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Новая запись в форме - Бухгалтерский Учет");
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Save2()
        {
            dataBase.openConnection();
            for (int index = 0; index < dataGridView2.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView2.Rows[index].Cells[8].Value;
                if (rowState == RowState.Existed)
                    continue;
                if (rowState == RowState.Deleted)
                {
                    var id_Information_about_Customers = Convert.ToInt32(dataGridView2.Rows[index].Cells[0].Value);
                    var deleteQuerry = $"delete from Information_about_Customers where id_Information_about_Customers = {id_Information_about_Customers}";
                    var command = new SqlCommand(deleteQuerry, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                }
                if (rowState == RowState.Modified)
                {
                    var id_Information_about_Customers = dataGridView2.Rows[index].Cells[0].Value.ToString();
                    var id_Customer_type = dataGridView2.Rows[index].Cells[1].Value.ToString();
                    var Surname = dataGridView2.Rows[index].Cells[2].Value.ToString();
                    var Name = dataGridView2.Rows[index].Cells[3].Value.ToString();
                    var Patronymic = dataGridView2.Rows[index].Cells[4].Value.ToString();
                    var id_Address = dataGridView2.Rows[index].Cells[5].Value.ToString();
                    var Phone_number = dataGridView2.Rows[index].Cells[6].Value.ToString();
                    var Mail = dataGridView2.Rows[index].Cells[7].Value.ToString();
                    var ChangeQuerry = $"update Information_about_Customers set  id_Customer_type= '{id_Customer_type}', Surname = '{Surname}', Name= '{Name}', Patronymic= '{Patronymic}',id_Address = '{id_Address}', Phone_number= '{Phone_number}',Mail = '{Mail}' where id_Information_about_Customers = '{id_Information_about_Customers}'";
                    var command = new SqlCommand(ChangeQuerry, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }
        private void button2_Save_Click(object sender, EventArgs e)
        {
            Save2();
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Сохранить в форме - Сведения о Заказчиках");
        }

        private void Change2()
        {
            var SelectRowIndex = dataGridView2.CurrentCell.RowIndex;
            var id = textBox2_id.Text;
            int id_Customer_type;
            var Surname = textBox2_Surname.Text;
            var Name = textBox2_Name.Text;
            var Patronymic = textBox2_Patronymic.Text;
            int id_Address;
            var Phone_number = textBox2_Phone_number.Text;
            var Mail = textBox2_Mail.Text;
            if (dataGridView2.Rows[SelectRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if (int.TryParse(textBox2_id_Customer_type.Text, out id_Customer_type) && int.TryParse(textBox2_id_Address.Text, out id_Address))
                {
                    dataGridView2.Rows[SelectRowIndex].SetValues(id, id_Customer_type, Surname, Name, Patronymic, id_Address, Phone_number, Mail);
                    dataGridView2.Rows[SelectRowIndex].Cells[8].Value = RowState.Modified;
                }
                else if (!int.TryParse(textBox2_id_Customer_type.Text, out id_Customer_type))
                {
                    MessageBox.Show("ID Тип Заказчика должен быть числовым форматом");
                }
                else if (!int.TryParse(textBox2_id_Address.Text, out id_Address))
                {
                    MessageBox.Show("ID Адреса должен быть числовым форматом");
                }

            }
        }

        private void button2_Change_Click(object sender, EventArgs e)
        {
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Изменить запись в форме - Сведения о Зказчиках");
            Change2();
            ClearFields2();
        }

        private void DeleteRow2()
        {
            int Index = dataGridView2.CurrentCell.RowIndex;
            dataGridView2.Rows[Index].Visible = false;
            if (dataGridView2.Rows[Index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView2.Rows[Index].Cells[8].Value = RowState.Deleted;
                return;
            }
            dataGridView2.Rows[Index].Cells[8].Value = RowState.Deleted;
        }
        private void button2_Delete_Click(object sender, EventArgs e)
        {
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Удалить запись в форме - Сведения о Заказчиках");
            DeleteRow2();
            ClearFields2();
        }

        private void button2_NewEntry_Click(object sender, EventArgs e)
        {
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Новая запись в форме - Сведения о Заказчиках");
            NewEntry2 newEntry2 = new NewEntry2();
            newEntry2.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Save1()
        {
            dataBase.openConnection();
            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[10].Value;
                if (rowState == RowState.Existed)
                    continue;
                if (rowState == RowState.Deleted)
                {
                    var id_Information_about_orders = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuerry = $"delete from Information_about_orders where id_Information_about_orders = {id_Information_about_orders}";
                    var command = new SqlCommand(deleteQuerry, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                }
                if (rowState == RowState.Modified)
                {
                    var id_Information_about_orders = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var id_Accounting = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var id_Information_about_Customers = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var id_Type_of_printed_products = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    var id_Information_about_publications = dataGridView1.Rows[index].Cells[4].Value.ToString();
                    var id_Information_about_printing_houses = dataGridView1.Rows[index].Cells[5].Value.ToString();
                    var date_of_order_acceptance = dataGridView1.Rows[index].Cells[6].Value.ToString();
                    var Mark_of_completion = dataGridView1.Rows[index].Cells[7].Value.ToString();
                    var Order_completion_date = dataGridView1.Rows[index].Cells[8].Value.ToString();
                    var The_cost_of_the_order = dataGridView1.Rows[index].Cells[9].Value.ToString();
                    var ChangeQuerry = $"update Information_about_orders set  id_Accounting= '{id_Accounting}', id_Information_about_Customers = '{id_Information_about_Customers}', id_Type_of_printed_products= '{id_Type_of_printed_products}', id_Information_about_publications= '{id_Information_about_publications}',id_Information_about_printing_houses = '{id_Information_about_printing_houses}', date_of_order_acceptance= '{date_of_order_acceptance}',Mark_of_completion = '{Mark_of_completion}',Order_completion_date = '{Order_completion_date}',The_cost_of_the_order = '{The_cost_of_the_order}' where id_Information_about_orders = '{id_Information_about_orders}'";
                    var command = new SqlCommand(ChangeQuerry, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }
        private void button1_Save_Click(object sender, EventArgs e)
        {
            Save1();
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Сохранить в форме - Сведения о заказах");
        }

        private void Change1()
        {
            var SelectRowIndex = dataGridView1.CurrentCell.RowIndex;
            var id = textBox1_id.Text;
            int id_Accounting;
            int id_Information_about_Customers;
            int id_Type_of_printed_products;
            int id_Information_about_publications;
            int id_Information_about_printing_houses;
            var date_of_order_acceptance = textBox1_date_of_order_acceptance;
            var Mark_of_completion = checkBox1_Mark_of_completion;
            var Order_completion_date = textBox1_Order_completion_date;
            var The_cost_of_the_order = textBox1_The_cost_of_the_order;
            if (dataGridView1.Rows[SelectRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if (int.TryParse(textBox1_id_Accounting.Text, out id_Accounting) && int.TryParse(textBox1_id_Information_about_Customers.Text, out id_Information_about_Customers) && int.TryParse(textBox1_id_Type_of_printed_products.Text, out id_Type_of_printed_products) && int.TryParse(textBox1_id_Type_of_printed_products.Text, out id_Information_about_publications) && int.TryParse(textBox1_id_Information_about_printing_houses.Text, out id_Information_about_printing_houses))
                {
                    dataGridView1.Rows[SelectRowIndex].SetValues(id, id_Accounting, id_Information_about_Customers, id_Type_of_printed_products, id_Information_about_publications, id_Information_about_printing_houses, date_of_order_acceptance, Mark_of_completion, Order_completion_date, The_cost_of_the_order);
                    dataGridView1.Rows[SelectRowIndex].Cells[10].Value = RowState.Modified;
                }
                else if (!int.TryParse(textBox1_id_Accounting.Text, out id_Accounting))
                {
                    MessageBox.Show("Неправильно введены данные в (ID Бухгалтерский учёт)");
                }
                else if (!int.TryParse(textBox1_id_Information_about_Customers.Text, out id_Information_about_Customers))
                {
                    MessageBox.Show("Неправильно введены данные в (ID Сведения О Заказчике)");
                }
                else if (!int.TryParse(textBox1_id_Type_of_printed_products.Text, out id_Type_of_printed_products))
                {
                    MessageBox.Show("Неправильно введены данные в (ID Тип Печатной Продукции)");
                }
                else if (!int.TryParse(textBox1_id_Information_about_publications.Text, out id_Information_about_publications))
                {
                    MessageBox.Show("Неправильно введены данные в (ID Сведения О Издании)");
                }
                else if (!int.TryParse(textBox1_id_Information_about_printing_houses.Text, out id_Information_about_printing_houses))
                {
                    MessageBox.Show("Неправильно введены данные в (ID Свдения О Типографии)");
                }


            }
        }

        private void button1_Change_Click(object sender, EventArgs e)
        {
            Change1();
            ClearFields1();
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Изменить запись в форме - Сведения о заказах");
        }

        private void DeleteRow1()
        {
            int Index = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[Index].Visible = false;
            if (dataGridView1.Rows[Index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView1.Rows[Index].Cells[10].Value = RowState.Deleted;
                return;
            }
            dataGridView1.Rows[Index].Cells[10].Value = RowState.Deleted;
        }
        private void button1_Delete_Click(object sender, EventArgs e)
        {
            DeleteRow1();
            ClearFields1();
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Удалить запись в форме - Сведения о заказах");
        }

        private void button1_NewEntry_Click(object sender, EventArgs e)
        {
            Debug.Indent();
            Debug.WriteLine("Нажата кнопка - Новая запись в форме - Сведения о заказах");
            NewEntry1 newEntry1 = new NewEntry1();
            newEntry1.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView9_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if(e.RowIndex>=0)
            {
                DataGridViewRow row = dataGridView9.Rows[selectedRow];
                textBox9_id.Text = row.Cells[0].Value.ToString();
                textBox9_Customer_type.Text = row.Cells[1].Value.ToString();
            }
        }

        private void dataGridView8_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView8.Rows[selectedRow];
                textBox8_id.Text = row.Cells[0].Value.ToString();
                textBox8_Type_of_printed_products.Text = row.Cells[1].Value.ToString();
            }
        }

        private void dataGridView7_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView7.Rows[selectedRow];
                textBox7_id.Text = row.Cells[0].Value.ToString();
                textBox7_Сity.Text = row.Cells[1].Value.ToString();
                textBox7_District.Text = row.Cells[2].Value.ToString();
                textBox7_street.Text = row.Cells[3].Value.ToString();
                textBox7_house.Text = row.Cells[4].Value.ToString();
            }
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView6.Rows[selectedRow];
                textBox6_id.Text = row.Cells[0].Value.ToString();
                textBox6_title_printing_houses.Text = row.Cells[1].Value.ToString();
                textBox6_id_Address.Text = row.Cells[2].Value.ToString();
                textBox6_Phone_number.Text = row.Cells[3].Value.ToString();
                textBox6_Mail.Text = row.Cells[4].Value.ToString();
            }
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView5.Rows[selectedRow];
                textBox5_id.Text = row.Cells[0].Value.ToString();
                textBox5_Surname.Text = row.Cells[1].Value.ToString();
                textBox5_Name.Text = row.Cells[2].Value.ToString();
                textBox5_Patronymic.Text = row.Cells[3].Value.ToString();
                textBox5_Phone_number.Text = row.Cells[4].Value.ToString();
                textBox5_Mail.Text = row.Cells[5].Value.ToString();
            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView4.Rows[selectedRow];
                textBox4_id.Text = row.Cells[0].Value.ToString();
                textBox4_id_Information_about_the_authors.Text = row.Cells[1].Value.ToString();
                textBox4_title.Text = row.Cells[2].Value.ToString();
                textBox4_Volume_in_printed_sheets.Text = row.Cells[3].Value.ToString();
                textBox4_Circulation.Text = row.Cells[4].Value.ToString();
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView3.Rows[selectedRow];
                textBox3_id.Text = row.Cells[0].Value.ToString();
                textBox3_royalties_expenses.Text = row.Cells[1].Value.ToString();
                textBox3_expenses_for_the_fee_for_artistic_and_graphic_works.Text = row.Cells[2].Value.ToString();
                textBox3_printing_costs.Text = row.Cells[3].Value.ToString();
                textBox3_material_costs.Text = row.Cells[4].Value.ToString();
                textBox3_editorial_expenses.Text = row.Cells[5].Value.ToString();
                textBox3_general_publishing_expenses.Text = row.Cells[6].Value.ToString();
                textBox3_selling_expenses.Text = row.Cells[7].Value.ToString();
                textBox3_Expenses_from_loss_defect.Text = row.Cells[8].Value.ToString();
                textBox3_Basic_income.Text = row.Cells[9].Value.ToString();
                textBox3_Secondary_income.Text = row.Cells[10].Value.ToString();
                textBox3_Debts.Text = row.Cells[11].Value.ToString();
                textBox3_Taxes.Text = row.Cells[12].Value.ToString();
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[selectedRow];
                textBox2_id.Text = row.Cells[0].Value.ToString();
                textBox2_id_Customer_type.Text = row.Cells[1].Value.ToString();
                textBox2_Surname.Text = row.Cells[2].Value.ToString();
                textBox2_Name.Text = row.Cells[3].Value.ToString();
                textBox2_Patronymic.Text = row.Cells[4].Value.ToString();
                textBox2_id_Address.Text = row.Cells[5].Value.ToString();
                textBox2_Phone_number.Text = row.Cells[6].Value.ToString();
                textBox2_Mail.Text = row.Cells[7].Value.ToString();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];
                textBox1_id.Text = row.Cells[0].Value.ToString();
                textBox1_id_Accounting.Text = row.Cells[1].Value.ToString();
                textBox1_id_Information_about_Customers.Text = row.Cells[2].Value.ToString();
                textBox1_id_Type_of_printed_products.Text = row.Cells[3].Value.ToString();
                textBox1_id_Information_about_publications.Text = row.Cells[4].Value.ToString();
                textBox1_id_Information_about_printing_houses.Text = row.Cells[5].Value.ToString();
                textBox1_date_of_order_acceptance.Text = row.Cells[6].Value.ToString();
                checkBox1_Mark_of_completion.Text = row.Cells[7].Value.ToString();
                textBox1_Order_completion_date.Text = row.Cells[8].Value.ToString();
                textBox1_The_cost_of_the_order.Text = row.Cells[9].Value.ToString();
            }
        }
    }
}
