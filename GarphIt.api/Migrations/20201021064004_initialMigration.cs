using Microsoft.EntityFrameworkCore.Migrations;

namespace GarphIt.api.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nodes",
                columns: table => new
                {
                    NodeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Xaxis = table.Column<double>(nullable: false),
                    Yaxis = table.Column<double>(nullable: false),
                    Radius = table.Column<int>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    LabelColor = table.Column<string>(nullable: false),
                    NodeColor = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nodes", x => x.NodeId);
                });

            migrationBuilder.CreateTable(
                name: "Edges",
                columns: table => new
                {
                    EdgeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeadId = table.Column<int>(nullable: false),
                    TailId = table.Column<int>(nullable: true),
                    Weight = table.Column<double>(nullable: false, defaultValue: 1.0),
                    Label = table.Column<string>(nullable: true),
                    LabelColor = table.Column<string>(nullable: false),
                    EdgeColor = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edges", x => x.EdgeId);
                    table.ForeignKey(
                        name: "FK_Edges_Nodes_HeadId",
                        column: x => x.HeadId,
                        principalTable: "Nodes",
                        principalColumn: "NodeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Edges_Nodes_TailId",
                        column: x => x.TailId,
                        principalTable: "Nodes",
                        principalColumn: "NodeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Edges_HeadId",
                table: "Edges",
                column: "HeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Edges_TailId",
                table: "Edges",
                column: "TailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Edges");

            migrationBuilder.DropTable(
                name: "Nodes");
        }
    }
}
