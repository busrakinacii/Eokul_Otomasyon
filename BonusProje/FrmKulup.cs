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

namespace BonusProje
{
    public partial class FrmKulup : Form
    {
        public FrmKulup()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-QUL77PV\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True;");

        void list()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBLKULUPLER", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void FrmKulup_Load(object sender, EventArgs e)
        {
            list();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            list();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO TBLKULUPLER (KULUPAD) VALUES (@p1)", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtKulupAd.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Kulüp Adı Listeye Eklenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            list();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Hide();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.OrangeRed;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewCellEventArgs == DataGrid Hücre Olayını Görüntüleme Bağımsız Değişkenleri
            //e parametresi datagridview hücre görünümleri olayları için çalışıyor
            TxtKulupid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtKulupAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete * from TBLKULUPLER where KULUPID=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtKulupid.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulup Adı Listeden Silinmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            list();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE TBLKULUPLER SET KULUPAD=@P1 WHERE KULUPID=@P2", baglanti);
            komut.Parameters.AddWithValue("@P1", TxtKulupAd.Text);
            komut.Parameters.AddWithValue("@P2", TxtKulupAd.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp Listesi Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            list();
        }
    }
}
