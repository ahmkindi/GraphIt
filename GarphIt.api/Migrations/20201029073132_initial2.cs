using Microsoft.EntityFrameworkCore.Migrations;

namespace GarphIt.api.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurvePointX",
                table: "Edges");

            migrationBuilder.DropColumn(
                name: "CurvePointY",
                table: "Edges");

            migrationBuilder.AddColumn<double>(
                name: "Curve",
                table: "Edges",
                nullable: false,
                defaultValue: 1.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Curve",
                table: "Edges");

            migrationBuilder.AddColumn<double>(
                name: "CurvePointX",
                table: "Edges",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CurvePointY",
                table: "Edges",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
