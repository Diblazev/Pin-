using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmApp.Migrations
{
    public partial class Glumac : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Zanr",
                table: "film",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ime",
                table: "film",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GlumacId",
                table: "film",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Glumac",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Glumac", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_film_GlumacId",
                table: "film",
                column: "GlumacId");

            migrationBuilder.AddForeignKey(
                name: "FK_film_Glumac_GlumacId",
                table: "film",
                column: "GlumacId",
                principalTable: "Glumac",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_film_Glumac_GlumacId",
                table: "film");

            migrationBuilder.DropTable(
                name: "Glumac");

            migrationBuilder.DropIndex(
                name: "IX_film_GlumacId",
                table: "film");

            migrationBuilder.DropColumn(
                name: "GlumacId",
                table: "film");

            migrationBuilder.AlterColumn<string>(
                name: "Zanr",
                table: "film",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ime",
                table: "film",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40);
        }
    }
}
