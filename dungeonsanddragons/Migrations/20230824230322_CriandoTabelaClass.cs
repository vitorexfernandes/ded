using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dungeonsanddragons.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelaClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "CharacterSkills");


            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacterSkills",
                table: "CharacterSkills",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CharacterClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterClasses", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterClasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacterSkills",
                table: "CharacterSkills");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "CharacterSkills",
                column: "Id");
        }
    }
}
