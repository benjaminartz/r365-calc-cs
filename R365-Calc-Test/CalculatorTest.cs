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
            int result = Calculator.Calculate("1,5000");
            Assert.AreEqual(result, 5001);
        }

        [TestMethod]
        public void WorksWithMoreThan2Numbers()
        {
            int result = Calculator.Calculate("1,2,3,4,5,6,7,8,9,10,11,12");
            Assert.AreEqual(result, 78);
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
