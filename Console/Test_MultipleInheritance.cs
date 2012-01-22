using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.Remoting.Messaging;		//pour AsyncResult

namespace ConsoleProj
{
	interface IBase
	{
		//static IBase Create(bool isDerived, bool isImpl1);

		void fctBase();
	};

	class BaseImpl1 : IBase
	{
		protected string member;

		public BaseImpl1()
		{
			member = "BaseImpl1";
		}
		public void fctBase()
		{
			Console.WriteLine("Appel de BaseImpl1::fctBase, {0}", member);
		}
	};

	class BaseImpl2 : IBase
	{
		protected string member;

		public BaseImpl2()
		{
			member = "BaseImpl2";
		}
		public void fctBase()
		{
			Console.WriteLine("Appel de BaseImpl2::fctBase, {0}", member);
		}
	};

	interface IDerived : IBase
	{
		void fctDerived();
	};

	class DerivedImpl1 : BaseImpl1, IDerived
	{
		public DerivedImpl1() { member += "DerivedImpl1"; }
		public void fctDerived() { Console.WriteLine("Appel de DerivedImpl1::fctDerived"); }
		public new void fctBase()		{base.fctBase();}			//pas obligé en c#
	};

	class DerivedImpl2 : BaseImpl2, IDerived
	{
		public DerivedImpl2() { member += "DerivedImpl2"; }
		public void fctDerived() { Console.WriteLine("Appel de DerivedImpl2::fctDerived"); }
		public new void fctBase()		{base.fctBase();}
	};


	static public class test_MultipleInheritance
	{
		static public void test()
		{
			{
				IBase ibase1 = new BaseImpl1(); Console.Write("BaseImpl1 :"); ibase1.fctBase();
				IBase ibase2 = new BaseImpl2(); Console.Write("BaseImpl2 :"); ibase2.fctBase();
			}
			IDerived iDerived1 = new DerivedImpl1(); Console.Write("DerivedImpl1 :"); iDerived1.fctBase();
			IDerived iDerived2 = new DerivedImpl2(); Console.Write("DerivedImpl2 :"); iDerived2.fctBase();

			{
				IBase ibase1 = new DerivedImpl1(); Console.Write("DerivedImpl1 from IBase :"); ibase1.fctBase();
				IBase ibase2 = new DerivedImpl2(); Console.Write("DerivedImpl2 from IBase :"); ibase2.fctBase();
			}
		}
	}

}