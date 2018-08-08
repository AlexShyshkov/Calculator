using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        private bool isOperationSignPressed = false;
        private string operation = "";
        private int value = 0;
            
        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if ((CalculatorTextBox.Text == "0") || (isOperationSignPressed))
            {
                CalculatorTextBox.Clear();
            }
            isOperationSignPressed = false;
            Button button = (Button)sender;
            CalculatorTextBox.Text = CalculatorTextBox.Text + button.Text;
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            if(CalculatorTextBox.Text.Length > 0)
            {
                CalculatorTextBox.Clear();
            }
            else if (CalculatorTextBox.Text.Length == 0)
            {
                Preview.Text = "";
            }         
        }

        private void ButtonOperation_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Text;
            NotActiveOperation();
            value = int.Parse(CalculatorTextBox.Text);
            Preview.Text = value + " " + operation;
            NotActiveOperation();
            isOperationSignPressed = true;
        }

        private void ButtonResult_Click(object sender, EventArgs e)
        {
            Calculate();
            Preview.Text = "";
            ButtonResult.Enabled = false;
        }

        private void CalculatorTextBox_TextChanged(object sender, EventArgs e)
        {
            if (CalculatorTextBox.Text.Length != null )
            {
                ButtonDivide.Enabled = true;
                ButtonMultiply.Enabled = true;
                ButtonPlus.Enabled = true;
                ButtonMinus.Enabled = true;
            }
            else
            {
                ButtonDivide.Enabled = false;
                ButtonMultiply.Enabled = false;
                ButtonPlus.Enabled = false;
                ButtonMinus.Enabled = false;
            }
        }

        private void Preview_TextChanged(object sender, EventArgs e)
        {
            if (Preview.Text.Length > 0)
            {
                ButtonResult.Enabled = true;
                ButtonDivide.Enabled = false;
                ButtonMultiply.Enabled = false;
                ButtonPlus.Enabled = false;
                ButtonMinus.Enabled = false;                
            }
        }

        private void ActiveOperation()
        {
            ButtonDivide.Enabled = true;
            ButtonMultiply.Enabled = true;
            ButtonPlus.Enabled = true;
            ButtonMinus.Enabled = true;
        }

        private void Calculate()
        {
            Preview.Text = "";
            switch (operation)
            {
                case "+":
                    CalculatorTextBox.Text = (value + int.Parse(CalculatorTextBox.Text)).ToString();
                    break;
                case "-":
                    CalculatorTextBox.Text = (value - int.Parse(CalculatorTextBox.Text)).ToString();
                    break;
                case "*":
                    CalculatorTextBox.Text = (value * int.Parse(CalculatorTextBox.Text)).ToString();
                    break;
                case "/":
                    if (CalculatorTextBox.Text == "0")
                    {
                        MessageBox.Show($"Cannot divide by zero");
                    }
                    else
                    {
                        CalculatorTextBox.Text = (value / int.Parse(CalculatorTextBox.Text)).ToString();
                    }
                    break;
                default:
                    break;
            }
            isOperationSignPressed = false;
            ButtonResult.Enabled = false;
        }

        private void NotActiveOperation()
        {
            ButtonDivide.Enabled = false;
            ButtonMultiply.Enabled = false;
            ButtonPlus.Enabled = false;
            ButtonMinus.Enabled = false;
        }        
    }
}