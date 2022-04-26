using Microsoft.Extensions.Configuration;

namespace MJ.Solutions.Core.Utils
{
	public static class ConfigurationExtensions
	{
		public static string GetMessageQueueConnection(this IConfiguration configuration, string name)
		{
			return configuration?.GetSection("MessageQueueConnection")?[name];
		}
	}
}
