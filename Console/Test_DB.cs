using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;

namespace ConsoleApplication1
{
	class Test_DB
	{
		public static void Test1()
		{
			//http://stackoverflow.com/questions/380819/common-programming-mistakes-for-net-developers-to-avoid
			using (SqlConnection	conn = new SqlConnection())
			using (SqlCommand		cmd  = new SqlCommand("select 1", conn)) // no need to nest 
			{
				conn.Open();
				using (SqlDataReader dr = cmd.ExecuteReader()) //nessesary nest 
				{
					//dr.read() 
				}
			}

		}
	}
}
