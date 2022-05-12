using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarAuctionMVC.Application.Migrations
{
    public partial class Addpropertyconfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarBodies_CarBodyId",
                schema: "dsz",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Categories_CategoryId",
                schema: "dsz",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_EngineTypes_EngineTypeId",
                schema: "dsz",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "YearOfProduction",
                schema: "dsz",
                table: "Cars");

            migrationBuilder.AlterColumn<string>(
                name: "EngineName",
                schema: "dsz",
                table: "EngineTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                schema: "dsz",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                schema: "dsz",
                table: "Cars",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mileage",
                schema: "dsz",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EngineTypeId",
                schema: "dsz",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CountryOfOrigin",
                schema: "dsz",
                table: "Cars",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                schema: "dsz",
                table: "Cars",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                schema: "dsz",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CarBodyId",
                schema: "dsz",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                schema: "dsz",
                table: "Cars",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuctionId",
                schema: "dsz",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfProduction",
                schema: "dsz",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "NameOfCarBody",
                schema: "dsz",
                table: "CarBodies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuctionTittle",
                schema: "dsz",
                table: "Auctions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AuctionDate",
                schema: "dsz",
                table: "Auctions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_AuctionId",
                schema: "dsz",
                table: "Cars",
                column: "AuctionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Auctions_AuctionId",
                schema: "dsz",
                table: "Cars",
                column: "AuctionId",
                principalSchema: "dsz",
                principalTable: "Auctions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarBodies_CarBodyId",
                schema: "dsz",
                table: "Cars",
                column: "CarBodyId",
                principalSchema: "dsz",
                principalTable: "CarBodies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Categories_CategoryId",
                schema: "dsz",
                table: "Cars",
                column: "CategoryId",
                principalSchema: "dsz",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_EngineTypes_EngineTypeId",
                schema: "dsz",
                table: "Cars",
                column: "EngineTypeId",
                principalSchema: "dsz",
                principalTable: "EngineTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Auctions_AuctionId",
                schema: "dsz",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarBodies_CarBodyId",
                schema: "dsz",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Categories_CategoryId",
                schema: "dsz",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_EngineTypes_EngineTypeId",
                schema: "dsz",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_AuctionId",
                schema: "dsz",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "AuctionId",
                schema: "dsz",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "DateOfProduction",
                schema: "dsz",
                table: "Cars");

            migrationBuilder.AlterColumn<string>(
                name: "EngineName",
                schema: "dsz",
                table: "EngineTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                schema: "dsz",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                schema: "dsz",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Mileage",
                schema: "dsz",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "EngineTypeId",
                schema: "dsz",
                table: "Cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CountryOfOrigin",
                schema: "dsz",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                schema: "dsz",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                schema: "dsz",
                table: "Cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CarBodyId",
                schema: "dsz",
                table: "Cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                schema: "dsz",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<string>(
                name: "YearOfProduction",
                schema: "dsz",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameOfCarBody",
                schema: "dsz",
                table: "CarBodies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AuctionTittle",
                schema: "dsz",
                table: "Auctions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AuctionDate",
                schema: "dsz",
                table: "Auctions",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarBodies_CarBodyId",
                schema: "dsz",
                table: "Cars",
                column: "CarBodyId",
                principalSchema: "dsz",
                principalTable: "CarBodies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Categories_CategoryId",
                schema: "dsz",
                table: "Cars",
                column: "CategoryId",
                principalSchema: "dsz",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_EngineTypes_EngineTypeId",
                schema: "dsz",
                table: "Cars",
                column: "EngineTypeId",
                principalSchema: "dsz",
                principalTable: "EngineTypes",
                principalColumn: "Id");
        }
    }
}
