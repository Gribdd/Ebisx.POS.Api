using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebisx.POS.Api.Migrations
{
    /// <inheritdoc />
    public partial class updatepublicidinuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Alter PublicId to be nullable if not already
            migrationBuilder.AlterColumn<string>(
                name: "PublicId",
                table: "Users",
                nullable: true, // Set as nullable
                oldClrType: typeof(string),
                oldNullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Revert the column back to non-nullable if needed
            migrationBuilder.AlterColumn<string>(
                name: "PublicId",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
