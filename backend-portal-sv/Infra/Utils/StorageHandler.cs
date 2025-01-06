using Azure.Storage.Blobs;
using Domain.Entity.Viagem;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace Infra.Utils
{
    public class StorageHandler : IStorageHandler
    {
        private readonly string _connectionString;
        private readonly string _containerName;
        private readonly string _blobName;

        public StorageHandler(IConfiguration conf)
        {
            _connectionString = conf["AzureStorage:ConnectionString"] ?? "";
            _containerName = conf["AzureStorage:ContainerName"] ?? "";
            _blobName = conf["AzureStorage:BlobName"] ?? "destinos.md";
        }

        public async Task<Dictionary<string, DestinoInfo>> LerDestinosDoArquivoAsync(string filePath)
        {
            var blobClient = new BlobContainerClient(_connectionString, _containerName)
                .GetBlobClient(_blobName);

            Dictionary<string, DestinoInfo> destinos = new Dictionary<string, DestinoInfo>();

            var response = await blobClient.DownloadAsync();
            using var streamReader = new StreamReader(response.Value.Content);
            var content = await streamReader.ReadToEndAsync();
            var linhas = content.Split('\n');

            foreach (var linha in linhas.Skip(2))
            {
                var partes = linha.Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .Select(p => p.Trim())
                    .ToArray();

                if (partes.Length == 0)
                {
                    continue;
                }
                
                string nome = partes[0];
                if (decimal.TryParse(partes[1], out var precoPorPessoa) &&
                    decimal.TryParse(partes[2], out var multiplicadorFamilia) &&
                    decimal.TryParse(partes[3], out var multiplicadorIdade) &&
                    decimal.TryParse(partes[4], out var multiplicadorSaude))
                {
                    destinos[nome] = new DestinoInfo(
                        precoPorPessoa,
                        multiplicadorFamilia,
                        multiplicadorIdade,
                        multiplicadorSaude
                    );
                }
            }
            return destinos;
        }

        public async Task<string> GetPrecosParaTodosDestinosAsync()
        {
            StringBuilder context = new StringBuilder();
            var destinos = await LerDestinosDoArquivoAsync(string.Empty);

            if (destinos == null || destinos.Count == 0)
                return "Não há destinos disponíveis na base de dados.";

            foreach (var destino in destinos)
            {
                var nomeDestino = destino.Key;
                var destinoInfo = destino.Value;
                context.Append($"- Destino: {nomeDestino} \n");
                context.Append($"  Preço por pessoa: R$ {destinoInfo.PrecoPorPessoa:F2} \n");
            }
            return context.ToString();
        }
    }
}