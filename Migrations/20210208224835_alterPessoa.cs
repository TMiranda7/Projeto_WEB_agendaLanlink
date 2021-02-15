using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB_agendaLanlink.Migrations
{
    public partial class alterPessoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "cpf",
                table: "pessoas",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 11);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "cpf",
                table: "pessoas",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 11);
        }
    }
}
