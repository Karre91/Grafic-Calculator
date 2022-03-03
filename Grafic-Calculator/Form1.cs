using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Grafic_Calculator
{
    public partial class Form1 : Form
    {       
        static Operators operate = new Operators();
        static ReadAndWrite RandW = new ReadAndWrite();       
        Calculate calculate = new Calculate(operate, RandW);
          
        public readonly char[] ops = { '*', '-', '+', '/' };
        bool commaAllowed = true;

        public Form1()
        {
            InitializeComponent();
            AbleEqual(isTextboxReady());
        }
        private void ac_Click(object sender, EventArgs e)
        {
            textBox.Text = "0";
            AbleOp(isTextboxReady());
            AbleEqual(isTextboxReady());            
        }
        private void DEL_Click(object sender, EventArgs e) 
        {
            string tmp = textBox.Text;
            if (tmp.Length > 1)
            {
                tmp = tmp.Substring(0, tmp.Length - 1);
                textBox.Text = "";
                textBox.Text = tmp;
            }
            else if (textBox.Text.Length <= 1)
            {
                textBox.Text = "0";
            }
            AbleEqual(isTextboxReady());
            AbleOp(isTextboxReady());
            isCommaAllowed();
        }
        private void button_Click(object sender, EventArgs e)
        {        
            Button button = (Button)sender;
            char boxLast = textBox.Text.Last();
            //int a = textBox.Text.IndexOf(',', '+', '-', '*', '/');

            if (button.Text == ",")
            {                
                if (boxLast != ',' && boxLast != '+' && boxLast != '-' && boxLast != '*' && boxLast != '/')
                {
                    if (commaAllowed)
                    {
                        commaAllowed = false;
                        textBox.Text += button.Text;
                        AbleOp(isTextboxReady());
                        AbleEqual(isTextboxReady());
                    }
                }                
            }                
            else if (textBox.Text == "0")
            {
                textBox.Text = button.Text;
                AbleEqual(isTextboxReady());
                AbleOp(isTextboxReady());
            } 
            else
            {
                textBox.Text += button.Text;
                AbleOp(isTextboxReady());                
                AbleEqual(isTextboxReady());              
            }                
        }
        private void operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            commaAllowed = true;
            AbleEqual(isTextboxReady());
            if (textBox.Text == "0" && button.Text == "-")
            {
                textBox.Text = button.Text;
            }
            else if (operate.OpOk(button.Text, textBox.Text) && textBox.Text != "0")
            {
                textBox.Text += button.Text;                                          
            }
        }
        private void buttonEquals_Click(object sender, EventArgs e)
        {
            decimal res = calculate.Calc(textBox.Text);
            textBox.Text = res.ToString();

            AbleEqual(isTextboxReady());            
            AbleOp(isTextboxReady());

            //TODO om 0 efter komma, inte skriva ut.
        }
        private void Log_button_Click(object sender, EventArgs e)
        {
            Form2 historyForm = new Form2();
            historyForm.ReadList();
            historyForm.Show();
        }
        private void Void_button_Click(object sender, EventArgs e)
        {
            RandW.ClearFile();
        }
        private void AbleOp(bool a)
        {
            if (a)
            {
                buttonPlus.Enabled = false;
                buttonMinus.Enabled = false;
                buttonTimes.Enabled = false;
                buttonDivided.Enabled = false;
                buttonPlus.BackColor = Color.Firebrick;
                buttonMinus.BackColor = Color.Firebrick;
                buttonTimes.BackColor = Color.Firebrick;
                buttonDivided.BackColor = Color.Firebrick; 
            }              
            else
            {
                buttonPlus.Enabled = true;
                buttonMinus.Enabled = true;
                buttonTimes.Enabled = true;
                buttonDivided.Enabled = true;
                buttonPlus.BackColor = Color.DarkGreen;
                buttonMinus.BackColor = Color.DarkGreen;
                buttonTimes.BackColor = Color.DarkGreen;
                buttonDivided.BackColor = Color.DarkGreen;
            }
        }
        private void AbleEqual(bool a)
        {
            if (a)
            {
                buttonEquals.Enabled = true;
                buttonEquals.BackColor = Color.Green;
            }
            else
            {
                buttonEquals.Enabled = false;
                buttonEquals.BackColor = Color.Firebrick;
            }
            
        }
        private bool isTextboxReady()
        {
            string[] splitted = textBox.Text.Split(ops);
            splitted = splitted.Where(val => val != "").ToArray();

            if (splitted.Length >= 2)
            {
                return true;
            }
            return false;
        }
        private void isCommaAllowed()
        {
            string[] splitted = textBox.Text.Split(ops);
            splitted = splitted.Where(val => val != "").ToArray();

            foreach (var s in splitted)
            {
                int a = s.IndexOf(",");
                if (a == -1) { commaAllowed = true; }
                else { commaAllowed = false; }
            }
        }
    }
}