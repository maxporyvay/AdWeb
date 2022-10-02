using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdWeb.Migrations.Migrations
{
    public partial class Seed_Ad_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql =
                $"INSERT INTO public.\"Ads\" (\"Id\", \"AdTitle\", \"AdDescription\", \"PublishTime\") VALUES('{Guid.NewGuid()}', 'Телевизор', 'Описание телевизора', '2022.10.10')";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
