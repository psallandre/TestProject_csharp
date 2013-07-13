using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleProj;

namespace UnitTestProject1
{
   [TestClass]
   public class UnitTest1
   {
      [TestMethod]
      [ExpectedException(typeof(ArgumentOutOfRangeException))]
      public void FactorialShouldThrowIfNegatif() {
         MathFunctions.Factorial(-1);
      }

      [TestMethod]
      public void FactorialShouldbeOk(int param, int result) {
         Assert.AreEqual(MathFunctions.Factorial(param), param);
      }
   }
}
