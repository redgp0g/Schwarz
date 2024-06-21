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
    [ForeignKey("Funcionario")]
    public int IDFuncionario{ get; set; }
    public virtual Funcionario? Funcionario { get; set; }

}

