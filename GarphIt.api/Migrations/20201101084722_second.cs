using Microsoft.EntityFrameworkCore.Migrations;

namespace GarphIt.api.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Edges_HeadNodeId_TailNodeId",
                table: "Edges");

            migrationBuilder.CreateIndex(
                name: "IX_Edges_HeadNodeId",
                table: "Edges",
                column: "HeadNodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Edges_HeadNodeId",
                table: "Edges");

            migrationBuilder.CreateIndex(
                name: "IX_Edges_HeadNodeId_TailNodeId",
                table: "Edges",
                columns: new[] { "HeadNodeId", "TailNodeId" },
                unique: true);
        }
    }
}
