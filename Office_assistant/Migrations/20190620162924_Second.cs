using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Office_assistant.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Food_name",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Foods");

            migrationBuilder.CreateTable(
                name: "subFood",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Food_name = table.Column<string>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    FoodId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subFood", x => x.Id);
                    table.ForeignKey(
                        name: "FK_subFood_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_subFood_FoodId",
                table: "subFood",
                column: "FoodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subFood");

            migrationBuilder.AddColumn<string>(
                name: "Food_name",
                table: "Foods",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Foods",
                nullable: false,
                defaultValue: 0);
        }
    }
}
