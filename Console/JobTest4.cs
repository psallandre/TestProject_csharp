using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleProj
{
    class Main4
    {
        public static void Run() {
            var values = new List<int>() { 100, 110, 120 };
            var funcs = new List<Func<int>>();
            foreach (var v in values)
                funcs.Add(() => v);
            foreach (var f in funcs)
                Console.WriteLine(f());
        }
    }
}
