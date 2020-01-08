using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using R365_Calc;

namespace R365_Calc_Test
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void ThrowsErrorWithMoreThan2Numbers()
        {
            string message = "";
            try
            {
                int result = Calculator.Calculate("1,2,3");
            } catch (Exception e) {
                message = e.Message;
            }
            Assert.AreEqual(message, "Max of 2 numbers exceeded");
        }

        [TestMethod]
        public void WorksWith1Number()
        {
            int result = Calculator.Calculate("20");
            Assert.AreEqual(result, 20);
        }

        [TestMethod]
        public void WorksWith2Numbers()
        {
            int result = Calculator.Calculate("1,5000");
            Assert.AreEqual(result, 5001);
        }

        [TestMethod]
        public void WorksWithNegativeNumbers()
        {
            int result = Calculator.Calculate("4,-3");
            Assert.AreEqual(result, 1);
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
    }
}
