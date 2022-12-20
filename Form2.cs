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

namespace EmlakKayıt
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=Emin-PC;Initial Catalog=EmlakKayıt;Integrated Security=True");
        private void VerileriGoster()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from Bilgiler", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["ID"].ToString();
                ekle.SubItems.Add(oku["Site"].ToString());
                ekle.SubItems.Add(oku["Oda"].ToString());
                ekle.SubItems.Add(oku["Metre"].ToString());
                ekle.SubItems.Add(oku["Fiyat"].ToString());
                ekle.SubItems.Add(oku["Blok"].ToString());
                ekle.SubItems.Add(oku["No"].ToString());
                ekle.SubItems.Add(oku["SatKira"].ToString());
                ekle.SubItems.Add(oku["AdSoyad"].ToString());
                ekle.SubItems.Add(oku["TelNo"].ToString());
                ekle.SubItems.Add(oku["Notlar"].ToString());
                listView1.Items.Add(ekle);

            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "ZAMBAK SİTESİ")
            {
                button1.BackColor = Color.Yellow;
                btn2.BackColor = Color.Gray;
                button3.BackColor = Color.Gray;
                button4.BackColor = Color.Gray;
            }
            if (comboBox1.Text == "GÜL SİTESİ")
            {
                button1.BackColor = Color.Gray;
                btn2.BackColor = Color.Gray;
                button3.BackColor = Color.Yellow;
                button4.BackColor = Color.Gray;
            }
            if (comboBox1.Text == "MENEKSE SİTESİ")
            {
                button1.BackColor = Color.Gray;
                btn2.BackColor = Color.Yellow;
                button3.BackColor = Color.Gray;
                button4.BackColor = Color.Gray;
            }
            if (comboBox1.Text == "PAPATYA SİTESİ")
            {
                button1.BackColor = Color.Gray;
                btn2.BackColor = Color.Gray;
                button3.BackColor = Color.Gray;
                button4.BackColor = Color.Yellow;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            VerileriGoster();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Insert into Bilgiler (ID,Site,Oda,Metre,Fiyat,Blok,No,SatKira,AdSoyad,TelNo,Notlar) Values ('" + textBox1.Text.ToString() + "','" +
                comboBox1.Text.ToString() + "','" + comboBox3.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" +
                comboBox3.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + comboBox2.Text.ToString() + "','" + textBox6.Text.ToString() + "','" +
                textBox7.Text.ToString() + "','" + textBox4.Text.ToString() + "')", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            VerileriGoster();

        }
        int ID = 0;
        private void button6_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Delete from Bilgiler where ID =(" + ID + ")", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            VerileriGoster();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ID = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            comboBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[4].Text;
            comboBox3.Text = listView1.SelectedItems[0].SubItems[5].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[6].Text;
            comboBox2.Text = listView1.SelectedItems[0].SubItems[7].Text;
            textBox6.Text = listView1.SelectedItems[0].SubItems[8].Text;
            textBox7.Text = listView1.SelectedItems[0].SubItems[9].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[10].Text;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Update Bilgiler set ID='" + textBox1.Text.ToString() + "',AdSoyad='" + textBox6.Text.ToString() + "',TelNo='" +
                textBox7.Text.ToString() + "',Notlar='" + textBox4.Text.ToString() + "'where ID=" + ID + "", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            VerileriGoster();


        }
    }
}
