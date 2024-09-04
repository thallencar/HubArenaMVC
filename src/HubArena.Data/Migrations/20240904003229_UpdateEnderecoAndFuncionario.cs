using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HubArena.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEnderecoAndFuncionario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_FUNCIONARIO_TB_ENDERECO_IdEndereco",
                table: "TB_FUNCIONARIO");

            migrationBuilder.DropIndex(
                name: "IX_TB_FUNCIONARIO_IdEndereco",
                table: "TB_FUNCIONARIO");

            migrationBuilder.AlterColumn<string>(
                name: "TipoEndereco",
                table: "TB_ENDERECO",
                type: "varchar(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "TB_ENDERECO",
                type: "varchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(2)");

            migrationBuilder.AddColumn<int>(
                name: "IdFuncionario",
                table: "TB_ENDERECO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TB_ENDERECO_IdFuncionario",
                table: "TB_ENDERECO",
                column: "IdFuncionario",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_ENDERECO_TB_FUNCIONARIO_IdFuncionario",
                table: "TB_ENDERECO",
                column: "IdFuncionario",
                principalTable: "TB_FUNCIONARIO",
                principalColumn: "IdFuncionario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_ENDERECO_TB_FUNCIONARIO_IdFuncionario",
                table: "TB_ENDERECO");

            migrationBuilder.DropIndex(
                name: "IX_TB_ENDERECO_IdFuncionario",
                table: "TB_ENDERECO");

            migrationBuilder.DropColumn(
                name: "IdFuncionario",
                table: "TB_ENDERECO");

            migrationBuilder.AlterColumn<int>(
                name: "TipoEndereco",
                table: "TB_ENDERECO",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "TB_ENDERECO",
                type: "varchar(2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)");

            migrationBuilder.CreateIndex(
                name: "IX_TB_FUNCIONARIO_IdEndereco",
                table: "TB_FUNCIONARIO",
                column: "IdEndereco",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_FUNCIONARIO_TB_ENDERECO_IdEndereco",
                table: "TB_FUNCIONARIO",
                column: "IdEndereco",
                principalTable: "TB_ENDERECO",
                principalColumn: "IdEndereco");
        }
    }
}
