using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConnectDB;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
namespace Nomber5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

          string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_20_6;database=is_1_20_st6_KURS;password=40112334;";
         DataTable table = new DataTable();

          BindingSource bindingSource = new BindingSource();
          MySqlConnection conn;

   
        public void Table()
        {
            
            table.Clear();
            conn.Close();
            conn.Open();
            string sql = $"SELECT * FROM T_Uchebka";
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = new MySqlCommand(sql, conn);
            adapter.Fill(table);
            bindingSource.DataSource = table;
            dataGridView1.DataSource = bindingSource;
            conn.Close();
            dataGridView1.DataSource = table;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[2].Visible = true;
            

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
          

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
           

            dataGridView1.RowHeadersVisible = false;

            dataGridView1.ColumnHeadersVisible = true;
            label1.Visible = false;

            dataGridView1.DataSource = table;
            
          
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            conn = new MySqlConnection(connStr);
            Table();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fio = textBox1.Text;
            string data = textBox2.Text;

            try 
            {
                conn.Close();
                conn.Open();
                string add = "INSERT INTO 'T_Uchebka'(FioStud,DatatimeStud) VALUES(@a,@b)";
                MySqlCommand command = new MySqlCommand(add, conn);
                command.Parameters.Add("@a", MySqlDbType.VarChar).Value = fio;
                command.Parameters.Add("@b", MySqlDbType.VarChar).Value = data;
                command.ExecuteNonQuery();
                conn.Close();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка"+ex);
              
            }
            finally
            {
                MessageBox.Show("Запись добавлена");
              

            }
                
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Table();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
