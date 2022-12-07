using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static IS_1_20_ValeevDR_U.Form1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Nomber2;
using Nomber5;
namespace IS_1_20_ValeevDR_U
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
  
        public abstract class Komplekuyshie<T>
        {
            public double Price;
            public int Age;
            public T Articul;
            
            public Komplekuyshie(double price, int age, T articul)
            {

                this.Price = price;
                this.Age = age;
                this.Articul = articul;

            }

            public void Constracshen()
            {

            }
            public virtual string Display()
            {
                
                return   $"Цена  { Price}  , ГодВыпуска  { Age}, Артикул {Articul}";
                
            }

        }

         class ZjestkieDiski<T> : Komplekuyshie<T>
        {
           public  int Rmp { get; set; }

            public string Inter { get; set; }

            public int capacity { get; set; }

            public ZjestkieDiski(double price, int age, T articul, int rmp,string inter, int capacity) : base(price, age, articul)
            {
                this.Rmp = rmp;
                this.Inter = inter;
                this.capacity = capacity;
            }
            public override string Display()
            {
                return ($"Цена:{Price}руб. {Age}Год выпуска, {Articul}Артикул\n ." 
                    +$" Количество оборотов жесткого диска:{Rmp}об/мин\nИнтерфейс {Inter}\n Объем:{capacity}Гб");


            }
        }
      public  class VideoKarta<T> : Komplekuyshie<T>
        {
         public  int GPU { get; set; }
           public string Prozv { get; set; }
            int VP { get; set; }
           public VideoKarta(double price, int age, T articul, int gpu, string prozv, int vp) : base(price, age, articul)
            {
                GPU = gpu;
                Prozv = prozv;
                VP = vp;
            }
             public override string Display()
            {
             return   $"Цена  { Price}  , ГодВыпуска  { Age} . {Articul}Артикул\n " 
                    + $"Частота:{GPU}\n. Производительность {Prozv}\n Объем памяти:{VP}Гб\n";
        }

        }

        Komplekuyshie<string> st1;
        VideoKarta<string> st2;
        private void button1_Click(object sender, EventArgs e)
        {

            {

           
                try
                {
                    double Price = Convert.ToDouble(textBox1.Text);
                    int Age = Convert.ToInt32(textBox2.Text);
                    string Articul = Convert.ToString(textBox3.Text);
                    int rmp = Convert.ToInt32(textBox4.Text);
                    string Inter = textBox5.Text;
                    int OP = Convert.ToInt32(textBox6.Text);
                 
                    st1 = new ZjestkieDiski<string>(Price, Age, Articul, rmp, Inter,OP );
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    listBox1.Items.Add(st1.Display());
                  
                }
        
            }
        }
        Nomber2.Form1 f1 = new Nomber2.Form1();
        private void button4_Click(object sender, EventArgs e)
        {

            f1.ShowDialog();
            this.Hide();
        }
        Nomber5.Form1 f2 = new Nomber5.Form1();
        private void button5_Click(object sender, EventArgs e)
        {
            f2.ShowDialog();
            this.Hide();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            try
            {
                  double Price = Convert.ToDouble(textBox1.Text);
                  int Age = Convert.ToInt32(textBox2.Text);
                  string Articul = Convert.ToString(textBox3.Text);
                
                  int GPU = Convert.ToInt32(textBox7.Text);
                string Prozv = textBox8.Text;
                  int VP = Convert.ToInt32(textBox9.Text);
                st2 = new VideoKarta<string>(Price, Age, Articul, GPU, Prozv , VP);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                listBox1.Items.Add(st2.Display());
                //проверить связь на вывод
            }
        }
    }
}


