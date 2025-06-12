using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _3_Data.Migrations
{
    /// <inheritdoc />
    public partial class TotalAccounting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Accounting",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Accounting");
        }
    }
}
