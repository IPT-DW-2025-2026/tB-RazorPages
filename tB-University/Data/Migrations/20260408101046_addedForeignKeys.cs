using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tB_University.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Registrations",
                table: "Registrations");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Registrations",
                newName: "CourseFk");

            migrationBuilder.AlterColumn<int>(
                name: "CourseFk",
                table: "Registrations",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "StudentFk",
                table: "Registrations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DegreeFk",
                table: "MyUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DegreeFk",
                table: "Courses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Registrations",
                table: "Registrations",
                columns: new[] { "StudentFk", "CourseFk" });

            migrationBuilder.CreateTable(
                name: "CourseTeacher",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeachersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTeacher", x => new { x.CoursesId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_CourseTeacher_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseTeacher_MyUsers_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "MyUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_CourseFk",
                table: "Registrations",
                column: "CourseFk");

            migrationBuilder.CreateIndex(
                name: "IX_MyUsers_DegreeFk",
                table: "MyUsers",
                column: "DegreeFk");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DegreeFk",
                table: "Courses",
                column: "DegreeFk");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTeacher_TeachersId",
                table: "CourseTeacher",
                column: "TeachersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Degrees_DegreeFk",
                table: "Courses",
                column: "DegreeFk",
                principalTable: "Degrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MyUsers_Degrees_DegreeFk",
                table: "MyUsers",
                column: "DegreeFk",
                principalTable: "Degrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Courses_CourseFk",
                table: "Registrations",
                column: "CourseFk",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_MyUsers_StudentFk",
                table: "Registrations",
                column: "StudentFk",
                principalTable: "MyUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Degrees_DegreeFk",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_MyUsers_Degrees_DegreeFk",
                table: "MyUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Courses_CourseFk",
                table: "Registrations");

            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_MyUsers_StudentFk",
                table: "Registrations");

            migrationBuilder.DropTable(
                name: "CourseTeacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Registrations",
                table: "Registrations");

            migrationBuilder.DropIndex(
                name: "IX_Registrations_CourseFk",
                table: "Registrations");

            migrationBuilder.DropIndex(
                name: "IX_MyUsers_DegreeFk",
                table: "MyUsers");

            migrationBuilder.DropIndex(
                name: "IX_Courses_DegreeFk",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "StudentFk",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "DegreeFk",
                table: "MyUsers");

            migrationBuilder.DropColumn(
                name: "DegreeFk",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "CourseFk",
                table: "Registrations",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Registrations",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Registrations",
                table: "Registrations",
                column: "Id");
        }
    }
}
