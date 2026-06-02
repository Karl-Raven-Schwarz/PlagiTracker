using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PlagiTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "plagi_tracker");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "plagi_tracker",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: false),
                    LogInAttempts = table.Column<int>(type: "integer", nullable: false),
                    IsLocked = table.Column<bool>(type: "boolean", nullable: false),
                    UnlockDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VerificationCode = table.Column<int>(type: "integer", nullable: false),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false),
                    VerificationCodeExpiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ResetPasswordAttempts = table.Column<int>(type: "integer", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                schema: "plagi_tracker",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Users_Id",
                        column: x => x.Id,
                        principalSchema: "plagi_tracker",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                schema: "plagi_tracker",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Users_Id",
                        column: x => x.Id,
                        principalSchema: "plagi_tracker",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                schema: "plagi_tracker",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InvitationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalSchema: "plagi_tracker",
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                schema: "plagi_tracker",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    SubmissionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AnalysisDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsAnalyzed = table.Column<bool>(type: "boolean", nullable: false),
                    DolosURLId = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "plagi_tracker",
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                schema: "plagi_tracker",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    Grade = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "plagi_tracker",
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "plagi_tracker",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                schema: "plagi_tracker",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    HaveBody = table.Column<bool>(type: "boolean", nullable: false),
                    AssignmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalSchema: "plagi_tracker",
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Submissions",
                schema: "plagi_tracker",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Url = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    SubmissionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Grade = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    Compiler = table.Column<int>(type: "integer", nullable: false),
                    UrlState = table.Column<int>(type: "integer", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    AssignmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Submissions_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalSchema: "plagi_tracker",
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Submissions_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "plagi_tracker",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                schema: "plagi_tracker",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ExerciseId = table.Column<Guid>(type: "uuid", nullable: false),
                    ParentClassId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_Classes_ParentClassId",
                        column: x => x.ParentClassId,
                        principalSchema: "plagi_tracker",
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Classes_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalSchema: "plagi_tracker",
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Codes",
                schema: "plagi_tracker",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubmissionId = table.Column<Guid>(type: "uuid", nullable: false),
                    FileName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Codes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Codes_Submissions_SubmissionId",
                        column: x => x.SubmissionId,
                        principalSchema: "plagi_tracker",
                        principalTable: "Submissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Methods",
                schema: "plagi_tracker",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    ParameterTypes = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ClassId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Methods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Methods_Classes_ClassId",
                        column: x => x.ClassId,
                        principalSchema: "plagi_tracker",
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plagiarisms",
                schema: "plagi_tracker",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Similarity = table.Column<double>(type: "numeric(5,2)", nullable: false),
                    Coincidences = table.Column<int>(type: "integer", nullable: false),
                    CodeSnippet = table.Column<string>(type: "text", nullable: true),
                    CodeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Algorithm = table.Column<int>(type: "integer", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plagiarisms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plagiarisms_Codes_CodeId",
                        column: x => x.CodeId,
                        principalSchema: "plagi_tracker",
                        principalTable: "Codes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parameter",
                schema: "plagi_tracker",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    MethodId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parameter_Methods_MethodId",
                        column: x => x.MethodId,
                        principalSchema: "plagi_tracker",
                        principalTable: "Methods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "plagi_tracker",
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "IsEnabled", "IsLocked", "IsVerified", "LastName", "LogInAttempts", "PasswordHash", "ResetPasswordAttempts", "UnlockDate", "UpdatedAt", "VerificationCode", "VerificationCodeExpiration" },
                values: new object[,]
                {
                    { new Guid("0392d24c-a1f5-4022-8278-cfa4efb14b8c"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), "lkennedy@plagitracker.com", "Luisfelipe", true, false, false, "Kennedy", 2, new byte[] { 94, 136, 72, 152, 218, 40, 4, 113, 81, 208, 229, 111, 141, 198, 41, 39, 115, 96, 61, 13, 106, 171, 189, 214, 42, 17, 239, 114, 29, 21, 66, 216, 175, 220, 117, 12, 253, 183, 88, 119, 47, 192, 90, 98, 73, 23, 199, 108 }, 0, new DateTime(2024, 10, 8, 0, 53, 2, 247, DateTimeKind.Utc), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), 0, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("12bedd1a-d7c6-4b54-aeb5-507ef12d4f83"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), "btennyson@plagitracker.com", "Ben", true, true, false, "Tennyson", 3, new byte[] { 94, 136, 72, 152, 218, 40, 4, 113, 81, 208, 229, 111, 141, 198, 41, 39, 115, 96, 61, 13, 106, 171, 189, 214, 42, 17, 239, 114, 29, 21, 66, 216, 175, 220, 117, 12, 253, 183, 88, 119, 47, 192, 90, 98, 73, 23, 199, 108 }, 0, new DateTime(2024, 10, 27, 10, 50, 1, 462, DateTimeKind.Utc).AddTicks(3040), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), 0, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("1979d2a7-de35-4d83-9aa9-857171cba7fa"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), "ptorres@plagitracker.com", "Pedro", true, false, false, "Torres", 0, new byte[] { 94, 136, 72, 152, 218, 40, 4, 113, 81, 208, 229, 111, 141, 198, 41, 39, 115, 96, 61, 13, 106, 171, 189, 214, 42, 17, 239, 114, 29, 21, 66, 216, 175, 220, 117, 12, 253, 183, 88, 119, 47, 192, 90, 98, 73, 23, 199, 108 }, 0, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), 0, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("239e66d0-16c3-4ce4-b321-058b64269f5e"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), "kkvaratskhelia@plagitracker.com", "Khvicha", true, false, false, "Kvaratskhelia", 0, new byte[] { 94, 136, 72, 152, 218, 40, 4, 113, 81, 208, 229, 111, 141, 198, 41, 39, 115, 96, 61, 13, 106, 171, 189, 214, 42, 17, 239, 114, 29, 21, 66, 216, 175, 220, 117, 12, 253, 183, 88, 119, 47, 192, 90, 98, 73, 23, 199, 108 }, 0, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), 0, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("38141a4f-bc22-4514-8f9b-139a11b004b2"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), "ahurtadoc@ulasalle.edu.pe", "Aron", true, false, false, "Hurtado", 0, new byte[] { 94, 136, 72, 152, 218, 40, 4, 113, 81, 208, 229, 111, 141, 198, 41, 39, 115, 96, 61, 13, 106, 171, 189, 214, 42, 17, 239, 114, 29, 21, 66, 216 }, 0, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), 10000000, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("38141a4f-bc22-4514-8f9b-139a11b004b8"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), "bschweinsteiger@plagitracker.com", "Bastian", true, false, false, "Schweinsteiger", 0, new byte[] { 94, 136, 72, 152, 218, 40, 4, 113, 81, 208, 229, 111, 141, 198, 41, 39, 115, 96, 61, 13, 106, 171, 189, 214, 42, 17, 239, 114, 29, 21, 66, 216 }, 0, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), 10000000, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("5500125e-16f5-4b77-9220-cc4dab69c102"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), "pillanes@plagitracker.com", "Pablo", true, false, false, "Illanes", 0, new byte[] { 94, 136, 72, 152, 218, 40, 4, 113, 81, 208, 229, 111, 141, 198, 41, 39, 115, 96, 61, 13, 106, 171, 189, 214, 42, 17, 239, 114, 29, 21, 66, 216, 175, 220, 117, 12, 253, 183, 88, 119, 47, 192, 90, 98, 73, 23, 199, 108 }, 0, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), 0, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("865bf0cc-1fe7-4203-944e-f353540d7210"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), "lluquen@ulasalle.edu.pe", "Luis Fernando", true, false, false, "Luque Nieto", 0, new byte[] { 94, 136, 72, 152, 218, 40, 4, 113, 81, 208, 229, 111, 141, 198, 41, 39, 115, 96, 61, 13, 106, 171, 189, 214, 42, 17, 239, 114, 29, 21, 66, 216 }, 0, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), 10000000, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("8d676dc9-1a50-48f6-aa83-cb47535c5af3"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), "elmerson30@plagitracker.com", "Elmerson", true, false, false, "Ferito", 0, new byte[] { 94, 136, 72, 152, 218, 40, 4, 113, 81, 208, 229, 111, 141, 198, 41, 39, 115, 96, 61, 13, 106, 171, 189, 214, 42, 17, 239, 114, 29, 21, 66, 216, 175, 220, 117, 12, 253, 183, 88, 119, 47, 192, 90, 98, 73, 23, 199, 108 }, 0, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), 0, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("9b934e06-3abd-4b8d-b45f-7e2106b4bc74"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), "knurmagomedov@plagitracker.com", "Khabib", true, false, false, "Nurmagomedov", 0, new byte[] { 94, 136, 72, 152, 218, 40, 4, 113, 81, 208, 229, 111, 141, 198, 41, 39, 115, 96, 61, 13, 106, 171, 189, 214, 42, 17, 239, 114, 29, 21, 66, 216, 175, 220, 117, 12, 253, 183, 88, 119, 47, 192, 90, 98, 73, 23, 199, 108 }, 0, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), 0, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("a37b3252-3e54-4199-8c4b-728238fc76b8"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), "kpachac@ulasalle.edu.pe", "Daoblur", true, false, false, "Álvarez", 0, new byte[] { 94, 136, 72, 152, 218, 40, 4, 113, 81, 208, 229, 111, 141, 198, 41, 39, 115, 96, 61, 13, 106, 171, 189, 214, 42, 17, 239, 114, 29, 21, 66, 216, 175, 220, 117, 12, 253, 183, 88, 119, 47, 192, 90, 98, 73, 23, 199, 108 }, 0, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), 10000000, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("aa597a6c-b219-4743-b5c6-8740551e79e0"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), "ittitoc@ulasalle.edu.pe", "Isabel Karina", true, false, false, "Ttito Campos", 0, new byte[] { 94, 136, 72, 152, 218, 40, 4, 113, 81, 208, 229, 111, 141, 198, 41, 39, 115, 96, 61, 13, 106, 171, 189, 214, 42, 17, 239, 114, 29, 21, 66, 216 }, 0, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), 10000000, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("af2eff91-54b0-43b4-91c4-57b7e2d62f15"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), "rkadyrov@plagitracker.com", "Ramzan", true, false, false, "Kadyrov", 0, new byte[] { 94, 136, 72, 152, 218, 40, 4, 113, 81, 208, 229, 111, 141, 198, 41, 39, 115, 96, 61, 13, 106, 171, 189, 214, 42, 17, 239, 114, 29, 21, 66, 216, 175, 220, 117, 12, 253, 183, 88, 119, 47, 192, 90, 98, 73, 23, 199, 108 }, 0, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), 0, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("e7c43279-2bcc-4c09-9165-b824041166fc"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), "avonkageneck@plagitracker.com", "August", true, false, false, "von Kageneck", 0, new byte[] { 94, 136, 72, 152, 218, 40, 4, 113, 81, 208, 229, 111, 141, 198, 41, 39, 115, 96, 61, 13, 106, 171, 189, 214, 42, 17, 239, 114, 29, 21, 66, 216, 175, 220, 117, 12, 253, 183, 88, 119, 47, 192, 90, 98, 73, 23, 199, 108 }, 0, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), 0, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                schema: "plagi_tracker",
                table: "Students",
                column: "Id",
                values: new object[]
                {
                    new Guid("12bedd1a-d7c6-4b54-aeb5-507ef12d4f83"),
                    new Guid("1979d2a7-de35-4d83-9aa9-857171cba7fa"),
                    new Guid("239e66d0-16c3-4ce4-b321-058b64269f5e"),
                    new Guid("38141a4f-bc22-4514-8f9b-139a11b004b2"),
                    new Guid("38141a4f-bc22-4514-8f9b-139a11b004b8"),
                    new Guid("8d676dc9-1a50-48f6-aa83-cb47535c5af3"),
                    new Guid("9b934e06-3abd-4b8d-b45f-7e2106b4bc74"),
                    new Guid("a37b3252-3e54-4199-8c4b-728238fc76b8"),
                    new Guid("af2eff91-54b0-43b4-91c4-57b7e2d62f15"),
                    new Guid("e7c43279-2bcc-4c09-9165-b824041166fc")
                });

            migrationBuilder.InsertData(
                schema: "plagi_tracker",
                table: "Teachers",
                column: "Id",
                values: new object[]
                {
                    new Guid("0392d24c-a1f5-4022-8278-cfa4efb14b8c"),
                    new Guid("5500125e-16f5-4b77-9220-cc4dab69c102"),
                    new Guid("865bf0cc-1fe7-4203-944e-f353540d7210"),
                    new Guid("aa597a6c-b219-4743-b5c6-8740551e79e0")
                });

            migrationBuilder.InsertData(
                schema: "plagi_tracker",
                table: "Courses",
                columns: new[] { "Id", "CreatedAt", "InvitationId", "IsArchived", "IsEnabled", "Name", "TeacherId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("5500125e-16f5-4b77-9220-cc4dab69c100"), new DateTime(2024, 10, 10, 15, 10, 10, 100, DateTimeKind.Utc), new Guid("5500125e-16f5-4b77-9220-cc4dab69c100"), false, true, "Programming Language I", new Guid("0392d24c-a1f5-4022-8278-cfa4efb14b8c"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("aa597a6c-b219-4743-b5c6-8740551e88a1"), new DateTime(2024, 10, 10, 15, 10, 10, 100, DateTimeKind.Utc), new Guid("aa597a6c-b219-4743-b5c6-8740551e88a2"), false, true, "Programming Language II", new Guid("aa597a6c-b219-4743-b5c6-8740551e79e0"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("aa597a6c-b219-4743-b5c6-8740551e88a3"), new DateTime(2024, 10, 10, 15, 10, 10, 100, DateTimeKind.Utc), new Guid("aa597a6c-b219-4743-b5c6-8740551e88a4"), false, true, "Programming Language III", new Guid("aa597a6c-b219-4743-b5c6-8740551e79e0"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("aa597a6c-b219-4743-b5c6-8740551e88a5"), new DateTime(2024, 10, 10, 15, 10, 10, 100, DateTimeKind.Utc), new Guid("aa597a6c-b219-4743-b5c6-8740551e88a6"), false, true, "Data Structure I", new Guid("aa597a6c-b219-4743-b5c6-8740551e79e0"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("aa597a6c-b219-4743-b5c6-8740551e88a7"), new DateTime(2024, 10, 10, 15, 10, 10, 100, DateTimeKind.Utc), new Guid("aa597a6c-b219-4743-b5c6-8740551e88a8"), false, true, "Data Structure II", new Guid("aa597a6c-b219-4743-b5c6-8740551e79e0"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("aa597a6c-b219-4743-b5c6-8740551e88a9"), new DateTime(2024, 10, 10, 15, 10, 10, 100, DateTimeKind.Utc), new Guid("aa597a6c-b219-4743-b5c6-8740551e88e0"), false, true, "Analysis and Design of Algorithms I", new Guid("aa597a6c-b219-4743-b5c6-8740551e79e0"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("aa597a6c-b219-4743-b5c6-8740551e88b1"), new DateTime(2024, 10, 10, 15, 10, 10, 100, DateTimeKind.Utc), new Guid("aa597a6c-b219-4743-b5c6-8740551e88b1"), false, true, "Analysis and Design of Algorithms II", new Guid("aa597a6c-b219-4743-b5c6-8740551e79e0"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("aa597a6c-b219-4743-b5c6-8740551e88b2"), new DateTime(2024, 10, 10, 15, 10, 10, 100, DateTimeKind.Utc), new Guid("aa597a6c-b219-4743-b5c6-8740551e88d2"), false, true, "Fundamentals of Programming Languages", new Guid("aa597a6c-b219-4743-b5c6-8740551e79e0"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("bf9ee4c7-b051-4dd8-ba56-101f2688888c"), new DateTime(2024, 10, 10, 15, 10, 10, 100, DateTimeKind.Utc), new Guid("bf9ee4c7-b051-4dd8-ba56-101f2688888c"), false, true, "Introduction to Programming", new Guid("0392d24c-a1f5-4022-8278-cfa4efb14b8c"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                schema: "plagi_tracker",
                table: "Assignments",
                columns: new[] { "Id", "AnalysisDate", "CourseId", "CreatedAt", "Description", "DolosURLId", "IsAnalyzed", "IsEnabled", "SubmissionDate", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("025f1811-79ec-43b2-9693-652fa2f7bdb1"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), new Guid("5500125e-16f5-4b77-9220-cc4dab69c100"), new DateTime(2024, 11, 18, 0, 48, 36, 691, DateTimeKind.Utc).AddTicks(7520), null, "8299776248912629284", false, true, new DateTime(2024, 12, 25, 0, 43, 58, 850, DateTimeKind.Utc), "Programación Orientada a Objetos 3", new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("ac85b4e5-33ea-4d2c-a281-f7ec41da15f7"), new DateTime(2024, 10, 9, 23, 40, 4, 711, DateTimeKind.Utc).AddTicks(5580), new Guid("5500125e-16f5-4b77-9220-cc4dab69c100"), new DateTime(2024, 11, 18, 0, 46, 30, 389, DateTimeKind.Utc), "", null, true, true, new DateTime(2024, 12, 7, 15, 14, 26, 713, DateTimeKind.Utc), "Programación Orientada a Objetos", new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("e4be8d12-8d5e-43d2-817c-b5987043404d"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), new Guid("5500125e-16f5-4b77-9220-cc4dab69c100"), new DateTime(2024, 11, 18, 0, 46, 30, 389, DateTimeKind.Utc), "Ninguna", "3950420146690480254", false, true, new DateTime(2024, 12, 25, 0, 43, 58, 850, DateTimeKind.Utc), "Cylinder", new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("e4be8d12-8d5e-43d2-817c-b5997043304d"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), new Guid("5500125e-16f5-4b77-9220-cc4dab69c100"), new DateTime(2024, 11, 18, 0, 46, 30, 389, DateTimeKind.Utc).AddTicks(3520), "Ninguna", null, false, true, new DateTime(2024, 12, 25, 0, 43, 58, 850, DateTimeKind.Utc), "Programación Orientada a Objetos 2", new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                schema: "plagi_tracker",
                table: "Enrollments",
                columns: new[] { "CourseId", "StudentId", "CreatedAt", "Grade", "IsEnabled", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("5500125e-16f5-4b77-9220-cc4dab69c100"), new Guid("12bedd1a-d7c6-4b54-aeb5-507ef12d4f83"), new DateTime(2024, 11, 17, 12, 59, 31, 81, DateTimeKind.Utc), 0.0, true, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("5500125e-16f5-4b77-9220-cc4dab69c100"), new Guid("1979d2a7-de35-4d83-9aa9-857171cba7fa"), new DateTime(2024, 11, 17, 12, 59, 31, 81, DateTimeKind.Utc), 0.0, true, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("5500125e-16f5-4b77-9220-cc4dab69c100"), new Guid("239e66d0-16c3-4ce4-b321-058b64269f5e"), new DateTime(2024, 11, 17, 12, 59, 31, 81, DateTimeKind.Utc), 0.0, true, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("5500125e-16f5-4b77-9220-cc4dab69c100"), new Guid("38141a4f-bc22-4514-8f9b-139a11b004b2"), new DateTime(2024, 11, 6, 4, 56, 54, 940, DateTimeKind.Utc).AddTicks(6620), 0.0, true, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("5500125e-16f5-4b77-9220-cc4dab69c100"), new Guid("38141a4f-bc22-4514-8f9b-139a11b004b8"), new DateTime(2024, 11, 6, 4, 8, 45, 690, DateTimeKind.Utc).AddTicks(1410), 0.0, true, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("bf9ee4c7-b051-4dd8-ba56-101f2688888c"), new Guid("38141a4f-bc22-4514-8f9b-139a11b004b8"), new DateTime(2024, 11, 6, 4, 8, 40, 787, DateTimeKind.Utc).AddTicks(8820), 0.0, true, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("5500125e-16f5-4b77-9220-cc4dab69c100"), new Guid("8d676dc9-1a50-48f6-aa83-cb47535c5af3"), new DateTime(2024, 11, 17, 12, 59, 31, 81, DateTimeKind.Utc).AddTicks(3270), 0.0, true, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("bf9ee4c7-b051-4dd8-ba56-101f2688888c"), new Guid("8d676dc9-1a50-48f6-aa83-cb47535c5af3"), new DateTime(2024, 11, 17, 12, 49, 21, 232, DateTimeKind.Utc).AddTicks(9780), 0.0, true, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("5500125e-16f5-4b77-9220-cc4dab69c100"), new Guid("9b934e06-3abd-4b8d-b45f-7e2106b4bc74"), new DateTime(2024, 11, 17, 12, 59, 31, 81, DateTimeKind.Utc), 0.0, true, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("5500125e-16f5-4b77-9220-cc4dab69c100"), new Guid("a37b3252-3e54-4199-8c4b-728238fc76b8"), new DateTime(2024, 11, 6, 4, 59, 6, 498, DateTimeKind.Utc).AddTicks(9810), 0.0, true, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("5500125e-16f5-4b77-9220-cc4dab69c100"), new Guid("af2eff91-54b0-43b4-91c4-57b7e2d62f15"), new DateTime(2024, 11, 17, 12, 59, 31, 81, DateTimeKind.Utc), 0.0, true, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("5500125e-16f5-4b77-9220-cc4dab69c100"), new Guid("e7c43279-2bcc-4c09-9165-b824041166fc"), new DateTime(2024, 11, 17, 12, 59, 31, 81, DateTimeKind.Utc), 0.0, true, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                schema: "plagi_tracker",
                table: "Submissions",
                columns: new[] { "Id", "AssignmentId", "Compiler", "CreatedAt", "Grade", "IsEnabled", "StudentId", "SubmissionDate", "UpdatedAt", "Url", "UrlState" },
                values: new object[,]
                {
                    { new Guid("14cabe76-3398-4429-ad34-01679f08acb9"), new Guid("025f1811-79ec-43b2-9693-652fa2f7bdb1"), 1, new DateTime(2024, 11, 18, 14, 35, 49, 879, DateTimeKind.Utc).AddTicks(1230), 0.0, true, new Guid("9b934e06-3abd-4b8d-b45f-7e2106b4bc74"), new DateTime(2024, 11, 18, 14, 28, 25, 801, DateTimeKind.Utc), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), "https://www.onlinegdb.com/bdoucGuWb", 3 },
                    { new Guid("22e13d14-0349-49df-9fc9-ff6c9bbb4bd8"), new Guid("e4be8d12-8d5e-43d2-817c-b5987043404d"), 1, new DateTime(2024, 11, 18, 18, 46, 4, 173, DateTimeKind.Utc).AddTicks(5290), 0.0, true, new Guid("8d676dc9-1a50-48f6-aa83-cb47535c5af3"), new DateTime(2024, 11, 18, 14, 22, 25, 801, DateTimeKind.Utc), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), "https://onlinegdb.com/EsUiHpxUO", 3 },
                    { new Guid("31edb16a-feb4-4cab-812c-e8a4bdb6ad45"), new Guid("ac85b4e5-33ea-4d2c-a281-f7ec41da15f7"), 0, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), 0.0, true, new Guid("239e66d0-16c3-4ce4-b321-058b64269f5e"), new DateTime(2024, 10, 7, 15, 55, 31, 51, DateTimeKind.Utc), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), "https://www.codiva.io/p/925bfea6-e307-4cbb-8e43-dbf634ec7325", 3 },
                    { new Guid("6252ac2f-e197-4ec3-821f-56ef3dffc72c"), new Guid("ac85b4e5-33ea-4d2c-a281-f7ec41da15f7"), 0, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), 0.0, true, new Guid("e7c43279-2bcc-4c09-9165-b824041166fc"), new DateTime(2024, 10, 7, 15, 15, 31, 51, DateTimeKind.Utc), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), "https://www.codiva.io/p/dbc162b6-5afe-46bf-b4b3-ee42f11c37c4", 3 },
                    { new Guid("6e701991-2a14-4493-a170-f4fe910e9c4a"), new Guid("ac85b4e5-33ea-4d2c-a281-f7ec41da15f7"), 0, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), 0.0, true, new Guid("12bedd1a-d7c6-4b54-aeb5-507ef12d4f83"), new DateTime(2024, 10, 7, 15, 5, 31, 51, DateTimeKind.Utc), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), "https://www.codiva.io/p/9f4e0e63-82d0-4241-b0bf-e12ae7a9b700", 3 },
                    { new Guid("7397a9ce-94a9-4e5b-9cbb-215f061b197e"), new Guid("025f1811-79ec-43b2-9693-652fa2f7bdb1"), 1, new DateTime(2024, 11, 18, 1, 28, 27, 708, DateTimeKind.Utc).AddTicks(3710), 0.0, true, new Guid("38141a4f-bc22-4514-8f9b-139a11b004b8"), new DateTime(2024, 11, 18, 1, 27, 14, 246, DateTimeKind.Utc), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), "https://www.onlinegdb.com/zWDNPiT9M", 3 },
                    { new Guid("7d0f9c15-9e1b-4301-8b6e-7812cca1d451"), new Guid("025f1811-79ec-43b2-9693-652fa2f7bdb1"), 1, new DateTime(2024, 11, 18, 0, 27, 21, 610, DateTimeKind.Utc).AddTicks(5890), 0.0, true, new Guid("8d676dc9-1a50-48f6-aa83-cb47535c5af3"), new DateTime(2024, 11, 18, 0, 12, 19, 911, DateTimeKind.Utc), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), "https://www.onlinegdb.com/cky2lPU84", 3 },
                    { new Guid("9fd9c7a4-266a-4032-9ed2-4e03a02dfdf4"), new Guid("e4be8d12-8d5e-43d2-817c-b5987043404d"), 1, new DateTime(2024, 11, 18, 18, 33, 47, 981, DateTimeKind.Utc).AddTicks(2120), 0.0, true, new Guid("38141a4f-bc22-4514-8f9b-139a11b004b2"), new DateTime(2024, 11, 18, 14, 27, 25, 801, DateTimeKind.Utc), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), "https://onlinegdb.com/lgantTSY2", 3 },
                    { new Guid("b6c2d5e1-33c4-4048-820b-03d25fe674b9"), new Guid("ac85b4e5-33ea-4d2c-a281-f7ec41da15f7"), 0, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), 0.0, true, new Guid("af2eff91-54b0-43b4-91c4-57b7e2d62f15"), new DateTime(2024, 10, 7, 15, 35, 31, 51, DateTimeKind.Utc), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), "https://www.codiva.io/p/dbc162b6-5afe-46bf-b4b3-ee42f11c37c3", 3 },
                    { new Guid("d00b5731-977d-41cf-b8bf-7f693cb8d97b"), new Guid("e4be8d12-8d5e-43d2-817c-b5987043404d"), 1, new DateTime(2024, 11, 18, 18, 30, 52, 604, DateTimeKind.Utc).AddTicks(8630), 0.0, true, new Guid("38141a4f-bc22-4514-8f9b-139a11b004b2"), new DateTime(2024, 11, 18, 14, 27, 25, 801, DateTimeKind.Utc), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), "https://onlinegdb.com/lgantTSY2", 3 },
                    { new Guid("e0d30fd2-1027-4af3-be3b-238a579dacb8"), new Guid("ac85b4e5-33ea-4d2c-a281-f7ec41da15f7"), 0, new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), 0.0, true, new Guid("9b934e06-3abd-4b8d-b45f-7e2106b4bc74"), new DateTime(2024, 10, 7, 15, 36, 31, 51, DateTimeKind.Utc), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), "https://www.codiva.io/p/e0f1785e-40a2-4174-a00d-e76fbcfc95f8", 3 },
                    { new Guid("fe8eb5ea-7686-4539-b13b-51bf931d36bb"), new Guid("025f1811-79ec-43b2-9693-652fa2f7bdb1"), 0, new DateTime(2024, 11, 18, 18, 3, 38, 659, DateTimeKind.Utc).AddTicks(3250), 0.0, true, new Guid("12bedd1a-d7c6-4b54-aeb5-507ef12d4f83"), new DateTime(2024, 11, 18, 14, 28, 25, 801, DateTimeKind.Utc), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), "https://www.codiva.io/p/cf89e5a1-d528-4334-b973-9fcacfbc28d6", 3 }
                });

            migrationBuilder.InsertData(
                schema: "plagi_tracker",
                table: "Codes",
                columns: new[] { "Id", "Content", "CreatedAt", "FileName", "IsEnabled", "SubmissionId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("09b35d8c-a153-4a9a-a218-84a379fe868c"), "public class Persona {\n    private String nombre;\n    int edad;\n\n    public Persona(String name, int age) {\n        this.nombre = name;\n        this.edad = age;\n    }\n\n    public String getName() {\n        return nombre;\n    }\n\n    public int getAge() {\n        return edad;\n    }\n\n    public void setName(String name) {\n        this.nombre = name;\n    }\n\n    public void setAge(int age) {\n        this.edad = age;\n    }\n}", new DateTime(2024, 11, 18, 1, 28, 57, 782, DateTimeKind.Utc).AddTicks(5380), "Persona.java", true, new Guid("7397a9ce-94a9-4e5b-9cbb-215f061b197e"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("301e8585-ac92-4bd2-809b-262228bcc1c1"), "package com.example;\n\nclass HelloCodiva {\n\n    public static void main(String[] args) {\n\n        String greeting = \"Hello World\";\n        System.out.println(greeting);\n\n    }\n}\n", new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), "HelloCodiva.java", true, new Guid("e0d30fd2-1027-4af3-be3b-238a579dacb8"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("32914a3b-9b54-4e6b-ad27-033693f8e181"), "\npackage com.example;\n\nclass Main {\n    public static void main(String[] args) {\n        char myLetter = 'D';\n        boolean myBool = true;\n        String myText = \"Hello\";\n\n        int myNum = 5;\n        float myFloatNum = 5.99f;\n\n        System.out.println(myNum);\n        System.out.println(myFloatNum);\n        System.out.println(myLetter);\n        System.out.println(myBool);\n        System.out.println(myText);\n    }\n}", new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), "Main.java", true, new Guid("e0d30fd2-1027-4af3-be3b-238a579dacb8"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("4abb984e-aead-4b40-88b0-8c801fdde54c"), "\npackage com.example;\n\nclass HelloCodiva {\n    public static void main(String[] args) {\n        int a = 15;\n        int b = 20; // will generate an error\n        int c = 654;\n        System.out.println(a+b+c);\n    }\n}\n", new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), "HelloCodiva.java", true, new Guid("31edb16a-feb4-4cab-812c-e8a4bdb6ad45"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("59d052ff-7969-4ebb-911d-c9c6c5246a2e"), "\nimport java.util.Scanner;\n\npublic class nCylinder {\n\n    public static void main(String[] args) {\n        Scanner s = new Scanner(System.in);\n        System.out.print(\"Enter the radius and length of a cylinder: \");\n        float r = s.nextFloat();\n        float l = s.nextFloat();\n        System.out.println(\"The area is \" + r * r * 3.14159);\n        System.out.println(\"The volume is \" + (r * r * 3.14159) * l);\n    }\n}\n", new DateTime(2024, 11, 18, 18, 34, 9, 695, DateTimeKind.Utc).AddTicks(2070), "nCylinder.java", true, new Guid("9fd9c7a4-266a-4032-9ed2-4e03a02dfdf4"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("5c96bfec-28ba-4c23-b9da-fbf4cf835e0d"), "\npackage com.example;\n\npublic class Main {\n    public static void main(String[] args) {\n        int myNum = 5;\n        float myFloatNum = 5.99f;\n        char myLetter = 'D';\n        boolean myBool = true;\n        String myText = \"Hello\";\n        System.out.println(myNum);\n        System.out.println(myFloatNum);\n        System.out.println(myLetter);\n        System.out.println(myBool);\n        System.out.println(myText);\n    }\n}", new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc), "Main.java", true, new Guid("31edb16a-feb4-4cab-812c-e8a4bdb6ad45"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("7996e30e-e7c0-4c5a-baa7-dd50faa3a3eb"), "\nimport java.util.Scanner;\n\npublic class ncylinder {\n\n    public static void main(String[] args) {\n        Scanner sc = new Scanner(System.in);\n        System.out.print(\"Enter the radius and length of a cylinder : \");\n        double radius = sc.nextDouble();\n        double length = sc.nextDouble();\n        double area = (radius * radius) * 3.14159;\n        double volume = area * length;\n        System.out.println(\"The area is : \" + area);\n        System.out.println(\"The volume is : \" + volume);\n    }\n\n}\n", new DateTime(2024, 11, 18, 18, 36, 44, 138, DateTimeKind.Utc).AddTicks(510), "ncylinder.java", true, new Guid("22e13d14-0349-49df-9fc9-ff6c9bbb4bd8"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("83bafa2e-f925-4ab5-a1d7-be8d030eb0b9"), "public class Main\n{\n    public static void main(String[] args) {\n        System.out.println(\"Hello PlagiTracker\");\n    }\n}", new DateTime(2024, 11, 18, 14, 36, 13, 451, DateTimeKind.Utc).AddTicks(9740), "Main.java", true, new Guid("14cabe76-3398-4429-ad34-01679f08acb9"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("a3c6fd63-81e7-4bca-8a49-b163f292400b"), "public class Person\n{\n    private String fname;\n    private String lname;\n    private int age;\n\n\n    public String getFname()\n    {\n        return fname;\n    }\n\n\n    public String getLname()\n    {\n        return lname;\n    }\n\n\n    public int getAge()\n    {\n        return age;\n    }\n\n\n    ", new DateTime(2024, 11, 18, 14, 36, 13, 473, DateTimeKind.Utc).AddTicks(2670), "Person.java", true, new Guid("14cabe76-3398-4429-ad34-01679f08acb9"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("a7b61980-fb3c-46b6-8471-46c7c80b55fd"), "public class Person {\n    private String name;\n    private int age;\n\n    public Person(String name, int age) {\n        this.name = name;\n        this.age = age;\n    }\n\n    public String getName() {\n        return name;\n    }\n\n    public int getAge() {\n        return age;\n    }\n\n    public void setName(String name) {\n        this.name = name;\n    }\n", new DateTime(2024, 11, 18, 0, 27, 48, 358, DateTimeKind.Utc).AddTicks(4480), "Person.java", true, new Guid("7d0f9c15-9e1b-4301-8b6e-7812cca1d451"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("b0eeb1d1-9e34-4157-9744-b9ee629a61c2"), "public class Main\n{\n    public static void main(String[] args) {\n        System.out.println(\"Hello PlagiTracker\");\n    }\n}", new DateTime(2024, 11, 18, 0, 27, 48, 334, DateTimeKind.Utc).AddTicks(2680), "Main.java", true, new Guid("7d0f9c15-9e1b-4301-8b6e-7812cca1d451"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("bab848e0-1ce8-4d0f-83b4-8b95afda5047"), "public class Main\n{\n    public static void main(String[] args) {\n\n        // con esto imprimo\n        System.out.println(\"Hello My Friend!\");\n    }\n}", new DateTime(2024, 11, 18, 1, 28, 57, 764, DateTimeKind.Utc).AddTicks(3200), "Main.java", true, new Guid("7397a9ce-94a9-4e5b-9cbb-215f061b197e"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("c9281571-e24b-4c92-875b-b59e5ae88fdf"), "\nimport java.util.Scanner;\n\npublic class nCylinder {\n    public static void main(String[] args){\n\n        Scanner sc = new Scanner(System.in);\n\n        System.out.print(\"Enter the radius and length of a cylinder: \");\n        double radius = sc.nextDouble();\n        double length = sc.nextDouble();\n\n        double area = radius * radius * 3.14159;\n        double volume = area * length;\n\n        System.out.println(\"The area is \" + (float)area);\n        System.out.printf(\"The volume is %.1f\", volume);\n        System.out.println();\n\n    }\n}\n", new DateTime(2024, 11, 18, 18, 31, 7, 7, DateTimeKind.Utc).AddTicks(5070), "nCylinder.java", true, new Guid("d00b5731-977d-41cf-b8bf-7f693cb8d97b"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("c939bfb1-7324-4715-9f85-cd8c3cb99035"), "package E_1_first_exercise;\n\npublic class First_exercise {\n    public static void main(String args[]){\n\n        int number_1 = 8;\n        int number_2 = 15;\n\n        number_1 = number_1 + number_2;\n        number_2 = number_1 - number_2;\n        number_1 = number_1 - number_2;\n\n        System.out.println(\"First: \" + number_1);\n        System.out.println(\"Second: \" + number_2);\n\n        System.out.println(\"Doston Hamrakulov doston.hamrakulov@gmail.com\");\n    }\n}\n", new DateTime(2024, 11, 18, 18, 3, 59, 319, DateTimeKind.Utc).AddTicks(420), "First_exercise.java", true, new Guid("fe8eb5ea-7686-4539-b13b-51bf931d36bb"), new DateTime(1, 1, 1, 5, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_CourseId_Title",
                schema: "plagi_tracker",
                table: "Assignments",
                columns: new[] { "CourseId", "Title" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Classes_ExerciseId_Name",
                schema: "plagi_tracker",
                table: "Classes",
                columns: new[] { "ExerciseId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Classes_ParentClassId",
                schema: "plagi_tracker",
                table: "Classes",
                column: "ParentClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Codes_SubmissionId_FileName",
                schema: "plagi_tracker",
                table: "Codes",
                columns: new[] { "SubmissionId", "FileName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InvitationId",
                schema: "plagi_tracker",
                table: "Courses",
                column: "InvitationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Name",
                schema: "plagi_tracker",
                table: "Courses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherId",
                schema: "plagi_tracker",
                table: "Courses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseId",
                schema: "plagi_tracker",
                table: "Enrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_AssignmentId_Name",
                schema: "plagi_tracker",
                table: "Exercises",
                columns: new[] { "AssignmentId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Methods_ClassId_Type_Name_ParameterTypes",
                schema: "plagi_tracker",
                table: "Methods",
                columns: new[] { "ClassId", "Type", "Name", "ParameterTypes" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parameter_MethodId_Type_Name",
                schema: "plagi_tracker",
                table: "Parameter",
                columns: new[] { "MethodId", "Type", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plagiarisms_CodeId",
                schema: "plagi_tracker",
                table: "Plagiarisms",
                column: "CodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Plagiarisms_Id_CodeId_Algorithm",
                schema: "plagi_tracker",
                table: "Plagiarisms",
                columns: new[] { "Id", "CodeId", "Algorithm" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_AssignmentId",
                schema: "plagi_tracker",
                table: "Submissions",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_StudentId_AssignmentId_Url",
                schema: "plagi_tracker",
                table: "Submissions",
                columns: new[] { "StudentId", "AssignmentId", "Url" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                schema: "plagi_tracker",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments",
                schema: "plagi_tracker");

            migrationBuilder.DropTable(
                name: "Parameter",
                schema: "plagi_tracker");

            migrationBuilder.DropTable(
                name: "Plagiarisms",
                schema: "plagi_tracker");

            migrationBuilder.DropTable(
                name: "Methods",
                schema: "plagi_tracker");

            migrationBuilder.DropTable(
                name: "Codes",
                schema: "plagi_tracker");

            migrationBuilder.DropTable(
                name: "Classes",
                schema: "plagi_tracker");

            migrationBuilder.DropTable(
                name: "Submissions",
                schema: "plagi_tracker");

            migrationBuilder.DropTable(
                name: "Exercises",
                schema: "plagi_tracker");

            migrationBuilder.DropTable(
                name: "Students",
                schema: "plagi_tracker");

            migrationBuilder.DropTable(
                name: "Assignments",
                schema: "plagi_tracker");

            migrationBuilder.DropTable(
                name: "Courses",
                schema: "plagi_tracker");

            migrationBuilder.DropTable(
                name: "Teachers",
                schema: "plagi_tracker");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "plagi_tracker");
        }
    }
}
