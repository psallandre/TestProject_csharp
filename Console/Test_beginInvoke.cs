﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.Remoting.Messaging;		//pour AsyncResult

namespace ConsoleProj
{
	static public class Test_BeginInvoke
	{
		static void WriteLineWithThreadId(string format, params object[] arg)
		{
			Console.Write("Thread {0}. ", Thread.CurrentThread.ManagedThreadId);
			Console.WriteLine(format, arg);
		}
		static void FuncA()
		{
			WriteLineWithThreadId("FuncA");
		}

		static public void Test()
		{
			WriteLineWithThreadId("/////////////////// Appels directs");
			Func(FuncA);

			Action caller = FuncA;
			Func(caller);

			Action caller2 = new Action(FuncA);
			Func(caller2);

			Console.WriteLine("\n");
			WriteLineWithThreadId("/////////////////// Appels synchrones, delegate anonymous & lambda");
			Func(delegate { WriteLineWithThreadId("Anonymous delegate called"); });
			Func(() => { WriteLineWithThreadId("Lambda called"); });

			Console.WriteLine("\n");
			WriteLineWithThreadId("/////////////////// Appels synchrones, lambda, avec exception");
			try
			{
				Func(() => { throw new Exception("Exception raised"); });
			}
			catch (Exception e)
			{
				WriteLineWithThreadId(e.ToString());
			}

			Console.WriteLine("\n");
			WriteLineWithThreadId("/////////////////// Appels Asynchrones, delegate anonymous & lambda");
			FuncAsync(delegate { WriteLineWithThreadId("Anonymous delegate called"); });
			FuncAsync(() => { WriteLineWithThreadId("Lambda called"); });

			Thread.Sleep(200);
			Console.WriteLine("\n");
			WriteLineWithThreadId("/////////////////// Appels Asynchrones, lambda, avec exception");
			FuncAsync(() => { WriteLineWithThreadId("Lambda called"); throw new Exception("Exception raised"); });			//try/catch inutile, l'exception est levée dans le endinvoke
		}

		static void Func(System.Action f)
		{
			TryCatchFunc(f);
		}

		static void TryCatchFunc(System.Action f)
		{
			try
			{
				f();
			}
			catch (Exception ex)
			{
				WriteLineWithThreadId("Exception" + ex.ToString());

			}
		}

		//ThreadPool threads are background threads, which do not keep the application running if the main thread ends
		//http://127.0.0.1:47873/help/1-4780/ms.help?method=page&id=41972034-92ED-450A-9664-AB93FCC6F1FB&topicversion=100&topiclocale=EN-US&SQM=1&product=VS&productVersion=100&locale=EN-US

		static void FuncAsync(System.Action f)
		{
			//f.Invoke();
			AsyncCallback cb = FuncAsyncCB;	//new ?
      Object argsOrUserState = null;
			IAsyncResult result = f.BeginInvoke(cb, argsOrUserState);

			//var handle = result.AsyncWaitHandle;
			//handle.WaitOne();
			//f.EndInvoke(result);
			//result.AsyncWaitHandle.Close();		//que si on a attendu avec WaitOne

			//// Poll while simulating work.
			//while (result.IsCompleted == false)
			//{
			//    Thread.Sleep(250);
			//    Console.Write(".");
			//}


		}

		static void FuncAsyncCB(IAsyncResult ar)
		{
			AsyncResult result = (AsyncResult)ar;
			Action f = (Action)result.AsyncDelegate;
			//string formatString = (string)ar.AsyncState;
			try
			{
				/*string returnValue = */
				f.EndInvoke(ar);
			}
			catch (Exception e)
			{
				WriteLineWithThreadId(e.ToString());
			}
		}
	}
}
