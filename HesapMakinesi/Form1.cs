using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HesapMakimesi
{
    public partial class Form1 : Form
    {
        //Değişkenleri Tanımlıyoruz
        float sayi1, sayi2, sonuc;
        string islem;

        public Form1()
        {
            InitializeComponent();
        }

        //Sonuç Butonunun
        private void button1_Click(object sender, EventArgs e)
        {
            //Alanları kontrol ediyoruz
            if(string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!");
                return;
            }

            //Geçerli parametreleri kontrol ediyoruz
            if (!float.TryParse(textBox1.Text, out sayi1) || !float.TryParse(textBox2.Text, out sayi2))
            {
                MessageBox.Show("Lütfen geçerli sayılar girin!");
                return;
            }

            //Tür Dönüştürme
            sayi1 = float.Parse(textBox1.Text);
            sayi2 = float.Parse(textBox2.Text);
            islem = Convert.ToString(comboBox1.Text);

            //İşlem Kısmında kullanıcının seçtiği işlemi yerine getiriyoruz.
            switch (islem)
            {
                //"+" sembolü seçildiyse sayıları topluyoruz
                case "+":
                    sonuc = sayi1 + sayi2;
                    break;
                //"-" sembolü seçildiyse sayıları çıkartıyoruz
                case "-":
                    sonuc = sayi1 - sayi2;
                    break;
                //"*" sembolü seçildiyse sayıları çarpıyoruz
                case "*":
                    sonuc =  sayi1 * sayi2;
                    break;
                //"/" sembolü seçildiyse sayıları bölüyoruz
                case "/":
                    sonuc = sayi1 / sayi2;
                    break;
                //"Üs alma" Seçildiyse ilk sayıyla ikinci sayıyının üssünü alıyoruz
                case "Üs alma":
                    sonuc = 1;
                    for (int i = 0; i < sayi2; i++)
                    {
                        sonuc *= sayi1;
                    }
                    break;
                //eğer bunlardan hiçbiri seçilmediyse ekrana uyarı veriyoruz
                default:
                    MessageBox.Show("Geçersiz işlem seçimi!");
                    return;
            }

            //Alanları temizliyoruz.
            MessageBox.Show("Sonuç: " + sonuc.ToString());
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = -1;
        }
    }
}
