using Microsoft.EntityFrameworkCore.Migrations;

namespace ForumRowerowe.Data.Migrations
{
    public partial class addtablethreadssecondtry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Thread_ThreadID",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Thread",
                table: "Thread");

            migrationBuilder.RenameTable(
                name: "Thread",
                newName: "Threads");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Threads",
                table: "Threads",
                column: "ThreadID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Threads_ThreadID",
                table: "Posts",
                column: "ThreadID",
                principalTable: "Threads",
                principalColumn: "ThreadID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Threads_ThreadID",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Threads",
                table: "Threads");

            migrationBuilder.RenameTable(
                name: "Threads",
                newName: "Thread");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Thread",
                table: "Thread",
                column: "ThreadID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Thread_ThreadID",
                table: "Posts",
                column: "ThreadID",
                principalTable: "Thread",
                principalColumn: "ThreadID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
