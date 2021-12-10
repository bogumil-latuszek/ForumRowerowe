using Microsoft.EntityFrameworkCore.Migrations;

namespace ForumRowerowe.Data.Migrations
{
    public partial class addthreadtablein1to2relationwithpost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ThreadID",
                table: "Posts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThreadID",
                table: "Posts");
        }
    }
}
