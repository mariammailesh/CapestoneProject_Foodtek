using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapestoneProject.Migrations
{
    /// <inheritdoc />
    public partial class updated_db_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DeliveryLocations_Order_Id",
                table: "DeliveryLocations");

            migrationBuilder.AddColumn<int>(
                name: "Item_Id",
                table: "Ratings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SoldCount",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Discounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_Item_Id",
                table: "Ratings",
                column: "Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryLocations_Order_Id",
                table: "DeliveryLocations",
                column: "Order_Id",
                unique: true,
                filter: "[Order_Id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Items",
                table: "Ratings",
                column: "Item_Id",
                principalTable: "Items",
                principalColumn: "Item_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Items",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_Item_Id",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryLocations_Order_Id",
                table: "DeliveryLocations");

            migrationBuilder.DropColumn(
                name: "Item_Id",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "SoldCount",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Discounts");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryLocations_Order_Id",
                table: "DeliveryLocations",
                column: "Order_Id");
        }
    }
}
