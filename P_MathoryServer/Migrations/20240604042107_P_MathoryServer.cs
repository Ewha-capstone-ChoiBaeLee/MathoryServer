using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P_MathoryServer.Migrations
{
    public partial class P_MathoryServer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharacterInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    CharacterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CharacterPersonality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ranking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ranking_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Min_Score = table.Column<int>(type: "int", nullable: false),
                    Max_Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranking", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Story",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Part = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Story", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StoryLine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num = table.Column<int>(type: "int", nullable: false),
                    Part = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Story = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryLine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.SubjectId);
                });

            migrationBuilder.CreateTable(
                name: "UserInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserPW = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserYear = table.Column<int>(type: "int", nullable: false),
                    UserLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInformation", x => x.Id);
                    table.UniqueConstraint("AK_UserInformation_UserId", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Quiz",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Part = table.Column<int>(type: "int", nullable: false),
                    Problem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Equation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quiz", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quiz_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    Equation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => new { x.UserId, x.Year, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_Log_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Log_UserInformation_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInformation",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MyPage",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    Solved_Questions = table.Column<int>(type: "int", nullable: false),
                    Correct_Questions = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyPage", x => new { x.UserId, x.Year, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_MyPage_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MyPage_UserInformation_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInformation",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StarCount",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LevelOne = table.Column<int>(type: "int", nullable: false),
                    LevelTwo = table.Column<int>(type: "int", nullable: false),
                    LevelThree = table.Column<int>(type: "int", nullable: false),
                    LevelFour = table.Column<int>(type: "int", nullable: false),
                    LevelFive = table.Column<int>(type: "int", nullable: false),
                    LevelSix = table.Column<int>(type: "int", nullable: false),
                    LevelSeven = table.Column<int>(type: "int", nullable: false),
                    LevelEight = table.Column<int>(type: "int", nullable: false),
                    LevelNine = table.Column<int>(type: "int", nullable: false),
                    LevelTen = table.Column<int>(type: "int", nullable: false),
                    LevelEleven = table.Column<int>(type: "int", nullable: false),
                    LevelTwelve = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarCount", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_StarCount_UserInformation_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInformation",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Log_SubjectId",
                table: "Log",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_MyPage_SubjectId",
                table: "MyPage",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_SubjectId",
                table: "Quiz",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterInformation");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "MyPage");

            migrationBuilder.DropTable(
                name: "Quiz");

            migrationBuilder.DropTable(
                name: "Ranking");

            migrationBuilder.DropTable(
                name: "StarCount");

            migrationBuilder.DropTable(
                name: "Story");

            migrationBuilder.DropTable(
                name: "StoryLine");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "UserInformation");
        }
    }
}
