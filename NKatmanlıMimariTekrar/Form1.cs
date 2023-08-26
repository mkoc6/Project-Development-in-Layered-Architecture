using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using LogicLayer;
using DataAccessLayer;
namespace NKatmanlıMimariTekrar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            List<EntityPersonel> PerList = LogicPersonel.LLPersonelListesi();
            dataGridView1.DataSource = PerList;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            EntityPersonel ent = new EntityPersonel();
            ent.Ad = textBox2.Text;
            ent.Soyad = textBox3.Text;
            ent.Sehir = textBox6.Text;
            ent.Maas =short.Parse ( textBox7.Text);
            ent.Gorev = textBox5.Text;
            LogicPersonel.LLPersonelEkle(ent);

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            EntityPersonel ent = new EntityPersonel();
            ent.Id = Convert.ToInt32(textBox1.Text);
            LogicPersonel.LLPersonelSil(ent.Id);
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            EntityPersonel ent = new EntityPersonel();
            ent.Id = Convert.ToInt32(textBox1.Text);
            ent.Ad = textBox2.Text;
            ent.Soyad = textBox3.Text;
            ent.Sehir = textBox6.Text;
            ent.Maas = short.Parse(textBox7.Text);
            ent.Gorev = textBox5.Text;
            LogicPersonel.LLPersonelGuncelle(ent);

        }
    }
}
