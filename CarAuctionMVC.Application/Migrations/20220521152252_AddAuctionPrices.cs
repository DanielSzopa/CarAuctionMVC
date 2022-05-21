using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarAuctionMVC.Application.Migrations
{
    public partial class AddAuctionPrices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                schema: "dsz",
                table: "Auctions",
                newName: "StartAuctionPrice");

            migrationBuilder.AddColumn<double>(
                name: "AuctionPrice",
                schema: "dsz",
                table: "Auctions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "BuyNowPrice",
                schema: "dsz",
                table: "Auctions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuctionPrice",
                schema: "dsz",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "BuyNowPrice",
                schema: "dsz",
                table: "Auctions");

            migrationBuilder.RenameColumn(
                name: "StartAuctionPrice",
                schema: "dsz",
                table: "Auctions",
                newName: "Price");
        }
    }
}
