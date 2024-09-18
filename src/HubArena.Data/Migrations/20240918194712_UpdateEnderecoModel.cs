using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HubArena.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEnderecoModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_ENDERECO_IdFuncionario",
                table: "TB_ENDERECO");

            migrationBuilder.DropIndex(
                name: "IX_TB_ENDERECO_IdQuadra",
                table: "TB_ENDERECO");

            migrationBuilder.AlterColumn<int>(
                name: "IdQuadra",
                table: "TB_ENDERECO",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdFuncionario",
                table: "TB_ENDERECO",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ENDERECO_IdFuncionario",
                table: "TB_ENDERECO",
                column: "IdFuncionario",
                unique: true,
                filter: "[IdFuncionario] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ENDERECO_IdQuadra",
                table: "TB_ENDERECO",
                column: "IdQuadra",
                unique: true,
                filter: "[IdQuadra] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_ENDERECO_IdFuncionario",
                table: "TB_ENDERECO");

            migrationBuilder.DropIndex(
                name: "IX_TB_ENDERECO_IdQuadra",
                table: "TB_ENDERECO");

            migrationBuilder.AlterColumn<int>(
                name: "IdQuadra",
                table: "TB_ENDERECO",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdFuncionario",
                table: "TB_ENDERECO",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_ENDERECO_IdFuncionario",
                table: "TB_ENDERECO",
                column: "IdFuncionario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_ENDERECO_IdQuadra",
                table: "TB_ENDERECO",
                column: "IdQuadra",
                unique: true);
        }
    }
}
