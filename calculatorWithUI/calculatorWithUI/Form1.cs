using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculatorWithUI
{
    public partial class Form1 : Form
    {
        double a = 0;
        double b = 0;
        string operation = "";
        double total = 0.0;
        string input = "";
        Boolean newInput = true;
        Boolean divideByZero = false;
        Boolean keepGivingError = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void one_Click(object sender, EventArgs e)
        {
            if (newInput)
            {
                textBox1.Text = "";
                input = "";
                newInput = false;
                divideByZero = false;
            }
            input += "1";
            textBox1.Text += "1";
        }

        private void two_Click(object sender, EventArgs e)
        {
            if (newInput)
            {
                textBox1.Text = "";
                input = "";
                newInput = false;
                divideByZero = false;
            }
            input += "2";
            textBox1.Text += "2";
        }

        private void three_Click(object sender, EventArgs e)
        {
            if (newInput)
            {
                textBox1.Text = "";
                input = "";
                newInput = false;
                divideByZero = false;
            }
            input += "3";
            textBox1.Text += "3";
        }

        private void four_Click(object sender, EventArgs e)
        {
            if (newInput)
            {
                textBox1.Text = "";
                input = "";
                newInput = false;
                divideByZero = false;
            }
            input += "4";
            textBox1.Text += "4";
        }

        private void five_Click(object sender, EventArgs e)
        {
            if (newInput)
            {
                textBox1.Text = "";
                input = "";
                newInput = false;
                divideByZero = false;
            }
            input += "5";
            textBox1.Text += "5";
        }

        private void six_Click(object sender, EventArgs e)
        {
            if (newInput)
            {
                textBox1.Text = "";
                input = "";
                newInput = false;
                divideByZero = false;
            }
            input += "6";
            textBox1.Text += "6";
        }

        private void seven_Click(object sender, EventArgs e)
        {
            if (newInput)
            {
                textBox1.Text = "";
                input = "";
                newInput = false;
                divideByZero = false;
            }
            input += "7";
            textBox1.Text += "7";
        }

        private void eight_Click(object sender, EventArgs e)
        {
            if (newInput)
            {
                textBox1.Text = "";
                input = "";
                newInput = false;
                divideByZero = false;
            }
            input += "8";
            textBox1.Text += "8";
        }

        private void nine_Click(object sender, EventArgs e)
        {
            if (newInput)
            {
                textBox1.Text = "";
                input = "";
                newInput = false;
                divideByZero = false;
            }
            input += "9";
            textBox1.Text += "9";
        }

        private void zero_Click(object sender, EventArgs e)
        {
            if (newInput)
            {
                textBox1.Text = "";
                input = "";
                newInput = false;
                divideByZero = false;
            }
            input += "0";
            textBox1.Text += "0";
        }

        private void equals_Click(object sender, EventArgs e)
        {
            b = Int32.Parse(input);
            if (keepGivingError)
            {
                textBox1.Text = "Can't divide by zero";
                divideByZero = true;
                newInput = true;
                return;
            }
            switch (operation)
            {
                case "+" :
                    total = a + b;
                    textBox1.Text = total.ToString();
                    input = total.ToString();
                    newInput = true;
                    break;
                case "-":
                    total = a - b;
                    textBox1.Text = total.ToString();
                    input = total.ToString();
                    newInput = true;
                    break;
                case "*":
                    total = a * b;
                    textBox1.Text = total.ToString();
                    input = total.ToString();
                    newInput = true;
                    break;
                case "/":
                    if (b == 0)
                    {
                        textBox1.Text = "Can't divide by zero";
                        newInput = true;
                        divideByZero = true;
                    } else
                    {
                        total = a / b;
                        textBox1.Text = total.ToString();
                        input = total.ToString();
                        newInput = true;
                    }
                    
                    break;
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            keepGivingError = (divideByZero) ? true : false;
            a = Double.Parse(input);
            operation = "+";
            input = "";
            newInput = true;
        }

        private void subtract_Click(object sender, EventArgs e)
        {
            keepGivingError = (divideByZero) ? true : false;
            
            a = Double.Parse(input);
            operation = "-";
            input = "";
            newInput = true;
        }

        private void multiply_Click(object sender, EventArgs e)
        {
            keepGivingError = (divideByZero) ? true : false;
            a = Double.Parse(input);
            operation = "*";
            input = "";
            newInput = true;
        }

        private void divide_Click(object sender, EventArgs e)
        {
            keepGivingError = (divideByZero) ? true : false;
            a = Double.Parse(input);
            operation = "/";
            input = "";
            newInput = true;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
