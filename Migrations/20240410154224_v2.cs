using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoTs.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Avaliacaos",
                table: "Avaliacaos");

            migrationBuilder.RenameTable(
                name: "Avaliacaos",
                newName: "Avaliacoes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Avaliacoes",
                table: "Avaliacoes",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Avaliacoes",
                table: "Avaliacoes");

            migrationBuilder.RenameTable(
                name: "Avaliacoes",
                newName: "Avaliacaos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Avaliacaos",
                table: "Avaliacaos",
                column: "Id");
        }
    }
}
