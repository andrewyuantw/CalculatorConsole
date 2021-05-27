using System;
using System.Collections;
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

        // input stores the text to be displayed in the calculator's display
        string input = "";

        // Creating a BackgroundWorker thread separate to the UI thread
        BackgroundWorker workerThread = new BackgroundWorker();

        public Form1()
        {
            InitializeComponent();
            workerThread.DoWork += new DoWorkEventHandler(math_DoWork);
        }

        private void one_Click(object sender, EventArgs e)
        {
            input += "1";
            textBox1.Text += "1";
            workerThread.RunWorkerAsync();
        }

        private void two_Click(object sender, EventArgs e)
        {
            input += "2";
            textBox1.Text += "2";
            workerThread.RunWorkerAsync();
        }

        private void three_Click(object sender, EventArgs e)
        {
            input += "3";
            textBox1.Text += "3";
            workerThread.RunWorkerAsync();
        }

        private void four_Click(object sender, EventArgs e)
        {
            input += "4";
            textBox1.Text += "4";
            workerThread.RunWorkerAsync();
        }

        private void five_Click(object sender, EventArgs e)
        {
            input += "5";
            textBox1.Text += "5";
            workerThread.RunWorkerAsync();
        }

        private void six_Click(object sender, EventArgs e)
        {
            input += "6";
            textBox1.Text += "6";
            workerThread.RunWorkerAsync();
        }

        private void seven_Click(object sender, EventArgs e)
        {
            input += "7";
            textBox1.Text += "7";
            workerThread.RunWorkerAsync();
        }

        private void eight_Click(object sender, EventArgs e)
        {
            input += "8";
            textBox1.Text += "8";
            workerThread.RunWorkerAsync();
        }

        private void nine_Click(object sender, EventArgs e)
        {
            input += "9";
            textBox1.Text += "9";
            workerThread.RunWorkerAsync();
        }

        private void zero_Click(object sender, EventArgs e)
        {
            input += "0";
            textBox1.Text += "0";
            workerThread.RunWorkerAsync();
        }

        // We don't start workerThreads for operation symbols
        private void add_Click(object sender, EventArgs e)
        {
            input += "+";
            textBox1.Text += "+";
        }

        private void subtract_Click(object sender, EventArgs e)
        {
            input += "-";
            textBox1.Text += "-";
        }

        private void multiply_Click(object sender, EventArgs e)
        {
            input += "*";
            textBox1.Text += "*";
        }

        private void divide_Click(object sender, EventArgs e)
        {
            input += "/";
            textBox1.Text += "/";
        }

        // Backspace handler
        private void equals_Click(object sender, EventArgs e)
        {
            // You can't backspace if there is currently no input
            if (input.Length != 0)
            {
                input = input.Remove(input.Length - 1, 1);
                textBox1.Text = input;
            }

            char lastChar = input[input.Length - 1];

            // We don't start a workerThread if the last character is an operation
            if (lastChar.Equals('+') || lastChar.Equals('-') || lastChar.Equals('*') || lastChar.Equals('/')){
                return;
            }

            workerThread.RunWorkerAsync();

        }

        delegate void changeText(string text);
        private void SetText(string text)
        {

            if (this.resultBox.InvokeRequired)
            {
                changeText d = new changeText(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.resultBox.Text = text;
            }
        }

        private void math_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            Double answer = evaluate(input);

            SetText(answer.ToString());

        }

        // This function finds the first occurence of an operation symbol in an expression
        public static int findSymbol(String ex)
        {
            int[] positions = { ex.IndexOf('+'), ex.IndexOf('-'), ex.IndexOf('*'), ex.IndexOf('/')};
            int min = ex.Length;
            foreach (int t in positions)
            {
                if (t < min && t > -1)
                    min = t;
            }
            return (min == ex.Length) ? -1 : min;
        }

        // Evaluates a mathematical expression passed in the form of a string
        public static Double evaluate(String ex)
        {
            var numbers = new ArrayList();
            var symbols = new ArrayList();

            // Changes something like -5 to 0 - 5
            if (ex[0] == '-')
                ex = "0" + ex;
            
            int len = ex.Length;

            // this for loop would destructure an expression like 5 + 8 * 10 into
            // numbers = {5, 8, 10}
            // symbols = {+, *}

            for (int i = 0; i < len; i++)
            {
                int position = findSymbol(ex);
                if (position != -1)
                {
                    numbers.Add(Double.Parse(ex.Substring(0, position)));
                    symbols.Add(ex[position]);
                }
                else
                {
                    numbers.Add(Double.Parse(ex.Substring(0)));
                    break;
                }
                ex = ex.Substring(position + 1);
            }

            // This for loop evaluates * and / first
            // Taking our previous example of 5 + 8 * 10, we would end up with
            // numbers = {5, 80}
            // symbols = { + }

            for (int t = 0; t < symbols.Count; t++)
            {
                if (symbols[t].Equals('*'))
                {
                    double temp = (Double) numbers[t] * (Double) numbers[t + 1];
                    numbers.RemoveAt(t);
                    numbers[t] = temp;
                    symbols.RemoveAt(t);
                    t--;
                }
                else if (symbols[t].Equals('/'))
                {
                    double temp = (Double)numbers[t] / (Double)numbers[t + 1];
                    numbers.RemoveAt(t);
                    numbers[t] = temp;
                    symbols.RemoveAt(t);
                    t--;
                }
            }

            // This for-loop evaluates + and -

            for (int t = 0; t < symbols.Count; t++)
            {
                if (symbols[t].Equals('+'))
                {
                    
                    double temp = (Double)numbers[t] + (Double)numbers[t + 1];
                    Console.Write(temp.ToString());
                    numbers.RemoveAt(t);
                    numbers[t] = temp;
                    symbols.RemoveAt(t);
                    t--;
                }
                else if (symbols[t].Equals('-'))
                {
                    double temp = (Double)numbers[t] - (Double)numbers[t + 1];
                    numbers.RemoveAt(t);
                    numbers[t] = temp;
                    symbols.RemoveAt(t);
                    t--;
                }
            }

            return Convert.ToDouble(numbers[0]);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
