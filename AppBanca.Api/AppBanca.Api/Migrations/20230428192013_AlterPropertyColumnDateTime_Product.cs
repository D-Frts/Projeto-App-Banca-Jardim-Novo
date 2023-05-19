using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppBanca.Api.Migrations
{
    /// <inheritdoc />
    public partial class AlterPropertyColumnDateTime_Product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Products",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 28, 19, 20, 12, 346, DateTimeKind.Utc).AddTicks(1896),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 28, 19, 20, 12, 345, DateTimeKind.Utc).AddTicks(9247),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 4, 28, 19, 20, 12, 346, DateTimeKind.Utc).AddTicks(1896));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2023, 4, 28, 19, 20, 12, 345, DateTimeKind.Utc).AddTicks(9247));
        }
    }
}
