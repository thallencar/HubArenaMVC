using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HubArena.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEnderecoMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TipoEndereco",
                table: "TB_ENDERECO",
                type: "varchar(12)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TipoEndereco",
                table: "TB_ENDERECO",
                type: "varchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(12)");
        }
    }
}
