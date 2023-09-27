using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator_window : Form
    {
        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, uint wMsg, UIntPtr wParam, IntPtr lParam);

        public Calculator_window()
        {
            InitializeComponent();
            BS_LOGIC();
            SendMessage(input.Handle, 0xd3, (UIntPtr)0x3, (IntPtr)0x00040004);
        }

        int HW_WIDTH = 380, HW_HEIGHT = 526, MHW_WIDTH = 465;
        double TV_VALUE = 0;
        string REG_DOUBLE = "([-]?\\d+[.]\\d*)|(\\d+)|(-\\d+)";
        char SO_OPERATOR = ' ';
        bool B_TRUEFALSE, B_VISIBLE;

        private void standard_Click(object sender, System.EventArgs e)
        {
            Width = HW_WIDTH;
            Height = HW_HEIGHT;
            input.Width = 337;
            squareRoot.Visible = false;
            pow.Visible = false;
            ln.Visible = false;
        }

        private void scientific_Click(object sender, System.EventArgs e)
        {
            Width = MHW_WIDTH;
            Height = HW_HEIGHT;
            input.Width = 423;
            squareRoot.Visible = true;
            pow.Visible = true;
            ln.Visible = true;
        }

        void BS_LOGIC()
        {
            clear.Click += (sender, args) =>{ input.Text = "0"; SO_OPERATOR = ' '; TV_VALUE = 0; };
            back.Click += (sender, args) => {
                StringBuilder SB_BUILDER = new StringBuilder();
                for (int i = 0; i < (input.Text.Length - 1); i++)
                {
                    SB_BUILDER.Append(input.Text.ElementAt(i));
                }
                if (SB_BUILDER.ToString().Equals(""))
                {
                    input.Text = "0";
                }
                else
                {
                    input.Text = SB_BUILDER.ToString();
                }
            };
            percent.Click += (sender, args) =>
            {
                if (!Regex.IsMatch(input.Text, REG_DOUBLE) || !B_TRUEFALSE)
                    return;

                TV_VALUE = equal_calc(TV_VALUE, Double.Parse(input.Text), SO_OPERATOR);

                if (Regex.IsMatch("[-]?[\\d]+[.][0]*", TV_VALUE.ToString()))
                {
                    input.Text = ((int)TV_VALUE).ToString();
                }
                else
                {
                    input.Text = TV_VALUE.ToString();
                }
                SO_OPERATOR = '%';
                B_TRUEFALSE = false;
                B_VISIBLE = false;
            };
            divide.Click += (sendedr, args) =>
            {
                if (!Regex.IsMatch(input.Text, REG_DOUBLE))
                    return;

                if (B_TRUEFALSE)
                {
                    TV_VALUE = equal_calc(TV_VALUE, double.Parse(input.Text), SO_OPERATOR);

                    if (Regex.IsMatch("[-]?[\\d]+[.][0]*", TV_VALUE.ToString()))
                    {
                        input.Text = ((int)TV_VALUE).ToString();
                    }
                    else
                    {
                        input.Text = TV_VALUE.ToString();
                    }

                    SO_OPERATOR = '/';
                    B_TRUEFALSE = false;
                    B_VISIBLE = false;
                }
                else
                {
                    SO_OPERATOR = '/';
                }
            };
            button1.Click += (sender, args) =>
            {
                if (B_VISIBLE)
                {
                    if (Regex.IsMatch("[0]*", input.Text))
                    {
                        input.Text = "1";
                    }
                    else
                    {
                        input.Text += "1";
                    }
                }
                else
                {
                    input.Text = "1";
                    B_VISIBLE = true;
                }
                B_TRUEFALSE = true;
            };
            button2.Click += (sender, args) =>
            {
                if (B_VISIBLE)
                {
                    if (Regex.IsMatch("[0]*", input.Text))
                    {
                        input.Text = "2";
                    }
                    else
                    {
                        input.Text += "2";
                    }
                }
                else
                {
                    input.Text = "2";
                    B_VISIBLE = true;
                }
                B_TRUEFALSE = true;
            };
            button3.Click += (sender, args) =>
            {
                if (B_VISIBLE)
                {
                    if (Regex.IsMatch("[0]*", input.Text))
                    {
                        input.Text = "3";
                    }
                    else
                    {
                        input.Text += "3";
                    }
                }
                else
                {
                    input.Text = "3";
                    B_VISIBLE = true;
                }
                B_TRUEFALSE = true;
            };
            button4.Click += (sender, args) =>
            {
                if (B_VISIBLE)
                {
                    if (Regex.IsMatch("[0]*", input.Text))
                    {
                        input.Text = "4";
                    }
                    else
                    {
                        input.Text += "4";
                    }
                }
                else
                {
                    input.Text = "4";
                    B_VISIBLE = true;
                }
                B_TRUEFALSE = true;
            };
            button5.Click += (sender, args) =>
            {
                if (B_VISIBLE)
                {
                    if (Regex.IsMatch("[0]*", input.Text))
                    {
                        input.Text = "5";
                    }
                    else
                    {
                        input.Text += "5";
                    }
                }
                else
                {
                    input.Text = "5";
                    B_VISIBLE = true;
                }
                B_TRUEFALSE = true;
            };
            button6.Click += (sender, args) =>
            {
                if (B_VISIBLE)
                {
                    if (Regex.IsMatch("[0]*", input.Text))
                    {
                        input.Text = "6";
                    }
                    else
                    {
                        input.Text += "6";
                    }
                }
                else
                {
                    input.Text = "6";
                    B_VISIBLE = true;
                }
                B_TRUEFALSE = true;
            };
            button7.Click += (sender, args) =>
            {
                if (B_VISIBLE)
                {
                    if (Regex.IsMatch("[0]*", input.Text))
                    {
                        input.Text = "7";
                    }
                    else
                    {
                        input.Text += "7";
                    }
                }
                else
                {
                    input.Text = "7";
                    B_VISIBLE = true;
                }
                B_TRUEFALSE = true;
            };
            button8.Click += (sender, args) =>
            {
                if (B_VISIBLE)
                {
                    if (Regex.IsMatch("[0]*", input.Text))
                    {
                        input.Text = "8";
                    }
                    else
                    {
                        input.Text += "8";
                    }
                }
                else
                {
                    input.Text = "8";
                    B_VISIBLE = true;
                }
                B_TRUEFALSE = true;
            };
            button9.Click += (sender, args) =>
            {
                if (B_VISIBLE)
                {
                    if (Regex.IsMatch("[0]*", input.Text))
                    {
                        input.Text = "9";
                    }
                    else
                    {
                        input.Text += "9";
                    }
                }
                else
                {
                    input.Text = "9";
                    B_VISIBLE = true;
                }
                B_TRUEFALSE = true;
            };
            zero.Click += (sender, args) =>
            {
                if (B_VISIBLE)
                {
                    if (Regex.IsMatch( "[0]*",input.Text))
                    {
                        input.Text = "0";
                    }
                    else
                    {
                        input.Text += "0";
                    }
                }
                else
                {
                    input.Text = "0";
                    B_VISIBLE = true;
                }
                B_TRUEFALSE = true;
            };
            multiply.Click += (sender, args) => {
                if (!Regex.IsMatch(input.Text, REG_DOUBLE))
                    return;

                if (B_TRUEFALSE)
                {
                    TV_VALUE = equal_calc(TV_VALUE, double.Parse(input.Text), SO_OPERATOR);

                    if (Regex.IsMatch("[-]?[\\d]+[.][0]*",TV_VALUE.ToString()))
                    {
                        input.Text = ((int)TV_VALUE).ToString();
                    }
                    else
                    {
                        input.Text = TV_VALUE.ToString();
                    }

                    SO_OPERATOR = '*';
                    B_TRUEFALSE = false;
                    B_VISIBLE = false;
                }
                else
                {
                    SO_OPERATOR = '*';
                }
            };
            minus.Click += (sender, args) =>
            {
                if (!Regex.IsMatch(input.Text, REG_DOUBLE))
                {
                    return;
                }

                if (B_TRUEFALSE)
                {
                    TV_VALUE = equal_calc(TV_VALUE, double.Parse(input.Text), SO_OPERATOR);

                    if (Regex.IsMatch("[-]?[\\d]+[.][0]*", TV_VALUE.ToString()))
                    {
                        input.Text = ((int)TV_VALUE).ToString();
                    }
                    else
                    {
                        input.Text = TV_VALUE.ToString();
                    }

                    SO_OPERATOR = '-';
                    B_TRUEFALSE = false;
                    B_VISIBLE = false;
                }
                else
                {
                    SO_OPERATOR = '-';
                }
            };
            plus.Click += (sender, args) =>
            {
                if (!Regex.IsMatch(input.Text, REG_DOUBLE))
                {
                    return;
                }

                if (B_TRUEFALSE)
                {
                    TV_VALUE = equal_calc(TV_VALUE, double.Parse(input.Text), SO_OPERATOR);

                    if (Regex.IsMatch("[-]?[\\d]+[.][0]*", TV_VALUE.ToString()))
                    {
                        input.Text = ((int)TV_VALUE).ToString();
                    }
                    else
                    {
                        input.Text = TV_VALUE.ToString();
                    }

                    SO_OPERATOR = '+';
                    B_TRUEFALSE = false;
                    B_VISIBLE = false;
                }
                else
                {
                    SO_OPERATOR = '+';
                }
            };
            dot.Click += (sender, args) =>
            {
                if (B_VISIBLE)
                {
                    if (!input.Text.Contains("."))
                    {
                        input.Text += ".";
                    }
                }
                else
                {
                    input.Text = "0.";
                    B_VISIBLE = true;
                }

                B_TRUEFALSE = true;
            };
            equal.Click += (sender, args) =>
            {
                if (!Regex.IsMatch(input.Text, REG_DOUBLE))
                {
                    return;
                }

                if (B_TRUEFALSE)
                {
                    TV_VALUE = equal_calc(TV_VALUE, double.Parse(input.Text), SO_OPERATOR);

                    if (Regex.IsMatch("[-]?[\\d]+[.][0]*", TV_VALUE.ToString()))
                    {
                        input.Text = ((int)TV_VALUE).ToString();
                    }
                    else
                    {
                        input.Text = TV_VALUE.ToString();
                    }

                    SO_OPERATOR = '=';
                    B_VISIBLE = false;
                }
            };
            squareRoot.Click += (sender, args) => {
                if (!Regex.IsMatch(input.Text, REG_DOUBLE))
                {
                    return;
                }

                if (B_TRUEFALSE)
                {
                    double VALUE = double.Parse(input.Text);

                    if (VALUE >= 0)
                    {
                        TV_VALUE = Math.Sqrt(VALUE);

                        if (Regex.IsMatch("[-]?[\\d]+[.][0]*", TV_VALUE.ToString()))
                        {
                            input.Text = ((int)TV_VALUE).ToString();
                        }
                        else
                        {
                            input.Text = TV_VALUE.ToString();
                        }

                        SO_OPERATOR = '√';
                        B_VISIBLE = false;
                    }
                }

            };
            pow.Click += (sender, args) =>
            {
                if (!Regex.IsMatch(input.Text, REG_DOUBLE))
                {
                    return;
                }

                if (B_TRUEFALSE)
                {
                    TV_VALUE = equal_calc(TV_VALUE, double.Parse(input.Text), SO_OPERATOR);

                    if (Regex.IsMatch("[-]?[\\d]+[.][0]*", TV_VALUE.ToString()))
                    {
                        input.Text = ((int)TV_VALUE).ToString();
                    }
                    else
                    {
                        input.Text = TV_VALUE.ToString();
                    }

                    SO_OPERATOR = '^';
                    B_TRUEFALSE = false;
                    B_VISIBLE = false;
                }
                else
                {
                    SO_OPERATOR = '^';
                }
            };
            ln.Click += (sender, args) =>
            {
                if (!Regex.IsMatch(input.Text, REG_DOUBLE))
                {
                    return;
                }

                if (B_TRUEFALSE)
                {
                    double inputValue = double.Parse(input.Text);
                    if (inputValue > 0)
                    {
                        TV_VALUE = Math.Log(inputValue);

                        if (Regex.IsMatch("[-]?[\\d]+[.][0]*", TV_VALUE.ToString()))
                        {
                            input.Text = ((int)TV_VALUE).ToString();
                        }
                        else
                        {
                            input.Text = TV_VALUE.ToString();
                        }
                        SO_OPERATOR = 'l';
                        B_VISIBLE = false;
                    }
                }
            };
        }

        double equal_calc(double FN_NUMBER, double SN_NUMBER, char OP_OPERATOR)
        {
            switch (OP_OPERATOR) {
                case '+':
                    return FN_NUMBER + SN_NUMBER;
                case '-':
                    return FN_NUMBER - SN_NUMBER;
                case '*':
                    return FN_NUMBER * SN_NUMBER;
                case '/':
                    return FN_NUMBER / SN_NUMBER;
                case '%':
                    return FN_NUMBER % SN_NUMBER;
                case '^':
                    return Math.Pow(FN_NUMBER, SN_NUMBER);
                default:
                    return SN_NUMBER;
                }
            }
        }

}
