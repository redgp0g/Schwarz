﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Schwarz.Data;
using System.Security.Permissions;
using Schwarz.Areas.Identity.Data;
using Schwarz.Repository;

namespace Schwarz.Models
{
    public class CadastroOleo : CadastroOleoRepository
    {
        [Key]
        public int IDCadastroOleo { get; set; }
        [ForeignKey("User")]
        public string IDUser { get; set; }
        public virtual SchwarzUser? User { get; set; }

        [ForeignKey("Maquina")]
        [Required(ErrorMessage = "Selecione uma máquina")]
        public int IDMaquina { get; set; }
        public virtual Maquina? Maquina { get; set; }

        [Display(Name = "Tipo do Óleo")]
        public string Tipo { get; set; }
        public DateTime Data { get; set; }
        public double Litros { get; set; }

        [Display(Name = "Diário de Bordo")]
        public string? DiarioBordo { get; set; }

        public CadastroOleo()
        {

        }
        public CadastroOleo(SchwarzContext contexto) : base(contexto)
        {
            _context= contexto;
        }
    }
}
