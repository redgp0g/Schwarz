using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schwarz.Migrations
{
    public partial class Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Boleto",
                columns: table => new
                {
                    IDBoleto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Boleto = table.Column<float>(type: "float", nullable: false),
                    Cota = table.Column<float>(type: "float", nullable: false),
                    Tolerancia = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Caracteristica = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boleto", x => x.IDBoleto);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IDCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IDCliente);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Falha",
                columns: table => new
                {
                    IDFalha = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Identificacao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Falha", x => x.IDFalha);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    IDFuncionario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Matricula = table.Column<int>(type: "int", nullable: true),
                    Setor = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Turno = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.IDFuncionario);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Maquina",
                columns: table => new
                {
                    IDMaquina = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maquina", x => x.IDMaquina);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Operacao",
                columns: table => new
                {
                    IDOperacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Sequencia = table.Column<int>(type: "int", nullable: false),
                    SubSequencia = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Procedimento = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operacao", x => x.IDOperacao);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    IDProduto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IDCliente = table.Column<int>(type: "int", nullable: false),
                    CodigoCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.IDProduto);
                    table.ForeignKey(
                        name: "FK_Produto_Cliente_IDCliente",
                        column: x => x.IDCliente,
                        principalTable: "Cliente",
                        principalColumn: "IDCliente",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IDFuncionario = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Funcionario_IDFuncionario",
                        column: x => x.IDFuncionario,
                        principalTable: "Funcionario",
                        principalColumn: "IDFuncionario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FSP",
                columns: table => new
                {
                    IDFSP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    DataAbertura = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataFechamento = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Produto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Origem = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IDFalha = table.Column<int>(type: "int", nullable: false),
                    MaodeObra = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Maquina = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Medicao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Material = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MeioAmbiente = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Metodo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PorqueFalhou1 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PorqueFalhou2 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PorqueFalhou3 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PorqueFalhou4 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PorqueFalhou5 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CausaRaizFalha = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PorquePassou1 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PorquePassou2 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PorquePassou3 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PorquePassou4 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PorquePassou5 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CausaRaizPassou = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AtualizarFMEA = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    QualFMEA = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IDFuncionarioFMEA = table.Column<int>(type: "int", nullable: true),
                    PrazoFMEA = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RealizadoFMEA = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    AtualizarInstrucao = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    QualInstrucao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IDFuncionarioInstrucao = table.Column<int>(type: "int", nullable: true),
                    PrazoInstrucao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RealizadoInstrucao = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    AtualizarPlanoControle = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    QualPlanoControle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IDFuncionarioPlanoControle = table.Column<int>(type: "int", nullable: true),
                    PrazoPlanoControle = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RealizadoPlanoControle = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    UtilizarPokaYoke = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    QualPokaYoke = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IDFuncionarioPokaYoke = table.Column<int>(type: "int", nullable: true),
                    PrazoPokaYoke = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RealizadoPokaYoke = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    AplicarTreinamento = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    QualTreinamento = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IDFuncionarioTreinamento = table.Column<int>(type: "int", nullable: true),
                    PrazoTreinamento = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RealizadoTreinamento = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    EmitirAlertaQualidade = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    QualAlertaQualidade = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IDFuncionarioAlertaQualidade = table.Column<int>(type: "int", nullable: true),
                    PrazoAlertaQualidade = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RealizadoAlertaQualidade = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IDFuncionarioVerificacao = table.Column<int>(type: "int", nullable: true),
                    DataVerificacao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IndicadorVerificacao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EficazVerificacao = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    MetodologiaVerificacao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IDNovaFSP = table.Column<int>(type: "int", nullable: true),
                    IDFuncionarioNovaFSP = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FSP", x => x.IDFSP);
                    table.ForeignKey(
                        name: "FK_FSP_Falha_IDFalha",
                        column: x => x.IDFalha,
                        principalTable: "Falha",
                        principalColumn: "IDFalha",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FSP_FSP_IDNovaFSP",
                        column: x => x.IDNovaFSP,
                        principalTable: "FSP",
                        principalColumn: "IDFSP");
                    table.ForeignKey(
                        name: "FK_FSP_Funcionario_IDFuncionarioAlertaQualidade",
                        column: x => x.IDFuncionarioAlertaQualidade,
                        principalTable: "Funcionario",
                        principalColumn: "IDFuncionario");
                    table.ForeignKey(
                        name: "FK_FSP_Funcionario_IDFuncionarioFMEA",
                        column: x => x.IDFuncionarioFMEA,
                        principalTable: "Funcionario",
                        principalColumn: "IDFuncionario");
                    table.ForeignKey(
                        name: "FK_FSP_Funcionario_IDFuncionarioInstrucao",
                        column: x => x.IDFuncionarioInstrucao,
                        principalTable: "Funcionario",
                        principalColumn: "IDFuncionario");
                    table.ForeignKey(
                        name: "FK_FSP_Funcionario_IDFuncionarioNovaFSP",
                        column: x => x.IDFuncionarioNovaFSP,
                        principalTable: "Funcionario",
                        principalColumn: "IDFuncionario");
                    table.ForeignKey(
                        name: "FK_FSP_Funcionario_IDFuncionarioPlanoControle",
                        column: x => x.IDFuncionarioPlanoControle,
                        principalTable: "Funcionario",
                        principalColumn: "IDFuncionario");
                    table.ForeignKey(
                        name: "FK_FSP_Funcionario_IDFuncionarioPokaYoke",
                        column: x => x.IDFuncionarioPokaYoke,
                        principalTable: "Funcionario",
                        principalColumn: "IDFuncionario");
                    table.ForeignKey(
                        name: "FK_FSP_Funcionario_IDFuncionarioTreinamento",
                        column: x => x.IDFuncionarioTreinamento,
                        principalTable: "Funcionario",
                        principalColumn: "IDFuncionario");
                    table.ForeignKey(
                        name: "FK_FSP_Funcionario_IDFuncionarioVerificacao",
                        column: x => x.IDFuncionarioVerificacao,
                        principalTable: "Funcionario",
                        principalColumn: "IDFuncionario");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Fluxo",
                columns: table => new
                {
                    IDFluxo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CodigoFL = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IDProduto = table.Column<int>(type: "int", nullable: false),
                    IDFuncionarioCriador = table.Column<int>(type: "int", nullable: false),
                    IDFuncionarioAprovador = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Aplicacao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Revisao = table.Column<int>(type: "int", nullable: false),
                    DescricaoRevisao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluxo", x => x.IDFluxo);
                    table.ForeignKey(
                        name: "FK_Fluxo_Funcionario_IDFuncionarioAprovador",
                        column: x => x.IDFuncionarioAprovador,
                        principalTable: "Funcionario",
                        principalColumn: "IDFuncionario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fluxo_Funcionario_IDFuncionarioCriador",
                        column: x => x.IDFuncionarioCriador,
                        principalTable: "Funcionario",
                        principalColumn: "IDFuncionario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fluxo_Produto_IDProduto",
                        column: x => x.IDProduto,
                        principalTable: "Produto",
                        principalColumn: "IDProduto",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Processo",
                columns: table => new
                {
                    IDProcesso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CodigoInterno = table.Column<int>(type: "int", nullable: false),
                    IDProduto = table.Column<int>(type: "int", nullable: false),
                    IDOperacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processo", x => x.IDProcesso);
                    table.ForeignKey(
                        name: "FK_Processo_Operacao_IDOperacao",
                        column: x => x.IDOperacao,
                        principalTable: "Operacao",
                        principalColumn: "IDOperacao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Processo_Produto_IDProduto",
                        column: x => x.IDProduto,
                        principalTable: "Produto",
                        principalColumn: "IDProduto",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CadastroOleo",
                columns: table => new
                {
                    IDCadastroOleo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IDUser = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IDMaquina = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Litros = table.Column<double>(type: "double", nullable: false),
                    DiarioBordo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadastroOleo", x => x.IDCadastroOleo);
                    table.ForeignKey(
                        name: "FK_CadastroOleo_AspNetUsers_IDUser",
                        column: x => x.IDUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CadastroOleo_Maquina_IDMaquina",
                        column: x => x.IDMaquina,
                        principalTable: "Maquina",
                        principalColumn: "IDMaquina",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ideia",
                columns: table => new
                {
                    IDIdeia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IDUser = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ganho = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Investimento = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Feedback = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NomeEquipe = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ideia", x => x.IDIdeia);
                    table.ForeignKey(
                        name: "FK_Ideia_AspNetUsers_IDUser",
                        column: x => x.IDUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EquipeFSP",
                columns: table => new
                {
                    IDEquipeFSP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IDFuncionario = table.Column<int>(type: "int", nullable: false),
                    IDFSP = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipeFSP", x => x.IDEquipeFSP);
                    table.ForeignKey(
                        name: "FK_EquipeFSP_FSP_IDFSP",
                        column: x => x.IDFSP,
                        principalTable: "FSP",
                        principalColumn: "IDFSP",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipeFSP_Funcionario_IDFuncionario",
                        column: x => x.IDFuncionario,
                        principalTable: "Funcionario",
                        principalColumn: "IDFuncionario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PlanoAcao",
                columns: table => new
                {
                    IDPlanoAcao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IDFuncionario = table.Column<int>(type: "int", nullable: false),
                    IDFSP = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Prazo = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoAcao", x => x.IDPlanoAcao);
                    table.ForeignKey(
                        name: "FK_PlanoAcao_FSP_IDFSP",
                        column: x => x.IDFSP,
                        principalTable: "FSP",
                        principalColumn: "IDFSP",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanoAcao_Funcionario_IDFuncionario",
                        column: x => x.IDFuncionario,
                        principalTable: "Funcionario",
                        principalColumn: "IDFuncionario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FluxoOperacao",
                columns: table => new
                {
                    IDFluxoOperacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IDFluxo = table.Column<int>(type: "int", nullable: false),
                    IDOperacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluxoOperacao", x => x.IDFluxoOperacao);
                    table.ForeignKey(
                        name: "FK_FluxoOperacao_Fluxo_IDFluxo",
                        column: x => x.IDFluxo,
                        principalTable: "Fluxo",
                        principalColumn: "IDFluxo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FluxoOperacao_Operacao_IDOperacao",
                        column: x => x.IDOperacao,
                        principalTable: "Operacao",
                        principalColumn: "IDOperacao",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Desenho",
                columns: table => new
                {
                    IDDesenho = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IDProcesso = table.Column<int>(type: "int", nullable: true),
                    IDProduto = table.Column<int>(type: "int", nullable: true),
                    Observacoes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Revisao = table.Column<int>(type: "int", nullable: false),
                    DescricaoRevisao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IDFuncionarioDesenhador = table.Column<int>(type: "int", nullable: true),
                    IDFuncionarioAprovador = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desenho", x => x.IDDesenho);
                    table.ForeignKey(
                        name: "FK_Desenho_Funcionario_IDFuncionarioAprovador",
                        column: x => x.IDFuncionarioAprovador,
                        principalTable: "Funcionario",
                        principalColumn: "IDFuncionario");
                    table.ForeignKey(
                        name: "FK_Desenho_Funcionario_IDFuncionarioDesenhador",
                        column: x => x.IDFuncionarioDesenhador,
                        principalTable: "Funcionario",
                        principalColumn: "IDFuncionario");
                    table.ForeignKey(
                        name: "FK_Desenho_Processo_IDProcesso",
                        column: x => x.IDProcesso,
                        principalTable: "Processo",
                        principalColumn: "IDProcesso");
                    table.ForeignKey(
                        name: "FK_Desenho_Produto_IDProduto",
                        column: x => x.IDProduto,
                        principalTable: "Produto",
                        principalColumn: "IDProduto");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProcessoProduto",
                columns: table => new
                {
                    IDProcessoProduto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IDProcesso = table.Column<int>(type: "int", nullable: false),
                    IDProduto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessoProduto", x => x.IDProcessoProduto);
                    table.ForeignKey(
                        name: "FK_ProcessoProduto_Processo_IDProcesso",
                        column: x => x.IDProcesso,
                        principalTable: "Processo",
                        principalColumn: "IDProcesso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcessoProduto_Produto_IDProduto",
                        column: x => x.IDProduto,
                        principalTable: "Produto",
                        principalColumn: "IDProduto",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EquipeIdeia",
                columns: table => new
                {
                    IDEquipeIdeia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IDFuncionario = table.Column<int>(type: "int", nullable: false),
                    IDIdeia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipeIdeia", x => x.IDEquipeIdeia);
                    table.ForeignKey(
                        name: "FK_EquipeIdeia_Funcionario_IDFuncionario",
                        column: x => x.IDFuncionario,
                        principalTable: "Funcionario",
                        principalColumn: "IDFuncionario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipeIdeia_Ideia_IDIdeia",
                        column: x => x.IDIdeia,
                        principalTable: "Ideia",
                        principalColumn: "IDIdeia",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DesenhoBoleto",
                columns: table => new
                {
                    IDDesenhoBoleto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IDDesenho = table.Column<int>(type: "int", nullable: false),
                    IDBoleto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesenhoBoleto", x => x.IDDesenhoBoleto);
                    table.ForeignKey(
                        name: "FK_DesenhoBoleto_Boleto_IDBoleto",
                        column: x => x.IDBoleto,
                        principalTable: "Boleto",
                        principalColumn: "IDBoleto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DesenhoBoleto_Desenho_IDDesenho",
                        column: x => x.IDDesenho,
                        principalTable: "Desenho",
                        principalColumn: "IDDesenho",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IDFuncionario",
                table: "AspNetUsers",
                column: "IDFuncionario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CadastroOleo_IDMaquina",
                table: "CadastroOleo",
                column: "IDMaquina");

            migrationBuilder.CreateIndex(
                name: "IX_CadastroOleo_IDUser",
                table: "CadastroOleo",
                column: "IDUser");

            migrationBuilder.CreateIndex(
                name: "IX_Desenho_IDFuncionarioAprovador",
                table: "Desenho",
                column: "IDFuncionarioAprovador");

            migrationBuilder.CreateIndex(
                name: "IX_Desenho_IDFuncionarioDesenhador",
                table: "Desenho",
                column: "IDFuncionarioDesenhador");

            migrationBuilder.CreateIndex(
                name: "IX_Desenho_IDProcesso",
                table: "Desenho",
                column: "IDProcesso");

            migrationBuilder.CreateIndex(
                name: "IX_Desenho_IDProduto",
                table: "Desenho",
                column: "IDProduto");

            migrationBuilder.CreateIndex(
                name: "IX_DesenhoBoleto_IDBoleto",
                table: "DesenhoBoleto",
                column: "IDBoleto");

            migrationBuilder.CreateIndex(
                name: "IX_DesenhoBoleto_IDDesenho",
                table: "DesenhoBoleto",
                column: "IDDesenho");

            migrationBuilder.CreateIndex(
                name: "IX_EquipeFSP_IDFSP",
                table: "EquipeFSP",
                column: "IDFSP");

            migrationBuilder.CreateIndex(
                name: "IX_EquipeFSP_IDFuncionario",
                table: "EquipeFSP",
                column: "IDFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_EquipeIdeia_IDFuncionario",
                table: "EquipeIdeia",
                column: "IDFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_EquipeIdeia_IDIdeia",
                table: "EquipeIdeia",
                column: "IDIdeia");

            migrationBuilder.CreateIndex(
                name: "IX_Fluxo_IDFuncionarioAprovador",
                table: "Fluxo",
                column: "IDFuncionarioAprovador");

            migrationBuilder.CreateIndex(
                name: "IX_Fluxo_IDFuncionarioCriador",
                table: "Fluxo",
                column: "IDFuncionarioCriador");

            migrationBuilder.CreateIndex(
                name: "IX_Fluxo_IDProduto",
                table: "Fluxo",
                column: "IDProduto");

            migrationBuilder.CreateIndex(
                name: "IX_FluxoOperacao_IDFluxo",
                table: "FluxoOperacao",
                column: "IDFluxo");

            migrationBuilder.CreateIndex(
                name: "IX_FluxoOperacao_IDOperacao",
                table: "FluxoOperacao",
                column: "IDOperacao");

            migrationBuilder.CreateIndex(
                name: "IX_FSP_IDFalha",
                table: "FSP",
                column: "IDFalha");

            migrationBuilder.CreateIndex(
                name: "IX_FSP_IDFuncionarioAlertaQualidade",
                table: "FSP",
                column: "IDFuncionarioAlertaQualidade");

            migrationBuilder.CreateIndex(
                name: "IX_FSP_IDFuncionarioFMEA",
                table: "FSP",
                column: "IDFuncionarioFMEA");

            migrationBuilder.CreateIndex(
                name: "IX_FSP_IDFuncionarioInstrucao",
                table: "FSP",
                column: "IDFuncionarioInstrucao");

            migrationBuilder.CreateIndex(
                name: "IX_FSP_IDFuncionarioNovaFSP",
                table: "FSP",
                column: "IDFuncionarioNovaFSP");

            migrationBuilder.CreateIndex(
                name: "IX_FSP_IDFuncionarioPlanoControle",
                table: "FSP",
                column: "IDFuncionarioPlanoControle");

            migrationBuilder.CreateIndex(
                name: "IX_FSP_IDFuncionarioPokaYoke",
                table: "FSP",
                column: "IDFuncionarioPokaYoke");

            migrationBuilder.CreateIndex(
                name: "IX_FSP_IDFuncionarioTreinamento",
                table: "FSP",
                column: "IDFuncionarioTreinamento");

            migrationBuilder.CreateIndex(
                name: "IX_FSP_IDFuncionarioVerificacao",
                table: "FSP",
                column: "IDFuncionarioVerificacao");

            migrationBuilder.CreateIndex(
                name: "IX_FSP_IDNovaFSP",
                table: "FSP",
                column: "IDNovaFSP");

            migrationBuilder.CreateIndex(
                name: "IX_Ideia_IDUser",
                table: "Ideia",
                column: "IDUser");

            migrationBuilder.CreateIndex(
                name: "IX_PlanoAcao_IDFSP",
                table: "PlanoAcao",
                column: "IDFSP");

            migrationBuilder.CreateIndex(
                name: "IX_PlanoAcao_IDFuncionario",
                table: "PlanoAcao",
                column: "IDFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_Processo_IDOperacao",
                table: "Processo",
                column: "IDOperacao");

            migrationBuilder.CreateIndex(
                name: "IX_Processo_IDProduto",
                table: "Processo",
                column: "IDProduto");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessoProduto_IDProcesso",
                table: "ProcessoProduto",
                column: "IDProcesso");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessoProduto_IDProduto",
                table: "ProcessoProduto",
                column: "IDProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_IDCliente",
                table: "Produto",
                column: "IDCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CadastroOleo");

            migrationBuilder.DropTable(
                name: "DesenhoBoleto");

            migrationBuilder.DropTable(
                name: "EquipeFSP");

            migrationBuilder.DropTable(
                name: "EquipeIdeia");

            migrationBuilder.DropTable(
                name: "FluxoOperacao");

            migrationBuilder.DropTable(
                name: "PlanoAcao");

            migrationBuilder.DropTable(
                name: "ProcessoProduto");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Maquina");

            migrationBuilder.DropTable(
                name: "Boleto");

            migrationBuilder.DropTable(
                name: "Desenho");

            migrationBuilder.DropTable(
                name: "Ideia");

            migrationBuilder.DropTable(
                name: "Fluxo");

            migrationBuilder.DropTable(
                name: "FSP");

            migrationBuilder.DropTable(
                name: "Processo");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Falha");

            migrationBuilder.DropTable(
                name: "Operacao");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
