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
        // a is the first operand
        double a = 0;

        // b is the second operand
        double b = 0;

        // operation can be +, -, *, or /
        string operation = "";

        double total = 0.0;

        // input stores the text to be displayed in the calculator's display
        string input = "";

        // when newInput is true, we clear the current calculator's display
        // For example, if the display if 57 right now and newInput is true, when we hit
        // 4, we get 4 instead of 574
        Boolean newInput = true;

        // These two booleans are used to handle division by zero errors
        Boolean divideByZero = false;
        Boolean keepGivingError = false;

        // Creating a BackgroundWorker thread separate to the UI thread
        BackgroundWorker workerThread = new BackgroundWorker();

        public Form1()
        {
            InitializeComponent();
            workerThread.DoWork += new DoWorkEventHandler(math_DoWork);
        }

        /* 
         To clarify, regarding division by zero, my calculator operates like this:
        If you divide a number by zero, you will get a "Cannot Divide by Zero" message.
        If you immediately do an operation, (ex. hit + and 6) you will get a "Cannot Divide by Zero" message again.
        However, if you type a number and do an operation (hit 5 and + and 6), you will get your desired answer
         */

        private void one_Click(object sender, EventArgs e)
        {
            if (newInput)
            {
                // If newInput is true, then we have to clear our current calculator display before adding new inputs
                textBox1.Text = "";
                input = "";
                newInput = false;

                // divideByZero is set to false since it is valid to enter a number after getting a divide by zero error. 
                // We only keep giving errors if you do an operation immediately after getting a divide by zero error.
                divideByZero = false;
            }
            input += "1";
            textBox1.Text += "1";
        }

        // The other button handlers for the number button handlers are the same as one_Click, so I will only comment one_Click

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

        private void add_Click(object sender, EventArgs e)
        {
            keepGivingError = (divideByZero) ? true : false;

            // Parses the input string into a double for calculation
            a = Double.Parse(input);
            operation = "+";

            // Resets the input string 
            input = "";
            newInput = true;
        }

        // subtract_Click, multiply_Click, and divide_Click operate the same way as add_Click
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

        private void equals_Click(object sender, EventArgs e)
        {

            // Parses the input string into a double
            b = Double.Parse(input);

            if (keepGivingError)
            {
                textBox1.Text = "Can't divide by zero";
                divideByZero = true;
                newInput = true;
                return;
            }

            // Starts the workerThread
            workerThread.RunWorkerAsync();

        }

        delegate void changeText(string text);
        private void SetText(string text)
        {

            if (this.textBox1.InvokeRequired)
            {
                changeText d = new changeText(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textBox1.Text = text;
            }
        }

        private void math_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            switch (operation)
            {
                case "+":
                    total = a + b;
                    SetText(total.ToString());
                    input = total.ToString();
                    newInput = true;
                    break;
                case "-":
                    total = a - b;
                    SetText(total.ToString());
                    input = total.ToString();
                    newInput = true;
                    break;
                case "*":
                    total = a * b;
                    SetText(total.ToString());
                    input = total.ToString();
                    newInput = true;
                    break;
                case "/":
                    if (b == 0)
                    {
                        SetText("Can't divide by zero");
                        newInput = true;
                        divideByZero = true;
                    }
                    else
                    {
                        total = a / b;
                        SetText(total.ToString());
                        input = total.ToString();
                        newInput = true;
                    }
                    break;
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
