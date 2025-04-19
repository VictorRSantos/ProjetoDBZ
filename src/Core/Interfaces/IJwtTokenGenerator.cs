
namespace ProjetoDBZ.src.Core.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(string userId);
    }
}