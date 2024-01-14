using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        double Result_Value = 0;
        string Operator_Performed = "";
        bool PerformedOp = false;
        bool ResetClicked = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            // numbers button and point
            if (textBox_Result.Text == "0" || PerformedOp || ResetClicked)
            {
                textBox_Result.Clear();
                ResetClicked = false;
            }

            PerformedOp = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!textBox_Result.Text.Contains("."))
                    textBox_Result.Text += button.Text;
            }
            else
                textBox_Result.Text += button.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Operator_click_Event(object sender, EventArgs e)
        {
            // +, -, *, / operators
            Button button = (Button)sender;

            if (PerformedOp)
            {
                Operator_Performed = button.Text;
                label_Show_Op.Text = Result_Value + " " + Operator_Performed;
            }
            else
            {
                if (Result_Value != 0)
                {
                    CalculateResult();
                    Operator_Performed = button.Text;
                    label_Show_Op.Text = Result_Value + " " + Operator_Performed;
                }
                else
                {
                    Result_Value = double.Parse(textBox_Result.Text);
                    Operator_Performed = button.Text;
                    label_Show_Op.Text = Result_Value + " " + Operator_Performed;
                }

                PerformedOp = true; // Set PerformedOp to true after the operation
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // CLEAR ENTRY BUTTON
            textBox_Result.Text = "0";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // CLEAR BUTTON
            textBox_Result.Text = "0";
            Result_Value = 0;
            Operator_Performed = "";
            label_Show_Op.Text = "";
            ResetClicked = true;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            // EQUALS BUTTON
            CalculateResult();
            label_Show_Op.Text = "";
            PerformedOp = true;
            ResetClicked = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // Toggle the sign of the displayed value
            if (textBox_Result.Text != "0")
            {
                double currentValue = double.Parse(textBox_Result.Text);
                textBox_Result.Text = (-currentValue).ToString();

                // Update Result_Value if it was used in a previous operation
                if (PerformedOp)
                {
                    Result_Value = -currentValue;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Other initialization code...

            // Wire up the Click event for button11
            button11.Click += button11_Click;
        }

        private void textBox_Result_TextChanged(object sender, EventArgs e)
        {

        }

        private void CalculateResult()
        {
            double currentInput = double.Parse(textBox_Result.Text);

            switch (Operator_Performed)
            {
                case "+":
                    Result_Value += currentInput;
                    break;

                case "-":
                    Result_Value -= currentInput;
                    break;

                case "×":
                    Result_Value *= currentInput;
                    break;

                case "÷":
                    if (currentInput != 0)
                        Result_Value /= currentInput;
                    else
                        MessageBox.Show("Cannot divide by zero.");
                    break;

                default:
                    Result_Value = currentInput;
                    break;
            }

            textBox_Result.Text = Result_Value.ToString();
        }
    }
}
