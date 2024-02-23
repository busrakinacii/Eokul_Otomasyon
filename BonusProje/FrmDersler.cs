using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BonusProje
{
    public partial class FrmDersler : Form
    {
        public FrmDersler()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            // Application.Exit();
            this.Hide();
        }
        DataSet1TableAdapters.TBLDERSLERTableAdapter ds = new DataSet1TableAdapters.TBLDERSLERTableAdapter();
        void clear()
        {
            TxtDersid.Text = " ";
            TxtDersAd.Text = " ";
        }
        void list()
        {
            dataGridView1.DataSource = ds.DersListesi();
            clear();
        }
        private void FrmDersler_Load(object sender, EventArgs e)
        {
            list();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            list();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            ds.DersEkle(TxtDersAd.Text);
            MessageBox.Show("Ders Adı Listeye Eklenmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TxtDersAd.Text = " ";
            list();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            // convert ve Pars olarak 2 şekilte dönüşüm yaptık
            //çünkü id tinyint olarak tanımladık byte olarak istiyor bizden
           // ds.DersSil(byte.Parse(TxtDersid.Text));

            ds.DersSil(Convert.ToByte(TxtDersid.Text));
            MessageBox.Show("Ders Adı Silinmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            list();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtDersid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtDersAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.DersGuncelle(TxtDersAd.Text, byte.Parse(TxtDersid.Text));
            MessageBox.Show("Ders Adı Listesi Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            list();
        }
    }
}
