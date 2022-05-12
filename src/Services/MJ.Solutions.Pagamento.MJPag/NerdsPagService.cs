﻿namespace MJ.Solutions.Pagamento.MJPag
{
	public class MJPagService
	{
		public readonly string ApiKey;
		public readonly string EncryptionKey;

		public MJPagService(string apiKey, string encryptionKey)
		{
			ApiKey = apiKey;
			EncryptionKey = encryptionKey;
		}
	}
}
