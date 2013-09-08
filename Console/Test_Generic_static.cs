using System;

namespace ConsoleProj
{
    class A<T>
    {
        static int cpt;
        static A() { cpt++; }

        int cpt2;
        public A() {
            cpt2++;
        }

        public int GetCpt() { return cpt; }
        public int GetCpt2() { return cpt2; }
    }

    class B { }
    class C { }

    class Test_Generic_static
    {
        public static void Run() {

            Console.WriteLine("///////////////////////////////////////////////////////////");
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);

            A<B> aB1 = new A<B>(); A<B> aB2 = new A<B>();
            A<C> aC1 = new A<C>(); A<C> aC2 = new A<C>();
            Console.WriteLine("aB1: cpt = " + aB1.GetCpt() + ", cpt2 = " + aB1.GetCpt2());
            Console.WriteLine("aB2: cpt = " + aB2.GetCpt() + ", cpt2 = " + aB2.GetCpt2());
            Console.WriteLine("aC1: cpt = " + aC1.GetCpt() + ", cpt2 = " + aC1.GetCpt2());
            Console.WriteLine("aC2: cpt = " + aC2.GetCpt() + ", cpt2 = " + aC2.GetCpt2());
        }
    }
}
