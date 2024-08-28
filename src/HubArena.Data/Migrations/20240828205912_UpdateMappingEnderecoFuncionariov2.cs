using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HubArena.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMappingEnderecoFuncionariov2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_ENDERECO_FUNCIONARIO_TB_FUNCIONARIO_IdFuncionario",
                table: "TB_ENDERECO_FUNCIONARIO");

            migrationBuilder.DropIndex(
                name: "IX_TB_ENDERECO_FUNCIONARIO_IdFuncionario",
                table: "TB_ENDERECO_FUNCIONARIO");

            migrationBuilder.AddColumn<int>(
                name: "IdEnderecoFuncionario",
                table: "TB_FUNCIONARIO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "IdFuncionario",
                table: "TB_ENDERECO_FUNCIONARIO",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_TB_FUNCIONARIO_IdEnderecoFuncionario",
                table: "TB_FUNCIONARIO",
                column: "IdEnderecoFuncionario",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_FUNCIONARIO_TB_ENDERECO_FUNCIONARIO_IdEnderecoFuncionario",
                table: "TB_FUNCIONARIO",
                column: "IdEnderecoFuncionario",
                principalTable: "TB_ENDERECO_FUNCIONARIO",
                principalColumn: "IdEnderecoFuncionario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_FUNCIONARIO_TB_ENDERECO_FUNCIONARIO_IdEnderecoFuncionario",
                table: "TB_FUNCIONARIO");

            migrationBuilder.DropIndex(
                name: "IX_TB_FUNCIONARIO_IdEnderecoFuncionario",
                table: "TB_FUNCIONARIO");

            migrationBuilder.DropColumn(
                name: "IdEnderecoFuncionario",
                table: "TB_FUNCIONARIO");

            migrationBuilder.AlterColumn<int>(
                name: "IdFuncionario",
                table: "TB_ENDERECO_FUNCIONARIO",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_ENDERECO_FUNCIONARIO_IdFuncionario",
                table: "TB_ENDERECO_FUNCIONARIO",
                column: "IdFuncionario",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_ENDERECO_FUNCIONARIO_TB_FUNCIONARIO_IdFuncionario",
                table: "TB_ENDERECO_FUNCIONARIO",
                column: "IdFuncionario",
                principalTable: "TB_FUNCIONARIO",
                principalColumn: "IdFuncionario");
        }
    }
}
