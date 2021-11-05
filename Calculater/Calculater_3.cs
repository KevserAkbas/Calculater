using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculater
{
    public partial class Calculater_3 : Form
    {
        public Calculater_3()
        {
            InitializeComponent();
        }

        private void Calculater_3_Load(object sender, EventArgs e)
        {
            string a = "00";
            string sayilar = "0123456789";

            foreach (Control item in this.Controls)
            {
                if (item is Button) //form da kullanılan işlem buton ise if e girer
                {
                    if (sayilar.IndexOf(item.Text) != -1)// inde bizim belirlemiş olduğumuz karaktere göre 
                    {
                        item.Font = new Font("Arial", 15);
                    }
                    else
                    {
                        item.Font = new Font("Arial", 12);
                        (item as Button).FlatStyle = FlatStyle.Flat;//FlatStyle --> buton kontrollerin stilleri
                        (item as Button).FlatAppearance.BorderSize = 0; //Kenarları olmasın
                        (item as Button).BackColor = Color.FromName("Red");
                    }
                }


            }
        }

        string islem;//hangi işlemde olduğumu anlamak için
        Boolean islemSec = false;//ekran ilk açıldığında hiç bir işlem yapılmıyor
        Boolean esittir = false;
        Boolean sayiSec = false;//hangi sayı üzerine hangi işelm yapıldığı
        int sayi1 = 0;
        int sayi2 = 0;

        private void btnEquals_Click(object sender, EventArgs e)
        {
            //txtData.Text = "";//içeriğini sıfırlasın
            int sonuc = 0;
            if (islem != "")
            {
                sayi2 = Convert.ToInt32(txtData.Text);//eğer ekranda +, - gibi bir şey varsa her zaman 2.sayıya göre işlem yapılır
            }
            else
            {
                sayi2 = sayi1; //her zaman sağıma göre işlem yapıyorum.
            }
            switch (islem)
            {
                case "+":
                    sonuc = sayi1 + sayi2; break;
                case "-":
                    sonuc = sayi1 - sayi2; break;
                case "*":
                    sonuc = sayi1 * sayi2; break;
                case "/":
                    sonuc = sayi1 / sayi2; break;
                default:
                    break;
            }
            txtData.Text = (sonuc).ToString();
            sayi1 = sonuc;
            sayi2 = 0;
            esittir = true;
            lblSonuc.Text = "sayı seçili: " + sayiSec + Environment.NewLine +
                "sayı 1: " + sayi1.ToString() + Environment.NewLine +
                "sayı 2: " + sayi2.ToString() + Environment.NewLine +
                "işlem: " + islem + Environment.NewLine +
                "seçili işlem:" + islemSec;
            //Environment --> bizim kullandığımız textbox ın Environment sınıf özelliğini almasını sağlıyor.
        }

        //sayı butonları
        private void btn1_Click(object sender, EventArgs e)
        {
            Button item = (Button)sender;//sender --> bir metotda çoklu işlem yapmamızı sağlıyor.
            if (txtData.Text == "0" || islemSec) //0 veya bir işlem varsa
            {
                txtData.Text = item.Text;
            }
            else
            {
                txtData.Text += item.Text;
            }
            sayiSec = true;
            islemSec = false;
            lblSonuc.Text = "sayı seçili: " + sayiSec + Environment.NewLine +
                "sayı 1: " + sayi1.ToString() + Environment.NewLine +
                "sayı 2: " + sayi2.ToString() + Environment.NewLine +
                "işlem: " + islem + Environment.NewLine +
                "seçili işlem:" + islemSec;

        }

        //işlem butonları
        private void btnPlus_Click(object sender, EventArgs e)
        {
            Button item = (Button)sender;
            if ("+-x/".IndexOf(item.Text) != -1)
            {
                islem = item.Text;
                islemSec = true;
            }
            int sonuc = 0;
            if ((sayiSec && sayi1 == 0) || esittir)//bir sayı seçmişim sayı1 0 dır 
            {
                sayi1 = Convert.ToInt32(txtData.Text);
                txtData.Text = sayi1 + " " + islem;
            }
            else if (sayiSec && sayi2 == 0)
            {
                sayi2 = Convert.ToInt32(txtData.Text);
                txtData.Text = sayi1 + " " + sayi2.ToString() + " " + islem;
                switch (islem)
                {
                    case "+":
                        sonuc = sayi1 + sayi2; break;
                    case "-":
                        sonuc = sayi1 - sayi2; break;
                    case "x":
                        sonuc = sayi1 * sayi2; break;
                    case "/":
                        sonuc = sayi1 / sayi2; break;
                    default:
                        break;
                }
                txtData.Text = sonuc.ToString();
                sayi1 = sonuc;
                sayi2 = 0;
            }
            if (islemSec && txtData.Text != "")
            {
                txtData.Text = sonuc.ToString() + " " + islem;
            }
            sayiSec = false;
            esittir = false;
            lblSonuc.Text = "sayı 1: " + sayi1.ToString() + Environment.NewLine +
                            "sayı 2: " + sayi2.ToString() + Environment.NewLine +
                            "işlem: " + islem + Environment.NewLine;



        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtData.Text.Length==1)
            {
                txtData.Text = "0";
            }
            else
            {
                txtData.Text = txtData.Text.Substring(0, txtData.Text.Length - 1);
            }
            
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            sayi1 = 0;
            sayi2 = 0;
            esittir = false;
            sayiSec = false;
            islemSec = false;
            txtData.Text = "0";
            lblSonuc.Text = "0";
            lblSonuc.Visible = false;
        }
    }
}