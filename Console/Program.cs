using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JobTest3;

namespace ConsoleProj
{
	class Program
	{
		static void Main(string[] args)
		{

            Test_Generic_static.Run();
            Test_copy_reference.Run();
            Test_copy_struct.Run();
            Test_lambda_capture.Run();
      
      //Test_BeginInvoke.Test();
			//test_MultipleInheritance.test();

            //ProgramBench.MainBench();

            Console.WriteLine("Press any key ...");
            Console.ReadKey();
		}
	}
}
