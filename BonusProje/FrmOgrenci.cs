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
using System.Windows.Forms.VisualStyles;

namespace BonusProje
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-QUL77PV\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True;");


        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        void list()
        {
            dataGridView1.DataSource = ds.TBLOGRENCI();
        }
        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            list();


            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TBLKULUPLER", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbKulup.DisplayMember = "KULUPAD";
            CmbKulup.ValueMember = "KULUPID";
            CmbKulup.DataSource = dt;
            baglanti.Close();

        }
        string cinsiyet = " ";
        private void BtnEkle_Click(object sender, EventArgs e)
        {
         

            if (radioButton1.Checked == true)
            {
                cinsiyet = "KADIN";
            }
            if (radioButton2.Checked == true)
            {
                cinsiyet = "ERKEK";
            }

            ds.OgrenciEkle(TxtAd.Text, TxtSoyad.Text, byte.Parse(CmbKulup.SelectedValue.ToString()), cinsiyet);
            MessageBox.Show("Öğrenci Listeye Eklenmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            list();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            list();
        }

        private void CmbKulup_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Txtid.Text = CmbKulup.SelectedValue.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(Txtid.Text));
            list();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                cinsiyet = "KADIN";
            }
            if(radioButton2.Checked== true)
            {
                cinsiyet = "ERKEK";
            }

            ds.OgrenciGuncelle(TxtAd.Text, TxtSoyad.Text, byte.Parse(CmbKulup.SelectedValue.ToString()), cinsiyet,int.Parse(Txtid.Text));
            list();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            CmbKulup.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            //cinsiyet = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

            if (dataGridView1.CurrentRow.Cells[3].Value.Equals("KADIN"))
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            if (dataGridView1.CurrentRow.Cells[3].Value.Equals("ERKEK"))
            {
                radioButton2.Checked = true;
                radioButton1.Checked = false;
            }

          /*  if (cinsiyet=="KADIN")
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            if (cinsiyet == "ERKEK")
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }*/

        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
          dataGridView1.DataSource = ds.OgrenciGetir(TxtAra.Text);
        }
    }
}
