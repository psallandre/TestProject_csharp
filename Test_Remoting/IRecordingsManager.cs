using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Test_Remoting
{
	public interface IRecordingsManager
	{
		DataSet GetRecordings();
	}
}
