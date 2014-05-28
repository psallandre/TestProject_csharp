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

        //http://stackoverflow.com/questions/4116242/c-sharp-fibonacci-sequence-replication
        //http://www.codeproject.com/Questions/118727/fibonacci-code-in-c
        public static int Fibonaci(int i) {
            //return Fibonaci_Recursif(i);
            //return Fibonaci_Memorize(i);
            return Fibonaci_Iteratif(i);
        }

        public static int Fibonaci_Recursif(int i) {
            if (i < 0) throw new ArgumentOutOfRangeException();
            if (i <= 1) return i;
            return Fibonaci(i - 1) + Fibonaci(i - 2);
        }

        static Dictionary<int, int> fibos = new Dictionary<int, int>();
        public static int Fibonaci_Memorize(int i) {
            if (i < 0) throw new ArgumentOutOfRangeException();
            if (i <= 1) return i;
            int result;
            if (fibos.TryGetValue(i, out result))
                return result;
            else {
                result = Fibonaci_Memorize(i - 1) + Fibonaci_Memorize(i - 2);
                fibos[i] = result;
                return result;
            }
        }

        public static int Fibonaci_Iteratif(int n) {
            if (n < 0) throw new ArgumentOutOfRangeException();
            int old = 0;
            int current = 1;
            // In N steps compute Fibonacci sequence iteratively.
            for (int i = 0; i < n; i++) {
                int temp = old;
                old = current;
                current = temp + current;
            }
            return old;
        }

        public static IEnumerable<int> Fibonator_Iteratif()
        {
          //if (n < 0) throw new ArgumentOutOfRangeException();
          int old = 0;
          int current = 1;
          // In N steps compute Fibonacci sequence iteratively.
          while(true)
          {
            int temp = old;
            old = current;
            current = temp + current;
            yield return old;
          }
        }

        public static IEnumerable<int> Fibonator_Iteratif2()
        {
            //from http://en.wikipedia.org/wiki/Comparison_of_C_Sharp_and_Java
            int a = 0;
            int b = 1;
 
            while (true) {
                yield return a;
                a += b;
                yield return b;
                b += a;
            }
        }
    }
}
