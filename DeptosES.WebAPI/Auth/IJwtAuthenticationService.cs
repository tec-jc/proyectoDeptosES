using DeptosES.EntidadesDeNegocio;

namespace DeptosES.WebAPI.Auth
{
    public interface IJwtAuthenticationService
    {
        string Authenticate(Usuario pUsuario);
    }
}
