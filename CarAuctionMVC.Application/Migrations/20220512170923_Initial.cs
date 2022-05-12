using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarAuctionMVC.Application.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dsz");

            migrationBuilder.CreateTable(
                name: "Auctions",
                schema: "dsz",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuctionTittle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuctionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarBodies",
                schema: "dsz",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfCarBody = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBodies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "dsz",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EngineTypes",
                schema: "dsz",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EngineName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                schema: "dsz",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearOfProduction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mileage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarBodyId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    EngineTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_CarBodies_CarBodyId",
                        column: x => x.CarBodyId,
                        principalSchema: "dsz",
                        principalTable: "CarBodies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cars_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "dsz",
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cars_EngineTypes_EngineTypeId",
                        column: x => x.EngineTypeId,
                        principalSchema: "dsz",
                        principalTable: "EngineTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarBodyId",
                schema: "dsz",
                table: "Cars",
                column: "CarBodyId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CategoryId",
                schema: "dsz",
                table: "Cars",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_EngineTypeId",
                schema: "dsz",
                table: "Cars",
                column: "EngineTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auctions",
                schema: "dsz");

            migrationBuilder.DropTable(
                name: "Cars",
                schema: "dsz");

            migrationBuilder.DropTable(
                name: "CarBodies",
                schema: "dsz");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "dsz");

            migrationBuilder.DropTable(
                name: "EngineTypes",
                schema: "dsz");
        }
    }
}
