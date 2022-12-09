using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConnectDB;
using MySql.Data.MySqlClient;
using Nomber5;
namespace Nomber4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
          
        }
        BindingSource bas = new BindingSource();
        private void button2_Click(object sender, EventArgs e)
        {

        }
        // Id Fio Date_of_Birth  PhotoUrl
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string st1 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_20_6;database=is_1_20_st6_KURS;password=40112334;";

            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string f1 = "";
            string f2 = "";
            string f3 = "";
            string sql =$"SELECT * FROM T_datatime WHERE Id= "+st1;

            MySqlDataAdapter adapter = new MySqlDataAdapter($"SELECT * FROM T_datatime ", conn);
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                f1 = reader[0].ToString();
                f2 = reader[1].ToString();
                f3 = reader[2].ToString();
              
            }
            reader.Close();
            label1.Text = ($"Id:{f1}. ФИО : {f2} , Дата рождения : {f3}");
            label1.Visible = true;
            conn.Close();
        }
        void Photo(string f)
        {
            var st1 = WebRequest.Create(f);
            using (var st2 = st1.GetResponse())
                using(var st3= st2.GetResponseStream())
            {
                pictureBox1.Image = Bitmap.FromStream(st3);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_20_6;database=is_1_20_st6_KURS;password=40112334;";
            MySqlConnection conn = new MySqlConnection(connStr);

            conn.Open();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter($"SELECT * FROM T_datatime", conn);
            bas.DataSource = adapter;

            dataGridView1.DataSource = bas;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[2].Visible = true;
            dataGridView1.Columns[3].Visible = false;

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.RowHeadersVisible = false;

            dataGridView1.ColumnHeadersVisible = true;
            label1.Visible = false;
        }
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
          /*  string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_20_6;database=is_1_20_st6_KURS;password=40112334;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                string sqlq = "SELECT T_datatime.PhotoUrl AS'Фото' FROM T_datatime.Id WHERE T_datatime.Id = " + id;
                MySqlCommand cmd1 = new MySqlCommand(sqlq, conn);
                string pictur = cmd1.ExecuteScalar().ToString();
                Photo(pictur);
                MySqlDataReader reader = cmd1.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message);
            }*/
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        Nomber5.Form1 st1 = new Nomber5.Form1();
        private void button3_Click(object sender, EventArgs e)
        {
            
            st1.ShowDialog();
        
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_20_6;database=is_1_20_st6_KURS;password=40112334;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                string sqlq = "SELECT * FROM T_datatime WHERE Id=" + id;
                MySqlCommand cmd1 = new MySqlCommand(sqlq, conn);
                string pictur = cmd1.ExecuteScalar().ToString();
                Photo(pictur);
                MySqlDataReader reader = cmd1.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message);
            }
        }
    }
}
