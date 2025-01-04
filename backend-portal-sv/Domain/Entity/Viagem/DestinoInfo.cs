namespace Domain.Entity.Viagem
{
    public class DestinoInfo
    {
        public decimal PrecoPorPessoa { get; private set; }
        public decimal MultiplicadorFamilia { get; private set; }
        public decimal MultiplicadorIdade { get; private set; }
        public decimal MultiplicadorSaude { get; private set; }
        public DestinoInfo(decimal precoPorPessoa, decimal multiplicadorFamilia, decimal multiplicadorIdade, decimal multiplicadorSaude)
        {
            PrecoPorPessoa = precoPorPessoa;
            MultiplicadorFamilia = multiplicadorFamilia;
            MultiplicadorIdade = multiplicadorIdade;
            MultiplicadorSaude = multiplicadorSaude;
        }
    }
}
