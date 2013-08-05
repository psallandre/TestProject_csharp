using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tools
{
   public static class MathFunctions
   {
      public static int Factorial(int i) { 
         if(i<0) throw new ArgumentOutOfRangeException();
         if (i == 0) return 1;
         if (i == 1) return 1;
         return i*Factorial(i-1);
      }
   }
}
