using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HubArena.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_FUNCIONARIO_TB_ENDERECO_FUNCIONARIO_IdEnderecoFuncionario",
                table: "TB_FUNCIONARIO");

            migrationBuilder.DropTable(
                name: "TB_ENDERECO_FUNCIONARIO");

            migrationBuilder.DropTable(
                name: "TB_ENDERECO_QUADRA");

            migrationBuilder.RenameColumn(
                name: "IdEnderecoFuncionario",
                table: "TB_FUNCIONARIO",
                newName: "IdEndereco");

            migrationBuilder.RenameIndex(
                name: "IX_TB_FUNCIONARIO_IdEnderecoFuncionario",
                table: "TB_FUNCIONARIO",
                newName: "IX_TB_FUNCIONARIO_IdEndereco");

            migrationBuilder.AddColumn<int>(
                name: "IdEndereco",
                table: "TB_QUADRA",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TB_ENDERECO",
                columns: table => new
                {
                    IdEndereco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cep = table.Column<string>(type: "varchar(10)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(2)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(50)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(50)", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: true),
                    Complemento = table.Column<string>(type: "varchar(50)", nullable: true),
                    PontoReferencia = table.Column<string>(type: "varchar(100)", nullable: true),
                    TipoEndereco = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ENDERECO", x => x.IdEndereco);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_QUADRA_IdEndereco",
                table: "TB_QUADRA",
                column: "IdEndereco",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_FUNCIONARIO_TB_ENDERECO_IdEndereco",
                table: "TB_FUNCIONARIO",
                column: "IdEndereco",
                principalTable: "TB_ENDERECO",
                principalColumn: "IdEndereco");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_QUADRA_TB_ENDERECO_IdEndereco",
                table: "TB_QUADRA",
                column: "IdEndereco",
                principalTable: "TB_ENDERECO",
                principalColumn: "IdEndereco");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_FUNCIONARIO_TB_ENDERECO_IdEndereco",
                table: "TB_FUNCIONARIO");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_QUADRA_TB_ENDERECO_IdEndereco",
                table: "TB_QUADRA");

            migrationBuilder.DropTable(
                name: "TB_ENDERECO");

            migrationBuilder.DropIndex(
                name: "IX_TB_QUADRA_IdEndereco",
                table: "TB_QUADRA");

            migrationBuilder.DropColumn(
                name: "IdEndereco",
                table: "TB_QUADRA");

            migrationBuilder.RenameColumn(
                name: "IdEndereco",
                table: "TB_FUNCIONARIO",
                newName: "IdEnderecoFuncionario");

            migrationBuilder.RenameIndex(
                name: "IX_TB_FUNCIONARIO_IdEndereco",
                table: "TB_FUNCIONARIO",
                newName: "IX_TB_FUNCIONARIO_IdEnderecoFuncionario");

            migrationBuilder.CreateTable(
                name: "TB_ENDERECO_FUNCIONARIO",
                columns: table => new
                {
                    IdEnderecoFuncionario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bairro = table.Column<string>(type: "varchar(50)", nullable: false),
                    Cep = table.Column<string>(type: "varchar(10)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(50)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(50)", nullable: true),
                    Estado = table.Column<string>(type: "varchar(2)", nullable: false),
                    IdFuncionario = table.Column<int>(type: "int", nullable: true),
                    Logradouro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: true),
                    PontoReferencia = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ENDERECO_FUNCIONARIO", x => x.IdEnderecoFuncionario);
                });

            migrationBuilder.CreateTable(
                name: "TB_ENDERECO_QUADRA",
                columns: table => new
                {
                    IdEnderecoQuadra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdQuadra = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(50)", nullable: false),
                    Cep = table.Column<string>(type: "varchar(10)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(50)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(50)", nullable: true),
                    Estado = table.Column<string>(type: "varchar(2)", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: true),
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

            migrationBuilder.CreateIndex(
                name: "IX_TB_ENDERECO_QUADRA_IdQuadra",
                table: "TB_ENDERECO_QUADRA",
                column: "IdQuadra",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_FUNCIONARIO_TB_ENDERECO_FUNCIONARIO_IdEnderecoFuncionario",
                table: "TB_FUNCIONARIO",
                column: "IdEnderecoFuncionario",
                principalTable: "TB_ENDERECO_FUNCIONARIO",
                principalColumn: "IdEnderecoFuncionario");
        }
    }
}
