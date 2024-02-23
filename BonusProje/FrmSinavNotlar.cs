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
    public partial class FrmSinavNotlar : Form
    {
        public FrmSinavNotlar()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-QUL77PV\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True;");

        DataSet1TableAdapters.TBLNOTLARTableAdapter ds = new DataSet1TableAdapters.TBLNOTLARTableAdapter();
        private void BtnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NotListesi(int.Parse(TxtAra.Text));
        }
        void list()
        {
            dataGridView1.DataSource = ds.NotListesi(int.Parse(Txtid.Text));
        }
        private void FrmSinavNotlar_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from TBLDERSLER", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbDers.DisplayMember = "DERSAD";
            CmbDers.ValueMember = "DERSID";
            CmbDers.DataSource = dt;
            baglanti.Close();

        }
        int notid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid= int.Parse(dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString());
            Txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            CmbDers.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtSinav1.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtSinav2.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            TxtSinav3.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            TxtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            TxtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            TxtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
        }
        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            int sinav1, sinav2, sinav3, proje;
            double ortalama;
            sinav1 = Convert.ToInt32(TxtSinav1.Text);
            sinav2 = Convert.ToInt32(TxtSinav2.Text);
            sinav3 = Convert.ToInt32(TxtSinav3.Text);
            proje = Convert.ToInt32(TxtProje.Text);
            ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4.00;
            TxtOrtalama.Text = ortalama.ToString();
            if(ortalama>=50)
            {
                TxtDurum.Text = "True";
            }
            else
            {
                TxtDurum.Text = "False";
            }

        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            ds.NotGuncelle(byte.Parse(CmbDers.SelectedValue.ToString()), int.Parse(Txtid.Text),byte.Parse(TxtSinav1.Text),byte.Parse(TxtSinav2.Text),byte.Parse(TxtSinav3.Text),byte.Parse(TxtProje.Text),decimal.Parse(TxtOrtalama.Text),bool.Parse(TxtDurum.Text), notid);
            list();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
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

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Txtid.Text = " ";
            TxtSinav1.Text = " ";
            TxtSinav2.Text = " ";
            TxtSinav3.Text = " ";
            TxtProje.Text = " ";
            TxtOrtalama.Text = " ";
            TxtDurum.Text = " ";
            TxtAra.Text = " ";
            //list();

        }
    }
}
