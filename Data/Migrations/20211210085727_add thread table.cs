using Microsoft.EntityFrameworkCore.Migrations;

namespace ForumRowerowe.Data.Migrations
{
    public partial class addthreadtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Thread",
                columns: table => new
                {
                    ThreadID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thread", x => x.ThreadID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ThreadID",
                table: "Posts",
                column: "ThreadID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Thread_ThreadID",
                table: "Posts",
                column: "ThreadID",
                principalTable: "Thread",
                principalColumn: "ThreadID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Thread_ThreadID",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Thread");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ThreadID",
                table: "Posts");
        }
    }
}
