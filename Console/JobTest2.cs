using System;

namespace ConsoleProj
{
    class Toto
    {
        private readonly int m_int;
        public Toto() { }
        public Toto(int p_int) { m_int = p_int; }
        public int GetValue() { return m_int; }

        public void Display() {
            Console.WriteLine(m_int.ToString());
        }
    }
    class Main2
    {
        public static void Run() {
            var toto = new Toto();
            toto.Display();
            Func<int> f = () => toto.GetValue();
            Toto titi = toto;
            toto = new Toto(int.MinValue);
            toto.Display();
            titi.Display();
            Display(f);
        }
        public static void Display(Func<int> f) {
            Console.WriteLine("Lambda = " + f());
        }
    }
}
