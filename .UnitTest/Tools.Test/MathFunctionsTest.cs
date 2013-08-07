using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tools;
using System.Diagnostics;

namespace Tools.Test
{
   [TestClass]
   public class MathFunctionsTest
   {
      #region Factorial
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
      public void FactorialShouldbeOkForN() {
         int n = 100;
         Assert.AreEqual(MathFunctions.Factorial(n-1)*n, MathFunctions.Factorial(n));
      }

      [TestMethod]
      public void FactorialShould_BeFast() {
         //Will fail if Factorial is recursive
         int n = 40000000;
         var sw = new Stopwatch();
         sw.Start();
         MathFunctions.Factorial(n);
         sw.Stop();
         Assert.IsTrue(sw.ElapsedMilliseconds < 500);
      }

      public void FactorialShouldbeOk(int expected, int param) {
         Assert.AreEqual(expected, MathFunctions.Factorial(param));
      }
      #endregion

      #region Fibonaci
      [TestMethod]
      [ExpectedException(typeof(ArgumentOutOfRangeException))]
      public void FibonaciShouldThrowIfNegatif() {
         MathFunctions.Fibonaci(-1);
      }

      [TestMethod]
      public void FibonaciShouldbeOkFor() {
         FibonaciShouldbeOk(1, 0);
         //FibonaciShouldbeOk(1, 1);
         //FibonaciShouldbeOk(2, 2);
         //FibonaciShouldbeOk(6, 3);
         //FibonaciShouldbeOk(24, 4);
      }

      public void FibonaciShouldbeOk(int expected, int param) {
         Assert.AreEqual(expected, MathFunctions.Fibonaci(param));
      }
      #endregion
   }
}
