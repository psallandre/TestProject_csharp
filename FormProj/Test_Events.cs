using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormProj
{
	class Test_Events
	{
		public static void test()
		{
			Subject subject = new Subject();
			Observer observer = new Observer(subject);

			//crée la tuyauterie ici plutot que dans le ctor de Observer pour diminuer le coupling
			subject.priceChanger += observer.OnUpdatePriceChange;

			subject.ReceivePriceChangeFromFeed(12, 5.2);
		}
	}

	class PriceChangeEventArgs: EventArgs
	{
		public int qty;
		public double price;

		public PriceChangeEventArgs(int qty, double price)
		{
			this.qty = qty;
			this.price = price;
		}
	}

	class Subject
	{
		public delegate void PriceChanger(Object sender, PriceChangeEventArgs args);			//PriceHandler
		public event PriceChanger priceChanger;													//PriceHandler PriceEvent

		public void ReceivePriceChangeFromFeed(int qty, double price)							//notify
		{
			PriceChangeEventArgs args = new PriceChangeEventArgs(qty, price);
			if (priceChanger != null)
				priceChanger(this, args);
		}
	}

	class Observer
	{
		public Observer(Subject subject)
		{ 
			//subject.priceChanger += new Subject.PriceChanger(this.OnUpdatePriceChange);		//.NET 1.1
			//subject.priceChanger += this.OnUpdatePriceChange;								//.NET 2.0
		}

		public void OnUpdatePriceChange(Object sender, PriceChangeEventArgs args)			//Update, push model
		{
			if (sender is Subject)			//seul coupling éventuel
				;							//ok
			int qty = args.qty;
			double price = args.price;
			string str = String.Format("Received qty = {0}, price = {1}", qty, price);
		}
	}

}
