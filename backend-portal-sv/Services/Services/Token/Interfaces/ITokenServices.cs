using Services.Services.DTO.Cliente;
namespace Services.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(ClienteDTO cliente);
    }
}
