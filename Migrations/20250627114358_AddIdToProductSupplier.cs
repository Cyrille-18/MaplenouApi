using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaplenouApi.Migrations
{
    /// <inheritdoc />
    public partial class AddIdToProductSupplier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSuppliers",
                table: "ProductSuppliers");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ProductSuppliers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSuppliers",
                table: "ProductSuppliers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSuppliers_ProductId_SupplierId",
                table: "ProductSuppliers",
                columns: new[] { "ProductId", "SupplierId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSuppliers",
                table: "ProductSuppliers");

            migrationBuilder.DropIndex(
                name: "IX_ProductSuppliers_ProductId_SupplierId",
                table: "ProductSuppliers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductSuppliers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSuppliers",
                table: "ProductSuppliers",
                columns: new[] { "ProductId", "SupplierId" });
        }
    }
}
