using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MStore.Persistence.Migrations
{
    public partial class updatingProductAttributeIdInproducttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductAttributeCombinationsId",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProductAttributeCombinationsId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
