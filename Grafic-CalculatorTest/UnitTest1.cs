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
            List<decimal> numbers = operatorz.SeparateNumbers(calculation);
            Assert.AreEqual(numbers[0], -3);
            Assert.AreEqual(numbers[1], -546543);

            calculation = "3-546543";
            numbers = operatorz.SeparateNumbers(calculation);
            Assert.AreEqual(numbers[0], 3);
            Assert.AreEqual(numbers[1], 546543);
        }

        [TestMethod]
        public void TestUseOperator()
        {
            string use = operatorz.UseOperator(ops);
            Assert.AreEqual(use, "-");
        }

        [TestMethod]
        public void TestOpOk()
        {
            bool answ = operatorz.OpOk("-", "3*-");
            Assert.IsFalse(answ);
            answ = operatorz.OpOk("+", "0");
            Assert.IsFalse(answ);
        }

        [TestMethod]
        public void TestWriteToFile() 
        {
            rw.WriteToFile(1, "-", 2, -1);
            List<string> history = rw.ShowHistory();
            history.Reverse();
            string l = history[1];
            Assert.AreEqual("1-2 = -1", l);
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
            rw.ClearFile();
            List<string> history = rw.ShowHistory();
            Assert.AreEqual(null,history[0]);
        }

        [TestMethod]
        public void TestCalc()
        {
            decimal result = calc.Calc("4,1 + 1");
            Assert.AreEqual(result, 5.1m);

        }
    }
}