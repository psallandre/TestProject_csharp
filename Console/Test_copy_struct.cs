using System;

namespace JobTest3
{
    struct Toto
    {
        private int m_int;
        public void Modify(int p_int) { m_int = p_int; }
        public int GetValue() {
            return m_int;
        }
        public void Display() {
            Console.WriteLine(m_int.ToString());
        }
    }
    class Test_copy_struct
    {
        public static void Run() {
            Console.WriteLine("///////////////////////////////////////////////////////////");
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);

            var toto = new Toto();
            toto.Display();
            Func<int> f = () => toto.GetValue();
            Toto titi = toto;
            toto.Modify(int.MinValue);
            toto.Display();
            titi.Display();
            Display(f);
        }
        public static void Display(Func<int> f) {
            Console.WriteLine("Lambda = " + f());
        }
    }
}
