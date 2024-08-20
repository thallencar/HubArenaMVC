using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HubArena.Data.Migrations
{
    /// <inheritdoc />
    public partial class MappingModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_EQUIPAMENTO",
                columns: table => new
                {
                    IdEquipamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    StatusEquipamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_EQUIPAMENTO", x => x.IdEquipamento);
                });

            migrationBuilder.CreateTable(
                name: "TB_FUNCIONARIO",
                columns: table => new
                {
                    IdFuncionario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    Cargo = table.Column<string>(type: "varchar(90)", nullable: false),
                    Documento = table.Column<string>(type: "varchar(11)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexo = table.Column<string>(type: "varchar(10)", nullable: true),
                    Email = table.Column<string>(type: "varchar(60)", nullable: false),
                    Usuario = table.Column<string>(type: "varchar(30)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(16)", nullable: false),
                    StatusPessoa = table.Column<int>(type: "int", nullable: false),
                    DataRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_FUNCIONARIO", x => x.IdFuncionario);
                });

            migrationBuilder.CreateTable(
                name: "TB_ESPORTE",
                columns: table => new
                {
                    IdEsporte = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: true),
                    IdEquipamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ESPORTE", x => x.IdEsporte);
                    table.ForeignKey(
                        name: "FK_TB_ESPORTE_TB_EQUIPAMENTO_IdEquipamento",
                        column: x => x.IdEquipamento,
                        principalTable: "TB_EQUIPAMENTO",
                        principalColumn: "IdEquipamento");
                });

            migrationBuilder.CreateTable(
                name: "TB_CONTATO",
                columns: table => new
                {
                    IdContato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ddd = table.Column<int>(type: "int", nullable: false),
                    Ddi = table.Column<int>(type: "int", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", nullable: false),
                    TipoContato = table.Column<int>(type: "int", nullable: false),
                    IdFuncionario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CONTATO", x => x.IdContato);
                    table.ForeignKey(
                        name: "FK_TB_CONTATO_TB_FUNCIONARIO_IdFuncionario",
                        column: x => x.IdFuncionario,
                        principalTable: "TB_FUNCIONARIO",
                        principalColumn: "IdFuncionario");
                });

            migrationBuilder.CreateTable(
                name: "TB_ENDERECO_FUNCIONARIO",
                columns: table => new
                {
                    IdEnderecoFuncionario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFuncionario = table.Column<int>(type: "int", nullable: false),
                    Cep = table.Column<string>(type: "varchar(10)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(2)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(50)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(50)", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(50)", nullable: true),
                    PontoReferencia = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ENDERECO_FUNCIONARIO", x => x.IdEnderecoFuncionario);
                    table.ForeignKey(
                        name: "FK_TB_ENDERECO_FUNCIONARIO_TB_FUNCIONARIO_IdFuncionario",
                        column: x => x.IdFuncionario,
                        principalTable: "TB_FUNCIONARIO",
                        principalColumn: "IdFuncionario");
                });

            migrationBuilder.CreateTable(
                name: "TB_QUADRA",
                columns: table => new
                {
                    IdQuadra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    Capacidade = table.Column<int>(type: "int", nullable: false),
                    TipoQuadra = table.Column<int>(type: "int", nullable: false),
                    StatusQuadra = table.Column<int>(type: "int", nullable: false),
                    IdEsporte = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_QUADRA", x => x.IdQuadra);
                    table.ForeignKey(
                        name: "FK_TB_QUADRA_TB_ESPORTE_IdEsporte",
                        column: x => x.IdEsporte,
                        principalTable: "TB_ESPORTE",
                        principalColumn: "IdEsporte");
                });

            migrationBuilder.CreateTable(
                name: "TB_ENDERECO_QUADRA",
                columns: table => new
                {
                    IdEnderecoQuadra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdQuadra = table.Column<int>(type: "int", nullable: false),
                    Cep = table.Column<string>(type: "varchar(10)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(2)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(50)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(50)", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(50)", nullable: true),
                    PontoReferencia = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ENDERECO_QUADRA", x => x.IdEnderecoQuadra);
                    table.ForeignKey(
                        name: "FK_TB_ENDERECO_QUADRA_TB_QUADRA_IdQuadra",
                        column: x => x.IdQuadra,
                        principalTable: "TB_QUADRA",
                        principalColumn: "IdQuadra");
                });

            migrationBuilder.CreateTable(
                name: "TB_RESERVA",
                columns: table => new
                {
                    IdReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HorarioInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HorarioFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusReserva = table.Column<int>(type: "int", nullable: false),
                    IdQuadra = table.Column<int>(type: "int", nullable: false),
                    IdFuncionario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_RESERVA", x => x.IdReserva);
                    table.ForeignKey(
                        name: "FK_TB_RESERVA_TB_FUNCIONARIO_IdFuncionario",
                        column: x => x.IdFuncionario,
                        principalTable: "TB_FUNCIONARIO",
                        principalColumn: "IdFuncionario");
                    table.ForeignKey(
                        name: "FK_TB_RESERVA_TB_QUADRA_IdQuadra",
                        column: x => x.IdQuadra,
                        principalTable: "TB_QUADRA",
                        principalColumn: "IdQuadra");
                });

            migrationBuilder.CreateTable(
                name: "TB_RESERVA_EQUIPAMENTO",
                columns: table => new
                {
                    IdReservaEquipamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    IdReserva = table.Column<int>(type: "int", nullable: false),
                    IdEquipamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_RESERVA_EQUIPAMENTO", x => x.IdReservaEquipamento);
                    table.ForeignKey(
                        name: "FK_TB_RESERVA_EQUIPAMENTO_TB_EQUIPAMENTO_IdEquipamento",
                        column: x => x.IdEquipamento,
                        principalTable: "TB_EQUIPAMENTO",
                        principalColumn: "IdEquipamento");
                    table.ForeignKey(
                        name: "FK_TB_RESERVA_EQUIPAMENTO_TB_RESERVA_IdReserva",
                        column: x => x.IdReserva,
                        principalTable: "TB_RESERVA",
                        principalColumn: "IdReserva");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_CONTATO_IdFuncionario",
                table: "TB_CONTATO",
                column: "IdFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ENDERECO_FUNCIONARIO_IdFuncionario",
                table: "TB_ENDERECO_FUNCIONARIO",
                column: "IdFuncionario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_ENDERECO_QUADRA_IdQuadra",
                table: "TB_ENDERECO_QUADRA",
                column: "IdQuadra",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_ESPORTE_IdEquipamento",
                table: "TB_ESPORTE",
                column: "IdEquipamento");

            migrationBuilder.CreateIndex(
                name: "IX_TB_QUADRA_IdEsporte",
                table: "TB_QUADRA",
                column: "IdEsporte");

            migrationBuilder.CreateIndex(
                name: "IX_TB_RESERVA_IdFuncionario",
                table: "TB_RESERVA",
                column: "IdFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_TB_RESERVA_IdQuadra",
                table: "TB_RESERVA",
                column: "IdQuadra");

            migrationBuilder.CreateIndex(
                name: "IX_TB_RESERVA_EQUIPAMENTO_IdEquipamento",
                table: "TB_RESERVA_EQUIPAMENTO",
                column: "IdEquipamento");

            migrationBuilder.CreateIndex(
                name: "IX_TB_RESERVA_EQUIPAMENTO_IdReserva",
                table: "TB_RESERVA_EQUIPAMENTO",
                column: "IdReserva");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CONTATO");

            migrationBuilder.DropTable(
                name: "TB_ENDERECO_FUNCIONARIO");

            migrationBuilder.DropTable(
                name: "TB_ENDERECO_QUADRA");

            migrationBuilder.DropTable(
                name: "TB_RESERVA_EQUIPAMENTO");

            migrationBuilder.DropTable(
                name: "TB_RESERVA");

            migrationBuilder.DropTable(
                name: "TB_FUNCIONARIO");

            migrationBuilder.DropTable(
                name: "TB_QUADRA");

            migrationBuilder.DropTable(
                name: "TB_ESPORTE");

            migrationBuilder.DropTable(
                name: "TB_EQUIPAMENTO");
        }
    }
}
