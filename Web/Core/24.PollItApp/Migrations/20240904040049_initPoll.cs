using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PollItApp.Migrations
{
    /// <inheritdoc />
    public partial class initPoll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Polls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Q1 = table.Column<int>(type: "int", nullable: false),
                    Q2 = table.Column<int>(type: "int", nullable: false),
                    Q10 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polls", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Polls");
        }
    }
}
