using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moonglade.EntityFrameworkCore.Migrations
{
    public partial class AddParentIdFieldToResourceEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Resources",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Resources");
        }
    }
}
