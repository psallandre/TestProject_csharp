using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Test
{
   //http://msdn.microsoft.com/EN-US/library/bsc2ak47(v=VS.110,d=hv.2).aspx
   //http://msdn.microsoft.com/en-us/library/ms173147%28VS.80%29.aspx
   //http://blogs.msdn.com/b/ericlippert/archive/2009/04/09/double-your-dispatch-double-your-fun.aspx

   [TestClass]
   public class ReferenceEqualsTest
   {
      [TestMethod]
      public void StringEquals() {
         string s1 = "test";
         string s2 = "test";
         string s3 = "test1".Substring(0, 4);
         object s4 = s3;

         Assert.IsTrue(object.ReferenceEquals(s1, s2));
         Assert.IsTrue(s1 == s2);
         Assert.IsTrue(s1.Equals(s2));

         Assert.IsFalse(object.ReferenceEquals(s1, s3));
         Assert.IsTrue(s1 == s3);
         Assert.IsTrue(s1.Equals(s3));

         Assert.IsFalse(object.ReferenceEquals(s1, s4));
         Assert.IsFalse(s1 == s4);  //warning CS0253: Possible unintended reference comparison; to get a value comparison, cast the right hand side to type 'string'
         Assert.IsTrue(s1 == (string)s4);
         Assert.IsTrue(s1.Equals(s4));
      }

      [TestMethod]
      public void StringBuilderEquals() {
         StringBuilder s1 = new StringBuilder("test");
         StringBuilder s2 = new StringBuilder("test");
         StringBuilder s3 = new StringBuilder("test1".Substring(0, 4));
         object s4 = s3;

         Assert.IsFalse(object.ReferenceEquals(s1, s2));
         Assert.IsFalse(s1 == s2);
         Assert.IsTrue(s1.Equals(s2));

         Assert.IsFalse(object.ReferenceEquals(s1, s3));
         Assert.IsFalse(s1 == s3);
         Assert.IsTrue(s1.Equals(s3));

         Assert.IsFalse(object.ReferenceEquals(s1, s4));
         Assert.IsFalse(s1 == s4);  //warning CS0253: Possible unintended reference comparison; to get a value comparison, cast the right hand side to type 'string'
         Assert.IsFalse(s1 == (StringBuilder)s4);
         Assert.IsFalse(s1.Equals(s4));
      }

      public class A
      {
         public string s;
         public A(string s_) { s = s_; }
      }

      [TestMethod]
      public void StringInsideClassEquals() {
         A s1 = new A("test");
         A s2 = new A("test");
         A s3 = new A("test1".Substring(0, 4));
         object s4 = s3;

         Assert.IsFalse(object.ReferenceEquals(s1, s2));
         Assert.IsFalse(s1 == s2);
         Assert.IsFalse(s1.Equals(s2));

         Assert.IsFalse(object.ReferenceEquals(s1, s3));
         Assert.IsFalse(s1 == s3);
         Assert.IsFalse(s1.Equals(s3));

         Assert.IsFalse(object.ReferenceEquals(s1, s4));
         Assert.IsFalse(s1 == s4);  //warning CS0253: Possible unintended reference comparison; to get a value comparison, cast the right hand side to type 'string'
         Assert.IsFalse(s1 == (A)s4);
         Assert.IsFalse(s1.Equals(s4));
      }

      public class B
      {
         public string s;
         public B(string s_) { s = s_; }

         public override bool Equals(object obj) {
            B rhs = obj as B;
            //if (object.ReferenceEquals(rhs, null))  //Attn: == null appelle operator ==
            if ((object)rhs == null)   //idem
               return false;
            else
               return s.Equals(rhs.s);
         }

         //pas necessaire, performance only
         public bool Equals(B rhs) {
            return s.Equals(rhs.s);
         }

         public static bool operator ==(B x, B y) {
            return x.s == y.s;
         }

         public static bool operator !=(B x, B y) {
            return !(x == y);
         }
      }

      [TestMethod]
      public void StringInsideClassWithOverridenEquals() {
         B s1 = new B("test");
         B s2 = new B("test");
         B s3 = new B("test1".Substring(0, 4));
         object s4 = s3;

         Assert.IsFalse(object.ReferenceEquals(s1, s2));
         Assert.IsTrue(s1 == s2);
         Assert.IsTrue(s1.Equals(s2));

         Assert.IsFalse(object.ReferenceEquals(s1, s3));
         Assert.IsTrue(s1 == s3);
         Assert.IsTrue(s1.Equals(s3));

         Assert.IsFalse(object.ReferenceEquals(s1, s4));
         Assert.IsFalse(s1 == s4);  //warning CS0253: Possible unintended reference comparison; to get a value comparison, cast the right hand side to type 'string'
         Assert.IsTrue(s1 == (B)s4);
         Assert.IsTrue(s1.Equals(s4));
      }

      //Struct
      public struct C
      {
         public string s;

         public C(string s_) { s = s_; }

         //.Equals fonctionne meme sans operator ==
         public static bool operator ==(C x, C y) {
            return x.s == y.s;
         }

         public static bool operator !=(C x, C y) {
            return !(x == y);
         }
      }

      [TestMethod]
      public void StringInsideStructWithOverridenEquals() {
         C s1 = new C("test");
         C s2 = new C("test");
         C s3 = new C("test1".Substring(0, 4));
         object s4 = s3;

         Assert.IsFalse(object.ReferenceEquals(s1, s2));
         Assert.IsTrue(s1 == s2);
         Assert.IsTrue(s1.Equals(s2));

         Assert.IsFalse(object.ReferenceEquals(s1, s3));
         Assert.IsTrue(s1 == s3);
         Assert.IsTrue(s1.Equals(s3));

         Assert.IsFalse(object.ReferenceEquals(s1, s4));
         //Assert.IsFalse(s1 == s4);  //ne compile pas
         Assert.IsTrue(s1 == (C)s4);
         Assert.IsTrue(s1.Equals(s4));
      }

   }
}
