using Microsoft.EntityFrameworkCore.Migrations;

namespace velotech.Migrations
{
    public partial class Emissor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Emissor",
                table: "Cadastros",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Emissor",
                table: "Cadastros");
        }
    }
}
