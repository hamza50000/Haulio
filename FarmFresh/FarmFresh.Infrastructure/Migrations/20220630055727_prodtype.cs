using Microsoft.EntityFrameworkCore.Migrations;

namespace FarmFresh.Infrastructure.Migrations
{
    public partial class prodtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProductTypeId",
                table: "Products",
                type: "int",
                nullable: true);

            

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
