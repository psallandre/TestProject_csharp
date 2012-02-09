using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;

namespace Test_Remoting
{
	class HttpServer
	{
		static HttpServer()
		{
			HttpChannel channel = new HttpChannel(8100);

			ChannelServices.RegisterChannel(channel);
			//ChannelServices.RegisterChannel(channel, true);

			RemotingConfiguration.RegisterWellKnownServiceType(typeof(IRecordingsManager), "RecordingsManager.soap", WellKnownObjectMode.Singleton);
		}

		//public HttpServer()
		//{}
	}
}
