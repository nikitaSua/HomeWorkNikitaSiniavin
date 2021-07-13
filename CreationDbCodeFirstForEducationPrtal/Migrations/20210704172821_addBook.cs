using Microsoft.EntityFrameworkCore.Migrations;

namespace CreationDbCodeFirstForEducationPrtal.Migrations
{
    public partial class addBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "shc");

            migrationBuilder.EnsureSchema(
                name: "sch");

            migrationBuilder.CreateTable(
                name: "Autor",
                schema: "shc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                schema: "shc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NumOfPage = table.Column<int>(type: "int", nullable: false),
                    YearOfPublishing = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Books_Materials_Id",
                        column: x => x.Id,
                        principalSchema: "sch",
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseMaterial",
                schema: "shc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    MaterialId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseMaterial_Course_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "shc",
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseMaterial_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalSchema: "sch",
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_User_Role",
                        column: x => x.RoleId,
                        principalSchema: "sch",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaterialSkill",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialSkill", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_MaterialSkill_Material",
                        column: x => x.MaterialId,
                        principalSchema: "sch",
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaterialSkill_Skill",
                        column: x => x.SkillId,
                        principalSchema: "sch",
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AutorBook",
                schema: "shc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AutorId = table.Column<int>(type: "int", nullable: true),
                    BookId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorBook", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutorBook_Autor_AutorId",
                        column: x => x.AutorId,
                        principalSchema: "shc",
                        principalTable: "Autor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AutorBook_Books_BookId",
                        column: x => x.BookId,
                        principalSchema: "sch",
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseUser",
                schema: "shc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseUser_Course_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "shc",
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseUser_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "sch",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserSkill",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkill", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Skill_UserSkill",
                        column: x => x.SkillId,
                        principalSchema: "sch",
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_UserSkill",
                        column: x => x.UserId,
                        principalSchema: "sch",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutorBook_AutorId",
                schema: "shc",
                table: "AutorBook",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_AutorBook_BookId",
                schema: "shc",
                table: "AutorBook",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMaterial_CourseId",
                schema: "shc",
                table: "CourseMaterial",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMaterial_MaterialId",
                schema: "shc",
                table: "CourseMaterial",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseUser_CourseId",
                schema: "shc",
                table: "CourseUser",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseUser_UserId",
                schema: "shc",
                table: "CourseUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialSkill_MaterialId",
                schema: "sch",
                table: "MaterialSkill",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialSkill_SkillId",
                schema: "sch",
                table: "MaterialSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                schema: "sch",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkill_SkillId",
                schema: "sch",
                table: "UserSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkill_UserId",
                schema: "sch",
                table: "UserSkill",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutorBook",
                schema: "shc");

            migrationBuilder.DropTable(
                name: "CourseMaterial",
                schema: "shc");

            migrationBuilder.DropTable(
                name: "CourseUser",
                schema: "shc");

            migrationBuilder.DropTable(
                name: "MaterialSkill",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "UserSkill",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "Autor",
                schema: "shc");

            migrationBuilder.DropTable(
                name: "Books",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "Course",
                schema: "shc");

            migrationBuilder.DropTable(
                name: "Skills",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "Materials",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "sch");
        }
    }
}
