using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MStore.Persistence.Migrations
{
    public partial class updatingCategoryColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Subscriptions_SubscriptionId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_SubscriptionId",
                table: "Categories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Categories_SubscriptionId",
                table: "Categories",
                column: "SubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Subscriptions_SubscriptionId",
                table: "Categories",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
