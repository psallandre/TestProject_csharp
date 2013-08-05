using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tools;

namespace Tools.Test
{
   [TestClass]
   public class MathFunctionsTest
   {
      [TestMethod]
      [ExpectedException(typeof(ArgumentOutOfRangeException))]
      public void FactorialShouldThrowIfNegatif() {
         MathFunctions.Factorial(-1);
      }

      [TestMethod]
      public void FactorialShouldbeOkFor() {
         FactorialShouldbeOk(1, 0);
         FactorialShouldbeOk(1, 1);
         FactorialShouldbeOk(2, 2);
         FactorialShouldbeOk(6, 3);
         FactorialShouldbeOk(24, 4);
      }

      [TestMethod]
      public void FactorialShouldbeOk(int expected, int param) {
         Assert.AreEqual(expected, MathFunctions.Factorial(param));
      }
   }
}
