using Microsoft.EntityFrameworkCore.Migrations;

namespace CreationDbCodeFirstForEducationPrtal.Migrations
{
    public partial class addBookConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutorBook_Books_BookId",
                schema: "shc",
                table: "AutorBook");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                schema: "shc",
                table: "AutorBook",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Book",
                schema: "shc",
                table: "AutorBook",
                column: "BookId",
                principalSchema: "sch",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Book",
                schema: "shc",
                table: "AutorBook");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                schema: "shc",
                table: "AutorBook",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AutorBook_Books_BookId",
                schema: "shc",
                table: "AutorBook",
                column: "BookId",
                principalSchema: "sch",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
