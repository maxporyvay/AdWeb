using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdWeb.Migrations.Migrations
{
    public partial class Changed_AdTitle_Max_Length : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AdTitle",
                table: "Ads",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(800)",
                oldMaxLength: 800);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AdTitle",
                table: "Ads",
                type: "character varying(800)",
                maxLength: 800,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(2000)",
                oldMaxLength: 2000);
        }
    }
}
