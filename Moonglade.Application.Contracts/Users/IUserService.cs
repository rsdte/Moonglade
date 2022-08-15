using Moonglade.Application.Contracts.Dtos;

namespace Moonglade.Application.Contracts
{
    public interface IUserService
    {
        Task<string> GenerateTokenAsync(LoginDto model);
    }
}
