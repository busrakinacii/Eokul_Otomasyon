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

namespace BonusProje
{
    public partial class FrmOgrenciNotlar : Form
    {
        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-QUL77PV\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True;");

        public string numara;
        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            
            SqlCommand komut = new SqlCommand("Select DERSAD,SINAV1,SINAV1,SINAV3,PROJE,ORTALAMA,DURUM from TBLNOTLAR INNER JOIN TBLDERSLER ON TBLNOTLAR.DERSID=TBLDERSLER.DERSID WHERE OGRID=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            /////////////////////////////////////
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("SELECT OGRAD,OGRSOYAD FROM TBLOGRENCILER WHERE OGRID=@p1", baglanti);
            komut2.Parameters.AddWithValue("@p1", numara);
            SqlDataReader r1 = komut2.ExecuteReader();
           
            //Sol Üst köşedeki yazıya  ad soyad yazdırdık
           
            while (r1.Read())
            {
                this.Text = r1[0] + " " + r1[1].ToString();
            }
            baglanti.Close();
            ////////////////////////////////
       
        }
    }
}
