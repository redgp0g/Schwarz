using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Schwarz.Models;

namespace Schwarz.Areas.Identity.Data;

public class SchwarzUser : IdentityUser
{
    [PersonalData]
    public string Nome { get; set; }
    [PersonalData]
    public int? Matricula { get; set; }
    [PersonalData]
    public string? Turno { get; set; }
    [PersonalData]
    public string? Setor { get; set; }
    [PersonalData]
    public string? Cargo { get; set; }

    [PersonalData]
    public bool Ativo { get; set; }
    [PersonalData]
    public int? Ramal { get; set; }
    [PersonalData]
    public byte[]? Foto { get; set; }
    [PersonalData]
    public DateTime? DataNascimento { get; set; }
    [PersonalData]
    [ForeignKey("Lider")]
    public string? IdAspNetUserLider { get; set; }
    public virtual SchwarzUser? Lider{ get; set; }
	[PersonalData]
	public bool Interno{ get; set; }



}

