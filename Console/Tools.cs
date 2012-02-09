using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
	public class Tools
	{
		//Smacchia p 508
		public static unsafe void ToUpper(string str)
		{
			fixed (char* s = str)
				for (char* p = s; *p != 0; ++p)
					//*p = Char.ToUpper(*p);			//OK
					*p = char.ToUpper(*p);
		}
	}
}
