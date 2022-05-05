using System.Collections.Generic;

namespace MJ.Solutions.Core.Communication
{
	public class ResponseErrorMessages
	{
		public ResponseErrorMessages()
		{
			Mensagens = new List<string>();
		}

		public List<string> Mensagens { get; set; }
	}
}
