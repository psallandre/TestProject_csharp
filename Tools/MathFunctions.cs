using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tools
{
   public static class MathFunctions
   {
      public static int Factorial(int n) {
         if (n < 0) throw new ArgumentOutOfRangeException();
         if (n <= 1) return 1;
         int result = 1;
         for (int i = 2; i <= n; i++) {
            result *= i;
         }
         return result;
         //return i*Factorial(i-1);
      }

      public static int Fibonaci(int i) {
         if (i < 0) throw new ArgumentOutOfRangeException();
         if (i == 0) return 1;
         if (i == 1) return 1;
         return i * Fibonaci(i - 1);
      }
   }
}
