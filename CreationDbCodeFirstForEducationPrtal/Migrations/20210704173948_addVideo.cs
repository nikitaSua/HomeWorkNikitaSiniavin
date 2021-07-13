using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CreationDbCodeFirstForEducationPrtal.Migrations
{
    public partial class addVideo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Videos",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Quality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Videos_Materials_Id",
                        column: x => x.Id,
                        principalSchema: "sch",
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Videos",
                schema: "sch");
        }
    }
}
