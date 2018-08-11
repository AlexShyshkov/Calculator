using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        private bool isOperationSignPressed = false;
        private string operation = "";
        private double value = 0;
            
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
            ActiveOperation();
            Button button = (Button)sender;
            CalculatorTextBox.Text = CalculatorTextBox.Text + button.Text;
            if (isOperationSignPressed)
            {
                NotActiveOperation();
                ButtonResult.Enabled = true;
            }
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            Button firstPressedButton = (Button)sender;
            Button secondPressedButton = (Button)sender;
            if (operation != string.Empty)
            {
                CalculatorTextBox.Text = CalculatorTextBox.Text + secondPressedButton.Text;
                CalculatorTextBox.Clear();
                ButtonResult.Enabled = false;
                NotActiveOperation();
            }
            else if (operation == string.Empty)
            {
                CalculatorTextBox.Text = CalculatorTextBox.Text + firstPressedButton.Text;
                CalculatorTextBox.Clear();
                ButtonResult.Enabled = false;
                NotActiveOperation();                
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
            Preview.Text = string.Empty;
            ButtonResult.Enabled = false;
            NotActiveOperation();
        }

        private void CalculatorTextBox_TextChanged(object sender, EventArgs e)
        {
            ActiveOperation();
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