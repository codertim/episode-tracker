using Microsoft.EntityFrameworkCore.Migrations;

namespace EpisodeTracker.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    ShowId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    LastEpisodeSeen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.ShowId);
                });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "ShowId", "LastEpisodeSeen", "Title" },
                values: new object[] { 1, "Season 2 Ep. 3", "Lost" });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "ShowId", "LastEpisodeSeen", "Title" },
                values: new object[] { 2, "15", "Saved by the Bell" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shows");
        }
    }
}
