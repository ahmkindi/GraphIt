using Microsoft.EntityFrameworkCore.Migrations;

namespace GarphIt.api.Migrations
{
    public partial class initial : Migration
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
                    HeadNodeId = table.Column<int>(nullable: false),
                    TailNodeId = table.Column<int>(nullable: false),
                    CurvePointX = table.Column<double>(nullable: false),
                    CurvePointY = table.Column<double>(nullable: false),
                    Weight = table.Column<double>(nullable: false, defaultValue: 1.0),
                    Label = table.Column<string>(nullable: true),
                    Width = table.Column<int>(nullable: false),
                    Directed = table.Column<bool>(nullable: false),
                    LabelColor = table.Column<string>(nullable: false),
                    EdgeColor = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edges", x => x.EdgeId);
                    table.ForeignKey(
                        name: "FK_Edges_Nodes_HeadNodeId",
                        column: x => x.HeadNodeId,
                        principalTable: "Nodes",
                        principalColumn: "NodeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Edges_Nodes_TailNodeId",
                        column: x => x.TailNodeId,
                        principalTable: "Nodes",
                        principalColumn: "NodeId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Edges_HeadNodeId",
                table: "Edges",
                column: "HeadNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Edges_TailNodeId",
                table: "Edges",
                column: "TailNodeId");
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
