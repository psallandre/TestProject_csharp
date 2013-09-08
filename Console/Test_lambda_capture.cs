using System;
using System.Collections.Generic;

namespace ConsoleProj
{
    class Test_lambda_capture
    {
        public static void Run() {
            Console.WriteLine("///////////////////////////////////////////////////////////");
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
            
          
            var values = new List<int>() { 100, 110, 120 };
            var funcs = new List<Func<int>>();
            foreach (var v in values)
                funcs.Add(() => v);
            foreach (var f in funcs)
                Console.WriteLine(f());
        }
    }
}
