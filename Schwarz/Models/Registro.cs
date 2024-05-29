
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace Schwarz.Models
{
    public class Registro
    {
        [Key]
        public int CodigoRegistro { get; set; }
        public int CodigoInterno { get; set; }
        public string Setor { get; set; } = string.Empty;
        public string Maquina { get; set; } = string.Empty;
        public string Operador { get; set; } = string.Empty;
        public string? Analista { get; set; }
        public string Situacao { get; set; } = string.Empty;
        public DateTime DataAbertura { get; set; }
        public DateTime DataFechamento { get; set; }
        public int OP { get; set; }
        public int RevisaoPlanoControle { get; set; }
        public string Turno { get; set; } = string.Empty;
        public DateTime? DataDiarioBordo { get; set; }
        public string? Problema { get; set; }
        public string? AcaoImediata { get; set; }
        public string? Responsavel { get; set; }

        public Registro()
        {

        }

    }
}
