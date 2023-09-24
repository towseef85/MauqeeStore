using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MStore.Persistence.Migrations
{
    public partial class updatingProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductAttributeCombinationId",
                table: "Products");

            migrationBuilder.AddColumn<Guid>(
                name: "AttributeValueId",
                table: "ProductAttributeCombinations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttributeValueId",
                table: "ProductAttributeCombinations");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductAttributeCombinationId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
