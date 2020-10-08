using Microsoft.EntityFrameworkCore.Migrations;

namespace GarphIt.api.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Edges",
                columns: table => new
                {
                    EdgeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeadId = table.Column<int>(nullable: false),
                    TailId = table.Column<int>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    LabelColor = table.Column<string>(nullable: false),
                    EdgeColor = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edges", x => x.EdgeId);
                });

            migrationBuilder.CreateTable(
                name: "Nodes",
                columns: table => new
                {
                    NodeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Xaxis = table.Column<double>(nullable: false),
                    Yaxis = table.Column<double>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    LabelColor = table.Column<string>(nullable: false),
                    NodeColor = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nodes", x => x.NodeId);
                });

            migrationBuilder.InsertData(
                table: "Edges",
                columns: new[] { "EdgeId", "EdgeColor", "HeadId", "Label", "LabelColor", "TailId", "Weight" },
                values: new object[] { 1, "#000000", 1, "Hello", "#dd1122", 2, 10.119999999999999 });

            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "NodeId", "Label", "LabelColor", "NodeColor", "Xaxis", "Yaxis" },
                values: new object[] { 1, "Hello", "#dd1122", "#000000", 10.119999999999999, 11.109999999999999 });

            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "NodeId", "Label", "LabelColor", "NodeColor", "Xaxis", "Yaxis" },
                values: new object[] { 2, "Bye", "#aabbcc", "#123456", 1.0, 13.44 });
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
