using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
	class Test_Covariance
	{
		//http://channel9.msdn.com/blogs/matthijs/c-40-and-beyond-by-anders-hejlsberg
		//Attention avec IEnumerable<> on ne peut pas modifier la collection
		static void func(IEnumerable<object> list)
		{
			foreach (var item in list)
				Console.WriteLine(item.ToString());
		}
		static public void Test_Cov()
		{
			List<string> strings = new List<string>();
			strings.Add("str1");
			//func(strings);
		}

		//exemple avec ma propre classe
		interface IBase<T>
		{
			void foo();
			void foo2();
		}
		class Base<T>: IBase<T>
		{
			public void foo()
			{
				Console.WriteLine("Base.foo");
			}
			public virtual void foo2()
			{
				Console.WriteLine("Base.foo2");
			}
		}

		class Derived<T> : Base<T>
		{
			public override void foo2()
			{
				Console.WriteLine("Derived.foo2");
			}
		}

		static void Func(IBase<Object> item)
		{
			item.foo();
			item.foo2();
		}

		static public void Test_Cov2()
		{
			//bof ne fait pas appel à la covariance ici
			Base<Object> item = new Base<object>();
			Func(item);

			Derived<Object> item2 = new Derived<object>();
			Func(item2);
		}

	}
}
