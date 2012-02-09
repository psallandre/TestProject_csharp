using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Test_Remoting
{
	class RecordingsManager: MarshalByRefObject, IRecordingsManager
	{
		public DataSet GetRecordings()
		{
			string connectionString = "server=local;database=recordings;Trusted_Connection=yes";
	
			using (SqlConnection myConnection = new SqlConnection(connectionString))
			{
				string selectCmd = "select * from Recording";

				SqlDataAdapter myCommand = new SqlDataAdapter(selectCmd, myConnection);

				DataSet ds = new DataSet();

				myCommand.Fill(ds);

				return ds;
			}
		}
	}
}
