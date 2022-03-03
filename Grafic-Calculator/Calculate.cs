using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Grafic_Calculator
{
    public class Calculate
    {
        Operators Op;
        ReadAndWrite RW;        
        private decimal res;

        public Calculate(Operators op, ReadAndWrite rw)
        {
            this.Op = op;      
            this.RW = rw;
        }

        public decimal Calc(string box)
        {
            List<char> UsedOps = Op.FindOperators(box);
            List<decimal> Numb = Op.SeparateNumbers(box);
            decimal a = Math.Round(Numb[0], 6);
            decimal b = Math.Round(Numb[1], 6);
            string op = Op.UseOperator(UsedOps);
            switch (op)
            {
                case "*":
                    res = a * b;
                    break;
                case "/":
                    res = a / b;
                    break;
                case "+":
                    res = a + b;
                    break;
                case "-":
                    res = a - b;                  
                    break;
            }
            res = Math.Round(res,6);
            RW.WriteToFile(a, op, b, res);            
            return res;
        }      
    }
}