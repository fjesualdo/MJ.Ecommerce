using System.Linq;

namespace MJ.Solutions.Core.Utils
{
	public static class StringUtils
	{

		//TODO:: MJ gerar extensions

		public static string ApenasNumeros(this string str, string input)
		{
			return new string(input.Where(char.IsDigit).ToArray());
		}
	}
}
