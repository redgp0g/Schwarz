namespace Schwarz.Statics
{
    public class StatusPare
    {
        public const string EmAnalise = "Em Análise";
        public const string AprovadoLider = "Aprovado pelo Líder";
        public const string ReprovadoLider = "Reprovado pelo Líder";
        public const string AprovadoMeioAmbiente = "Aprovado pelo Meio Ambiente";
        public const string ReprovadoMeioAmbiente = "Reprovado pelo Meio Ambiente";
        public const string AprovadoQualidade = "Aprovado pela Qualidade";
        public const string ReprovadoQualidade = "Reprovado pela Qualidade";
        public const string AprovadoSeguranca = "Aprovado pela Segurança";
        public const string ReprovadoSeguranca = "Reprovado pela Segurança";
        public const string AcaoPendente = "Ação Pendente";
        public const string AcaoConcluida = "Ação Concluída";
        public const string AcaoValidada = "Ação Validada";
        public const string AcaoInvalidada = "Ação Invalidada";


        public static readonly List<string> QualidadeStatus = new List<string>
        {
            EmAnalise,
            AprovadoLider,
            ReprovadoLider,
            AprovadoMeioAmbiente,
            ReprovadoMeioAmbiente
        };

        public static readonly List<string> SegurancaStatus = new List<string>
        {
            EmAnalise,
            AprovadoSeguranca,
            ReprovadoSeguranca,
            AcaoPendente,
            AcaoConcluida,
            AcaoValidada,
            AcaoInvalidada
        };

        public static readonly List<string> MeioAmbienteStatus = new List<string>
        {
            EmAnalise,
            AprovadoLider,
            ReprovadoLider,
            AprovadoMeioAmbiente,
            ReprovadoMeioAmbiente
        };
    }
}
