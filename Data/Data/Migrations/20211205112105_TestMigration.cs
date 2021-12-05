using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class TestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "CategoryID",
            //    table: "Bookmark",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Bookmark_CategoryID",
            //    table: "Bookmark",
            //    column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmark_Categories_CategoryID",
                table: "Bookmark",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmark_Categories_CategoryID",
                table: "Bookmark");

            migrationBuilder.DropIndex(
                name: "IX_Bookmark_CategoryID",
                table: "Bookmark");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Bookmark");
        }
    }
}
