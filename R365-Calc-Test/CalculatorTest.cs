using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using R365_Calc;

namespace R365_Calc_Test
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void WorksWith1Number()
        {
            int result = Calculator.Calculate("20");
            Assert.AreEqual(result, 20);
        }

        [TestMethod]
        public void WorksWith2Numbers()
        {
            int result = Calculator.Calculate("1,5");
            Assert.AreEqual(result, 6);
        }

        [TestMethod]
        public void ShouldTreatNumbersGreaterThan1000AsInvalid()
        {
            int result = Calculator.Calculate("2,1001,6");
            Assert.AreEqual(result, 8);
        }


        [TestMethod]
        public void WorksWithMoreThan2Numbers()
        {
            int result = Calculator.Calculate("1,2,3,4,5,6,7,8,9,10,11,12");
            Assert.AreEqual(result, 78);
        }

        [TestMethod]
        public void ErrorsWithNegativeNumbersShowingNegatives()
        {
            string message = "";
            try
            {
               Calculator.Calculate("4,-3,5,-2");
            } catch (Exception e)
            {
                message = e.Message;
            }
            StringAssert.Contains(message, "[-3,-2]");
        }

        [TestMethod]
        public void TreatsEmptyNumbersAs0()
        {
            int result = Calculator.Calculate(",3");
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TreatsInvalidNumbersAs0()
        {
            int result = Calculator.Calculate("5,tytyt");
            Assert.AreEqual(result, 5);
        }

        [TestMethod]
        public void SupportsUnixNewlineAsAnAlternateDelimeter()
        {
            int result = Calculator.Calculate("1\n2,3");
            Assert.AreEqual(result, 6);
        }

        [TestMethod]
        public void SupportsWindowsNewlineAsAnAlternateDelimeter()
        {
            int result = Calculator.Calculate("1\r\n2,3");
            Assert.AreEqual(result, 6);
        }

        [TestMethod]
        public void SupportsACustom1CharacterDelimeter()
        {
            int result = Calculator.Calculate("//#\n2#5");
            Assert.AreEqual(result, 7);
            result = Calculator.Calculate("//,\n2,ff,100");
            Assert.AreEqual(result, 102);
        }

        [TestMethod]
        public void SupportsACustomDelimeterOfAnyLength()
        {
            int result = Calculator.Calculate("//[***]\n11***22***33");
            Assert.AreEqual(result, 66);
        }
    }
}
