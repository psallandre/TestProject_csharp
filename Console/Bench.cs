using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace ConsoleProj
{
  static class ProgramBench
  {
    static ReaderWriterLock _lock = new ReaderWriterLock();

    static LockItSelf _lockItSelf = new LockItSelf();


    static public void MainBench()
    {
      TestInstruction(VOID_INSTRUCTION, "Reference delegate");
      TestInstruction(delegate { new Object(); }, "create instance");
      TestInstruction(delegate { if (true) { new Object(); } }, "if + create instance");
      TestInstruction(delegate   {   new DateTime(1000,1,1);  }, "create DateTime");
      TestInstruction(delegate   {   s_int = 19589;  }, "create int");
      TestInstruction(delegate { s_nullableInt = 19589; }, "create Nullable int");
      TestInstruction(delegate { _lock.AcquireReaderLock( 100 ); _lock.ReleaseReaderLock();}, "acquire / release readerLock");
      TestInstruction(delegate { _lock.AcquireWriterLock(100); _lock.ReleaseWriterLock(); }, "acquire / release writerLock");
      TestInstruction(delegate { lock (s_object) { } }, "lock");
      TestInstruction(delegate { using (new LoggedLockClass(s_object)) { } }, "LoggedLockClass");
      TestInstruction(delegate { using (_lockItSelf.Lock()) { } }, "LockItSelf");
      TestInstruction(delegate { using (new LoggedLockStruct(s_object)) { } }, "LoggedLockStruct");
      TestInstruction(delegate { try { new Object(); } catch { new Object(); } finally { new Object(); } }, "try catch");
      //Very slow !!!
      TestInstruction(delegate { try { throw new Exception(); } catch { new Object(); } finally { new Object(); } }, "try throws catch");
      TestInstruction(delegate { _dico.Add(s_int++,null);}, "Add Key in dictionary");


      TestInstruction(delegate { s_impl.Meth(); }, "Call method directly");
      TestInstruction(delegate { s_interf.Meth(); }, "Call method with interface");
    }

    private static Impl s_impl =new Impl();
    private static INterf s_interf = new Impl();

    private static Object s_object = new object();
    private static int s_int;
    private static int? s_nullableInt;

    private const int NB_ITERATIONS = 100;
    private static long s_reference;
    private static readonly Dictionary<int,Object> _dico = new Dictionary<int, object>();


    static void TestInstruction(TestInstructionDelegate instruction, String instName)
    {
      GC.Collect();
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();
      for (int i = 0; i < NB_ITERATIONS; i++)
      {
        instruction();
      }
      stopwatch.Stop();
      long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
      Console.WriteLine(instName.PadRight(40) + " " + (elapsedMilliseconds / ((double)NB_ITERATIONS/(double)1000000)) + " nano-second/Operation");
    }

    public delegate void TestInstructionDelegate();
    static readonly TestInstructionDelegate VOID_INSTRUCTION = delegate { };

  }


  interface INterf
  {
    void Meth();
  }

  class Impl : INterf
  {
    private int _i;
    public void Meth()
    {
      _i = 0;
    }
  }



  public class LockItSelf : IDisposable
  {
    private bool _isEntered;

    public LockItSelf Lock()
    {
      _isEntered = Monitor.TryEnter(this, 10000);
      if (!_isEntered)
      {
        //LOG !
        throw new TimeoutException();
      }
      return this;
    }


    public void Dispose()
    {
      if (_isEntered)
      {
        Monitor.Exit(this); //A DEBUGGER
      }
    }
  }



   public class LoggedLockClass : IDisposable
  {
     private static readonly LoggedLockClass[] ARRAY = new LoggedLockClass[10000];
     private static int compteur = 0;

     private readonly Object _ressource;

    public LoggedLockClass(Object ressource )
    {
      bool isEntered = Monitor.TryEnter(ressource, 10000);
      if (isEntered)
      {
        _ressource = ressource;
      }
      else
      {
        //LOG !
        throw new TimeoutException();
      }
    }

    public void Dispose()
    {
      if ( _ressource != null)
      {
        Monitor.Exit(_ressource);
      }
    }
  }

   public struct LoggedLockStruct : IDisposable
   {
     private Object _ressource;

     public LoggedLockStruct(Object ressource)
     {
       bool isEntered = Monitor.TryEnter(ressource, 10000);
       if (isEntered)
       {
         _ressource = ressource;
       }
       else
       {
         //LOG !
         throw new TimeoutException();
       }
     }

     public void Dispose()
     {
       if (_ressource != null)
       {
         Monitor.Exit(_ressource);
         _ressource = null;
       }
     }
   }
}
