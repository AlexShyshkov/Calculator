using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        bool isOperationSignPressed = false;
        string operation = "";
        int value;
            
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
                    calculatorTextBox.Text = (value + int.Parse(calculatorTextBox.Text)).ToString();
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
            if ((calculatorTextBox.Text == "0") || (isOperationSignPressed))
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
            if(calculatorTextBox.Text.Length > 0)
            {
                calculatorTextBox.Clear();
            }
            else if (calculatorTextBox.Text.Length == 0)
            {
                preview.Text = "";
            }
        }

        private void calculatorTextBox_TextChanged(object sender, EventArgs e)
        {
            if (calculatorTextBox.Text.Length > 0)
            {
                buttonDivide.Enabled = true;
                buttonMultiply.Enabled = true;
                buttonPlus.Enabled = true;
                buttonMinus.Enabled = true;
            }
        }

        private void preview_TextChanged(object sender, EventArgs e)
        {
            if (preview.Text.Length > 0)
            {
                buttonResult.Enabled = true;
            }
        }
    }
}