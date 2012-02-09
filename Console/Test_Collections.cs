using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
	class Test_Collections
	{
		public static void Test_Dictionnary()
		{
			Dictionary<string, string> dico = new Dictionary<string, string>(10);
			//SortedDictionary<string, string> dico = new SortedDictionary<string, string>();
			dico.Add("key3", "value3");
			dico.Add("key1", "value1");
			dico.Add("key2", "value2");

			//Array.Sort<string>(dico);
			foreach (var elem in dico)
				//Console.WriteLine("Key : {0}, value : {1}", elem.Key, elem.Value);
				Console.WriteLine(elem.Key + " : " + elem.Value);

			//Search
			bool b;
			b = dico.ContainsKey("key3");
			b = dico.ContainsKey("key0");
		}

		public static void Test_List()
		{
			List<string> strings = new List<string>(10);
			strings.Add("value3");
			strings.Add("value1");
			strings.Add("value2");

			strings.Sort();
			foreach (var elem in strings)
				//Console.WriteLine("Key : {0}, value : {1}", elem.Key, elem.Value);
				Console.WriteLine(elem);

			//Search
			int i;
			i = strings.BinarySearch("v");						//-1
			i = strings.BinarySearch("value2");					//1

			string str;
			str = strings.Find(delegate(string s) { return s.Contains("1"); });
			str = strings.Find((string s) => { return s.Contains("2"); });
		}

		public static void Test_List2()
		{
			List<int>	ints = new List<int>(10);
			//cf Smacchia p 592
		}

		class Article
		{
			int		reference;
			string	description;
			decimal	prix;

			public Article()
			{
				reference   = -1;
				description = null;
				prix        = -1;
			}
		}

		class Article2:IComparable<Article2>
		{
			public class PrixCompare: IComparer<Article2>
			{
				int IComparer<Article2>.Compare(Article2 lhs, Article2 rhs)
				{ return lhs.Prix.CompareTo(rhs.Prix); }
			}
			public class ReferenceCompare: IComparer<Article2>
			{
				int IComparer<Article2>.Compare(Article2 lhs, Article2 rhs)
				{ return lhs.Reference.CompareTo(rhs.Reference); }
			}
			public int		Reference	{ get; set; }
			public string	Description { get; set; }
			public decimal	Prix		{ get; set; }

			public Article2()
			{
				Reference   = -1;
				Description = null;
				Prix        = -1;
			}
			public Article2(int Reference, string Description, decimal Prix)
			{
				this.Reference   = Reference;
				this.Description = Description;
				this.Prix        = Prix;
			}

			int IComparable<Article2>.CompareTo(Article2 other)
			{
				return Prix.CompareTo(other.Prix);
			}
			public override string ToString()
			{
				return Reference.ToString() + ", " + Description + ", " + Prix.ToString();
			}
		}

		class Stock: SortedDictionary<int, Article2>
		{
			public void Dump()
			{
				foreach (var elem in this)
					Console.WriteLine(elem.Value);
			}
		}

		public static void Test_Sort()
		{
			Stock stock = new Stock();

			Article2 article = new Article2();

			article.Reference   = 0;
			article.Description = "shoes";
			article.Prix        = 10;
			stock.Add(article.Reference, article);

			stock.Add(1, new Article2(Reference: 1, Description: "pants", Prix: 20));
			stock.Add(2, new Article2(2, "sockets", 5));

			stock.Dump();

			//Creation Array
			Console.WriteLine("\nArticles Array");
			Article2[] articles = new Article2[stock.Count];
			stock.Values.CopyTo(articles, 0);
			Console.WriteLine(articles.Length);

			Console.WriteLine("Sorting...(IComparable)");
			Array.Sort<Article2>(articles);
			foreach (var elem in articles)
				Console.WriteLine(elem);

			Console.WriteLine("Sorting...(PrixCompare)");
			Array.Sort<Article2>(articles,  new Article2.PrixCompare());
			foreach (var elem in articles)
				Console.WriteLine(elem);

			Console.WriteLine("Sorting...(ReferenceCompare)");
			Array.Sort<Article2>(articles,  new Article2.ReferenceCompare());
			foreach (var elem in articles)
				Console.WriteLine(elem);

		}
	}
}
