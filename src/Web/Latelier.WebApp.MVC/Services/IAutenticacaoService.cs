using Latelier.WebApp.MVC.Models;
using System.Threading.Tasks;

namespace Latelier.WebApp.MVC.Services
{
	public interface IAutenticacaoService
	{
		Task<string> Login(UsuarioLogin usuarioLogin);

		Task<string> Registro(UsuarioRegistro usuarioRegistro);
	}
}
