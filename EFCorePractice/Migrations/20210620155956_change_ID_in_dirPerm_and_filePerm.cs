using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCorePractice.Migrations
{
    public partial class change_ID_in_dirPerm_and_filePerm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileId",
                schema: "sch",
                table: "FilePermissions",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_FilePermissions_FileId",
                schema: "sch",
                table: "FilePermissions",
                newName: "IX_FilePermissions_Id");

            migrationBuilder.RenameColumn(
                name: "DirectoryId",
                schema: "sch",
                table: "DirectoryPermissions",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "sch",
                table: "FilePermissions",
                newName: "FileId");

            migrationBuilder.RenameIndex(
                name: "IX_FilePermissions_Id",
                schema: "sch",
                table: "FilePermissions",
                newName: "IX_FilePermissions_FileId");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "sch",
                table: "DirectoryPermissions",
                newName: "DirectoryId");
        }
    }
}
