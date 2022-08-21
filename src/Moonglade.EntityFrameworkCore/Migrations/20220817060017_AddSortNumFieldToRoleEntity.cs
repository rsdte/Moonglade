using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moonglade.EntityFrameworkCore.Migrations
{
    public partial class AddSortNumFieldToRoleEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SortNum",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SortNum",
                table: "Roles");
        }
    }
}
