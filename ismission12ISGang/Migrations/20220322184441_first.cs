using Microsoft.EntityFrameworkCore.Migrations;

namespace ismission12ISGang.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "persons",
                columns: table => new
                {
                    PersonID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "times",
                columns: table => new
                {
                    TimeID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Month = table.Column<string>(nullable: false),
                    Day = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    TimeOfDay = table.Column<string>(nullable: false),
                    PersonID = table.Column<int>(nullable: true),
                    bReserved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_times", x => x.TimeID);
                    table.ForeignKey(
                        name: "FK_times_persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "persons",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "persons",
                columns: new[] { "PersonID", "Email", "Name", "Phone", "Size" },
                values: new object[] { 1, "test@test.com", "Jacob Poor", "800 867 5309", 4 });

            migrationBuilder.CreateIndex(
                name: "IX_times_PersonID",
                table: "times",
                column: "PersonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "times");

            migrationBuilder.DropTable(
                name: "persons");
        }
    }
}
