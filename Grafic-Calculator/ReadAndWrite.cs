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
        List<string> list = new List<string>();

        public void WriteToFile(decimal a, string op, decimal b, decimal res)
        {
            try
            {
                StreamWriter sWrite = new StreamWriter("Sample.txt", true) ;
                sWrite.WriteLine(a + op + b + " = " + res);
                sWrite.Close();
            }
            catch (Exception e)
            {
                list.Add("Exception write: " + e);
            }
        }

        public List<string> ShowHistory()
        {            
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
                list.Add("Exception read: " + e); //
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
