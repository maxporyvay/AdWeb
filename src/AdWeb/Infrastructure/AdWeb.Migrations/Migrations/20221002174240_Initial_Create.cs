using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdWeb.Migrations.Migrations
{
    public partial class Initial_Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AdTitle = table.Column<string>(type: "character varying(800)", maxLength: 800, nullable: false),
                    AdDescription = table.Column<string>(type: "text", nullable: false),
                    PublishTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdBoards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AdId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdBoards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdBoards_Ads_AdId",
                        column: x => x.AdId,
                        principalTable: "Ads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdBoards_AdId",
                table: "AdBoards",
                column: "AdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdBoards");

            migrationBuilder.DropTable(
                name: "Ads");
        }
    }
}
