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
    public partial class Calculater_Form1 : Form
    {
        public Calculater_Form1()
        {
            InitializeComponent();
        }

        double num1, num2, result;
        int  choice= 0;
        private void SelectedButtons(object sender, EventArgs e)
        {
            if (txtData.Text == "0")
            {
                txtData.Clear();
            }
            txtData.Text = txtData.Text + ((Button)sender).Text;//butonda ne yazılıysa TextBox a aktarır
        }

        private void btnDot_Click(object sender, EventArgs e)
        {

            if (!txtData.Text.Contains("."))
            {
                txtData.Text = txtData.Text + ".";
            }

        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            num1 = double.Parse(txtData.Text);
            txtData.Text = "0";
            choice = 1;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            num1 = double.Parse(txtData.Text);
            txtData.Text = "0";
            choice = 2;
        }

        private void btnMultiplication_Click(object sender, EventArgs e)
        {
            num1 = double.Parse(txtData.Text);
            txtData.Text = "0";
            choice = 3;
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            num1 = double.Parse(txtData.Text);
            txtData.Text = "0";
            choice = 4;
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            num1 = double.Parse(txtData.Text);
            txtData.Text = "0";
            choice = 5;
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            num2 = double.Parse(txtData.Text);
            if (choice == 1)
            {
                result = num1 + num2;
                txtData.Text = result.ToString();
            }
            if (choice == 2)
            {
                result = num1 - num2;
                txtData.Text = result.ToString();
            }
            if (choice == 3)
            {
                result = num1 * num2;
                txtData.Text = result.ToString();
            }
            if (choice == 4)
            {
                result = num1 / num2;
                txtData.Text = result.ToString("0.00");
            }
            if (choice == 5)
            {
                result = num1 % num2;
                txtData.Text = result.ToString();
            }
        }      

        private void btnC_Click(object sender, EventArgs e)
        {
            txtData.Text = "0";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtData.Text = txtData.Text.Substring(0,txtData.Text.Length-1);

            if (txtData.Text=="")
            {
                txtData.Text = "0";
            }
        }

        
    }
}
