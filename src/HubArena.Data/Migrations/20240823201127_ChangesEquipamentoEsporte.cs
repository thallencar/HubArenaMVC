using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HubArena.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangesEquipamentoEsporte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_ESPORTE_TB_EQUIPAMENTO_IdEquipamento",
                table: "TB_ESPORTE");

            migrationBuilder.DropIndex(
                name: "IX_TB_ESPORTE_IdEquipamento",
                table: "TB_ESPORTE");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "TB_ESPORTE");

            migrationBuilder.DropColumn(
                name: "IdEquipamento",
                table: "TB_ESPORTE");

            migrationBuilder.AddColumn<int>(
                name: "IdEsporte",
                table: "TB_EQUIPAMENTO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TB_EQUIPAMENTO_IdEsporte",
                table: "TB_EQUIPAMENTO",
                column: "IdEsporte");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_EQUIPAMENTO_TB_ESPORTE_IdEsporte",
                table: "TB_EQUIPAMENTO",
                column: "IdEsporte",
                principalTable: "TB_ESPORTE",
                principalColumn: "IdEsporte");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_EQUIPAMENTO_TB_ESPORTE_IdEsporte",
                table: "TB_EQUIPAMENTO");

            migrationBuilder.DropIndex(
                name: "IX_TB_EQUIPAMENTO_IdEsporte",
                table: "TB_EQUIPAMENTO");

            migrationBuilder.DropColumn(
                name: "IdEsporte",
                table: "TB_EQUIPAMENTO");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "TB_ESPORTE",
                type: "varchar(500)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdEquipamento",
                table: "TB_ESPORTE",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TB_ESPORTE_IdEquipamento",
                table: "TB_ESPORTE",
                column: "IdEquipamento");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_ESPORTE_TB_EQUIPAMENTO_IdEquipamento",
                table: "TB_ESPORTE",
                column: "IdEquipamento",
                principalTable: "TB_EQUIPAMENTO",
                principalColumn: "IdEquipamento");
        }
    }
}
