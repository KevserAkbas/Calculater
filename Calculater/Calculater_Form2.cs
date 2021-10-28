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
    public partial class Calculater_Form2 : Form
    {
        public Calculater_Form2()
        {
            InitializeComponent();
        }
        double sonuc = 0;
        string operation = "";
        bool isOperationPerfomed = false;

        private void ButtonValues(object sender, EventArgs e)
        {
            if (txtData.Text == "0" || isOperationPerfomed)
            {
                txtData.Clear();
            }
            isOperationPerfomed = false;
            Button button = (Button)sender;
            if (sender.GetType() == typeof(Button))
            {

            }
            txtData.Text = txtData.Text + button.Text;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (!txtData.Text.Contains("."))
            {
                txtData.Text = txtData.Text + ".";
            }
        }

        private void operation_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (sonuc != 0)
            {
                btnEquals.PerformClick();
                operation = button.Text;
                labelCurrentOperation.Text = sonuc + " " + operation;
                isOperationPerfomed = true;
            }
            else
            {
                operation = button.Text;
                sonuc = double.Parse(txtData.Text);
                labelCurrentOperation.Text = sonuc + " " + operation;
                isOperationPerfomed = true;
            }
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "+":
                    txtData.Text = (sonuc + double.Parse(txtData.Text)).ToString();
                    break;
                case "-":
                    txtData.Text = (sonuc - double.Parse(txtData.Text)).ToString();
                    break;
                case "*":
                    txtData.Text = (sonuc * double.Parse(txtData.Text)).ToString();
                    break;
                case "/":
                    txtData.Text = (sonuc / double.Parse(txtData.Text)).ToString("0.00");
                    break;
                case "%":
                    txtData.Text = (sonuc % double.Parse(txtData.Text)).ToString("0.00");
                    break;
                default:
                    break;
            }
            sonuc = double.Parse(txtData.Text);
            labelCurrentOperation.Text = " ";

        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtData.Text = "0";
            sonuc = 0;
            labelCurrentOperation.Text = " ";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtData.Text = txtData.Text.Substring(0, txtData.Text.Length - 1);
            if (txtData.Text == "")
            {
                txtData.Text = "0";
            }
        }
    }
}
