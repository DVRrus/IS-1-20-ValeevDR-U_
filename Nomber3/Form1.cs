using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using MySqlX.XDevAPI.Relational;
using System.Data.SqlClient;
using Nomber4;
namespace Nomber3
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        public delegate void Handler(string message);
        public event Handler Notify;
        public class Server
        {
            static public MySqlConnection GetConn()
            {

                string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_20_6;database=is_1_20_st6_KURS;password=40112334;";
                MySqlConnection conn = new MySqlConnection(connStr);
                return conn;
            }
          


        }
        void Display(string message)
        {
            MessageBox.Show(message);
        }

        MySqlConnection conn = Server.GetConn();
        public class Auth
        {
            
          
            public static string Id = null;
            public static string Uchebka = null;
        }
            private void button1_Click(object sender, EventArgs e)

        {

            string selected_id = textBox1.Text;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите Id месяца", "Ошибка");
                return;
            }
            conn.Open();
            DataTable table = new DataTable();
         
           MySqlDataAdapter adapter = new MySqlDataAdapter($"SELECT * FROM Ucheba WHERE Id='{selected_id}'", conn);
            table.Clear();
           
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = true;
            

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
           

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            Add();

            conn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        public void Add()
        {
            Notify += Display;
            string selected_id = textBox1.Text;
            string sql = $"SELECT * FROM Ucheba WHERE Id='{selected_id}'";
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter($"SELECT * FROM Ucheba WHERE Id='{selected_id}'", conn);
            table.Clear();
            adapter.Fill(table);
            MySqlCommand command = new MySqlCommand(sql, conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                Auth.Id = reader[0].ToString();
                Auth.Uchebka = reader[1].ToString();
                //   Auth.auth_role = Convert.ToInt32(reader[3].ToString());
            }
            Notify?.Invoke($"Вы выбрали : {Auth.Id}, {Auth.Uchebka}");


           
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        Nomber4.Form1 f1 = new Nomber4.Form1();
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            f1.ShowDialog();
            this.Show();
        }
    }
}
