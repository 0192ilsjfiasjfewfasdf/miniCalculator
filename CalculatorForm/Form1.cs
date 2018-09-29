using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorForm
{
    public enum Operators
    {
        Add,
        Sub,
        Multi,
        Div
    };
    
    public partial class Form1 : Form
    {
        // The place where current result is saved.
        public int Result = 0;
        // When hitting the '+' button, system check there's a new number.
        public bool isNewNum = true;
        public Operators Opt = Operators.Add;

        public Form1()
        {
            InitializeComponent();

            int number1;
        }

        public int Add(int number1, int number2)
        {
            int sum = number1 + number2;
            return sum;
        }

        public float Add2(float number1, float number2)
        {
            float sum = number1 + number2;
            return sum;
        }

        public int Sub(int number1, int number2)
        {
            int sub = number1 - number2;
            return sub;
        }

        public int Multi(int number1, int number2)
        {
            int multi = number1 * number2;
            return multi;
        }

        private void NumButton1_Click(object sender, EventArgs e)
        {
            //algothrim
            // first number = 0;
            // Input second number
            // Hit '+' button - number complete, calculate the number and variable, save the result to the variable
            // ....
            Button numButton = (Button)sender;
            SetNum(numButton.Text);
        }


        public void SetNum(string num)
        {
            if (isNewNum)
            {
                NumScreen.Text = num;
                isNewNum = false; //because from now on, it's not a new number.
            }
            else if (NumScreen.Text == "0")
            {
                NumScreen.Text = num;
            }
            else
            {
                NumScreen.Text = NumScreen.Text + num;
            }
        }

        private void NumPlus_Click(object sender, EventArgs e)
        {
            if (isNewNum == false)
            {
                int num = int.Parse(NumScreen.Text);
                if (Opt == Operators.Add)
                    Result = Add(Result, num);
                else if (Opt == Operators.Sub)
                    Result = Sub(Result, num);
                else if (Opt == Operators.Multi)
                    Result = Multi(Result, num);
                else if (Opt == Operators.Div)
                    Result = Result / num;

                NumScreen.Text = Result.ToString();
                isNewNum = true; //receive the new number from now
            }

            Button optButton = (Button) sender;
            if (optButton.Text == "+")
                Opt = Operators.Add;
            else if (optButton.Text == "-")
                Opt = Operators.Sub;
            else if (optButton.Text == "*")
                Opt = Operators.Multi;
            else if (optButton.Text == "/")
                Opt = Operators.Div;
        }

        private void NumClear_Click(object sender, EventArgs e)
        {
            Result = 0;
            isNewNum = true;
            Opt = Operators.Add;

            NumScreen.Text = "0";
        }
    }
}
