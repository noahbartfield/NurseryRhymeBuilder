using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class WordAndRhyme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Favorite = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NurseryRhymes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Rhyme = table.Column<string>(nullable: false),
                    WordId = table.Column<int>(nullable: false),
                    Favorite = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NurseryRhymes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NurseryRhymes_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NurseryRhymes_WordId",
                table: "NurseryRhymes",
                column: "WordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NurseryRhymes");

            migrationBuilder.DropTable(
                name: "Words");
        }
    }
}
