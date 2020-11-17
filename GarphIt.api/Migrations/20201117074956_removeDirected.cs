using Microsoft.EntityFrameworkCore.Migrations;

namespace GarphIt.api.Migrations
{
    public partial class removeDirected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Directed",
                table: "Edges");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Directed",
                table: "Edges",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
