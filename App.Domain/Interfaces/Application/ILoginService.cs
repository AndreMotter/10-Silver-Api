using App.Domain.DTO;

namespace App.Domain.Interfaces.Application
{
    public interface ILoginService
    {
        RetornoLoginDTO Logar(LoginDTO login);
    }
}
