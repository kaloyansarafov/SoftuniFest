using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftuniFest.Migrations
{
    public partial class fixedregDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Terminal_Merchants_MerchantId",
                schema: "App",
                table: "Terminal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Terminal",
                schema: "App",
                table: "Terminal");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                schema: "App",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Terminal",
                schema: "App",
                newName: "Terminals",
                newSchema: "App");

            migrationBuilder.RenameIndex(
                name: "IX_Terminal_MerchantId",
                schema: "App",
                table: "Terminals",
                newName: "IX_Terminals_MerchantId");

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                schema: "App",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                schema: "App",
                table: "Merchants",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Terminals",
                schema: "App",
                table: "Terminals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Terminals_Merchants_MerchantId",
                schema: "App",
                table: "Terminals",
                column: "MerchantId",
                principalSchema: "App",
                principalTable: "Merchants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Terminals_Merchants_MerchantId",
                schema: "App",
                table: "Terminals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Terminals",
                schema: "App",
                table: "Terminals");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                schema: "App",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                schema: "App",
                table: "Merchants");

            migrationBuilder.RenameTable(
                name: "Terminals",
                schema: "App",
                newName: "Terminal",
                newSchema: "App");

            migrationBuilder.RenameIndex(
                name: "IX_Terminals_MerchantId",
                schema: "App",
                table: "Terminal",
                newName: "IX_Terminal_MerchantId");

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                schema: "App",
                table: "Employees",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Terminal",
                schema: "App",
                table: "Terminal",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Terminal_Merchants_MerchantId",
                schema: "App",
                table: "Terminal",
                column: "MerchantId",
                principalSchema: "App",
                principalTable: "Merchants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
