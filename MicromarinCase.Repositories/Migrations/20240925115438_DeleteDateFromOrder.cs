using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicromarinCase.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class DeleteDateFromOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "BaseTables");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "BaseTables",
                type: "datetime2",
                nullable: true);
        }
    }
}
