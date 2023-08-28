using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dungeonsanddragons.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoCharacter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
            name: "NewId",
            table: "Character",
            type: "int",
            nullable: false,
            defaultValue: 0);

            migrationBuilder.Sql("UPDATE Character SET NewId = Id");

            migrationBuilder.DropPrimaryKey(name: "PK_Character", table: "Character");

            migrationBuilder.DropColumn(name: "Id", table: "Character");

            migrationBuilder.RenameColumn(
                name: "NewId",
                table: "Character",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(name: "PK_Character", table: "Character", column: "Id");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_CharacterClasses_CharacterClassId",
                table: "Character");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Character",
                table: "Character");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Character",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Character",
                table: "Character",
                column: "Id");
        }
    }
}
