using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCorePractice.Migrations
{
    public partial class AudioFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AudioFile",
                schema: "shc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Bitrate = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    SampleRate = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    ChannelCount = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioFile", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_AudioFile_File_Id",
                        column: x => x.Id,
                        principalSchema: "sch",
                        principalTable: "File",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AudioFile",
                schema: "shc");
        }
    }
}
