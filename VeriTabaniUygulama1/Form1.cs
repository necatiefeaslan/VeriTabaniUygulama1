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

namespace VeriTabaniUygulama1
{
    public partial class Form1 : Form
    {
        SqlConnection sqlBaglanti = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Personel;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void btnKayıtekle_Click(object sender, EventArgs e)
        {
            try
            {
                sqlBaglanti.Open();
                string sqlCumlesi = "INSERT INTO Personel (ad_soyad,cinsiyet,departman) VALUES (" + textBox1 + "','" + textBox2.Text + "','" + textBox3.Text + "')'";
                SqlCommand cmd = new SqlCommand(sqlCumlesi, sqlBaglanti);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Veriler personel veri tabanına kaydedildi");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Bağlantı hatası oluştu");
            }
            finally 
            {
                if (sqlBaglanti != null) { sqlBaglanti.Close(); }
            }
        }
    }
}
