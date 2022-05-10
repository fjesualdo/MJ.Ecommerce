using Latelier.WebApp.MVC.Models;
using MJ.Solutions.Core.Communication;
using System.Threading.Tasks;

namespace Latelier.WebApp.MVC.Services
{
	public interface IClienteService
  {
    Task<EnderecoViewModel> ObterEndereco();
    Task<ResponseResult> AdicionarEndereco(EnderecoViewModel endereco);
  }
}
