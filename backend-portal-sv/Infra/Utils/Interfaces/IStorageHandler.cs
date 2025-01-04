using Domain.Entity.Viagem;

namespace Infra.Utils
{
    public interface IStorageHandler
    {
        Task<Dictionary<string, DestinoInfo>> LerDestinosDoArquivoAsync(string filePath);
        Task<string> GetPrecosParaTodosDestinosAsync();
    }
}
