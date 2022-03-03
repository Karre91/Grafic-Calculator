using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Grafic_Calculator
{
    public class Operators
    {
        public readonly char[] ops = { '*', '-', '+', '/' };
        

        public List<char> FindOperators(string box) // REGEX?
        {
            List<char> UsedOperators = new List<char>();
            for (int i = 0; i < box.Length; i++)
            {
                for (int j = 0; j < ops.Length; j++)
                {
                    if (box[i] == ops[j])
                    {
                        UsedOperators.Add(ops[j]);
                    }
                }
            }
            return UsedOperators;
        }
        public List<decimal> SeparateNumbers(string box) 
        {
            decimal a;
            decimal b;
            List<decimal> Nr = new List<decimal>();
            int r = 0;      
            string[] splitted = box.Split(ops);

            if (splitted[r] == "")
            {
                r++;
                a = decimal.Parse(splitted[r]);
                a *= -1;
                r++;
                if (splitted[r] == "")
                {
                    r++;
                    b = decimal.Parse(splitted[r]);
                    b *= -1;
                }
                else
                {
                    b = decimal.Parse(splitted[r]);
                }
            }
            else
            {
                a = decimal.Parse(splitted[r]);
                r++;
                if (splitted[r] == "")
                {
                    r++;
                    b = decimal.Parse(splitted[r]);
                    b *= -1;
                }
                else
                {
                    b = decimal.Parse(splitted[r]);
                }                
            }            
            Nr.Add(a);
            Nr.Add(b);                     
            return Nr;
        }
        public string UseOperator(List<char> UsedOps)
        {
            string op;
            UsedOps.RemoveAll(o => o == '-');
            if (UsedOps.Count == 0)
            {
                op = "-";
                return op;
            }                       
            return op = UsedOps[0].ToString();
        }
        public bool OpOk(string op, string box)
        {            
            char tmpOp = Convert.ToChar(op);

            if (ops.Contains(box.Last()))
            {
                if (tmpOp == '-')
                {
                    if (box.Last() == '-')
                    {
                        if (box.Length < 2)
                        {
                            return false;
                        }
                        if (box[box.Length - 1] == '-' && box[box.Length - 2] == '-')
                        {
                            return false;
                        }
                        else if (box[box.Length - 1] == '-' && ops.Contains(box[box.Length - 2]))
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
                else 
                {
                    return false;
                }                
            }
            return true;
        }       
    }   
}
