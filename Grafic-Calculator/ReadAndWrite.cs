using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Grafic_Calculator
{
    public class ReadAndWrite
    {
        public void WriteToFile(decimal a, string op, decimal b, decimal res)
        {
            StreamWriter sWrite = new StreamWriter("Sample.txt", true);

            try
            {
                sWrite.WriteLine(a + op + b + " = " + res);
            }
            catch (Exception e)
            {
                //list.Add("Exception: " + e);  // Kast här??
            }
            sWrite.Close();
        }

        public List<string> ShowHistory() // EXEPTION FIXA
        {
            List<string> list = new List<string>();
            string line;
            try
            {
                StreamReader sRead = new StreamReader("Sample.txt", true);

                line = sRead.ReadLine();
                list.Add(line);
                while (line != null)
                {
                    line = sRead.ReadLine();
                    list.Add(line);
                }
                sRead.Close();

            }
            catch (Exception e)
            {
                list.Add("Exception: " + e);
            }
            return list;
        }

        public void ClearFile()
        {
            StreamWriter sClear = new StreamWriter("Sample.txt", false);
            sClear.Write("");
            sClear.Close();
        }
    }
}
