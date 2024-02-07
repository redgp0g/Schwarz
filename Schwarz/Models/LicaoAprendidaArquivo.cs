using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
    [PrimaryKey(nameof(IDLicaoAprendida), nameof(IDArquivo))]
    public class LicaoAprendidaArquivo
    {
        [ForeignKey("LicaoAprendida")]
        public int IDLicaoAprendida { get; set; }
        public virtual LicaoAprendida LicaoAprendida { get; set; }

        [ForeignKey("Arquivo")]
        public int IDArquivo { get; set; }
        public virtual Arquivo Arquivo { get; set; }

        public LicaoAprendidaArquivo()
        {
        }

        public LicaoAprendidaArquivo(int iDLicaoAprendida, int iDArquivo)
        {
            IDLicaoAprendida = iDLicaoAprendida;
            IDArquivo = iDArquivo;
        }
    }
}
