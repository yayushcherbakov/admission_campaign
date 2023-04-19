using Microsoft.EntityFrameworkCore.Migrations;

namespace AdmissionCampaign.DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entrants",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntryYear = table.Column<int>(type: "int", nullable: false),
                    EducationProgram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationNumber = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SNILS = table.Column<long>(type: "bigint", nullable: false),
                    ApplicationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WithoutExamsReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialQuota = table.Column<bool>(type: "bit", nullable: false),
                    TargetQuota = table.Column<bool>(type: "bit", nullable: false),
                    InformaticsUSE = table.Column<int>(type: "int", nullable: false),
                    MathUSE = table.Column<int>(type: "int", nullable: false),
                    RussianLanguageUSE = table.Column<int>(type: "int", nullable: false),
                    IndividualAchievementScore = table.Column<int>(type: "int", nullable: false),
                    EducationForm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreemptiveRight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDormitoryNeeded = table.Column<bool>(type: "bit", nullable: false),
                    DocumentsReturned = table.Column<bool>(type: "bit", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EducationCompetitions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationRegion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrants", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entrants");
        }
    }
}
