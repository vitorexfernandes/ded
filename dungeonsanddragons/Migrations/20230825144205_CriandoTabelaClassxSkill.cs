using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dungeonsanddragons.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelaClassxSkill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharacterClassxSkill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterClassId = table.Column<int>(type: "int", nullable: false),
                    CharacterSkillId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterClassxSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterClassxSkill_CharacterClasses_CharacterClassId",
                        column: x => x.CharacterClassId,
                        principalTable: "CharacterClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterClassxSkill_CharacterSkills_CharacterSkillId",
                        column: x => x.CharacterSkillId,
                        principalTable: "CharacterSkills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterClassxSkill_CharacterClassId",
                table: "CharacterClassxSkill",
                column: "CharacterClassId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterClassxSkill_CharacterSkillId",
                table: "CharacterClassxSkill",
                column: "CharacterSkillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterClassxSkill");
        }
    }
}
