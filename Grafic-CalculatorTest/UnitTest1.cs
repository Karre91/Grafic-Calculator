using Microsoft.VisualStudio.TestTools.UnitTesting;
using Grafic_Calculator;
using System.Collections.Generic;

namespace Grafic_CalculatorTest
{
    [TestClass]
    public class UnitTest1
    {
        static Operators operatorz = new Operators();
        List<char> ops = new List<char>();

        static ReadAndWrite rw = new ReadAndWrite();

        Calculate calc = new Calculate(operatorz, rw);

        [TestMethod]
        public void TestFindOperators()
        {            
            ops = operatorz.FindOperators("-75*-45678");
            Assert.AreEqual(ops.Count, 3);
        }

        [TestMethod]
        public void TestIsNumberNegative()
        {
            string calculation = "-3--546543";
            List<decimal> numbers = operatorz.IsNumberNegative(calculation);
            Assert.AreEqual(numbers[0], -3);
            Assert.AreEqual(numbers[1], -546543);
        }

        [TestMethod]
        public void TestUseOperator()
        {
            string use = operatorz.UseOperator(ops);
            Assert.AreEqual(use, "*");
        }

        [TestMethod]
        public void TestOpOk()
        {            
            Assert.IsTrue(operatorz.OpOk("-", "3*-"));
        }

        [TestMethod]
        public void TestWriteToFile() // Hjälp
        {
            rw.WriteToFile(1, "-", 2, -1);
            List<string> history = rw.ShowHistory();
            Assert.AreEqual(history.Contains, "1-2=-1");
        }

        [TestMethod]
        public void TestShowHistory() // Hjälp
        {
            List<string> history = rw.ShowHistory();
            Assert.IsNotNull(history);              
        }
        
        [TestMethod]
        public void TestClearFile() // Hjälp
        {
            //rw.ClearFile();
            List<string> history = rw.ShowHistory();
            Assert.AreEqual("","");
        }

        [TestMethod]
        public void TestCalc() // Fel variabeltyp vid användning av "," men uträkningen är rätt
        {
            decimal result = calc.Calc("43,1 + 1");
            Assert.AreEqual(result, 44.1);

        }
    }
}