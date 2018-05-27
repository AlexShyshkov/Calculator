using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        int value ;
        string operation = "";
        bool isOperationSignPressed = false;
            
        public CalculatorForm()
        {
            InitializeComponent();
        }

            private void Calculate()
        {
            preview.Text = "";
            switch (operation)
            {
                case "+":
                    calculatorTextBox.Text = (value+ int.Parse(calculatorTextBox.Text)).ToString();
                    break;
                case "-":
                    calculatorTextBox.Text = (value - int.Parse(calculatorTextBox.Text)).ToString();
                    break;
                case "*":
                    calculatorTextBox.Text = (value * int.Parse(calculatorTextBox.Text)).ToString();
                    break;
                case "/":
                    if (calculatorTextBox.Text == "0")
                    {
                        MessageBox.Show($"Cannot divide by zero");
                    }
                    else
                    {
                        calculatorTextBox.Text = (value / int.Parse(calculatorTextBox.Text)).ToString();
                    }
                    break;
                default:
                    break;
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            if ((calculatorTextBox.Text == "0")||(isOperationSignPressed))
            {
                calculatorTextBox.Clear();
            }
            isOperationSignPressed = false;
            Button button = (Button)sender;
            calculatorTextBox.Text = calculatorTextBox.Text + button.Text;

        }

        private void buttonOperation_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Text;
            value = int.Parse(calculatorTextBox.Text);
            isOperationSignPressed = true;
            preview.Text = value + " " + operation;
        }

        private void buttonResult_Click(object sender, EventArgs e)
        {
            Calculate();
            preview.Text = "";
        }
        
        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (calculatorTextBox.Text == null)
            {
                preview.Text = "";
            }
            else if(calculatorTextBox.Text != null)
            {
                calculatorTextBox.Clear();
                preview.Text = "";
            }
        }
    }
}