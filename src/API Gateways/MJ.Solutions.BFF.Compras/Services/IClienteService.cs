using MJ.Solutions.BFF.Compras.Models;
using System.Threading.Tasks;

namespace MJ.Solutions.BFF.Compras.Services
{
	public interface IClienteService
	{
		Task<EnderecoDTO> ObterEndereco();
	}
}
