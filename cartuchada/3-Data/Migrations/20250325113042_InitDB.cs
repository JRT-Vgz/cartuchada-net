using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _3_Data.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "DATE", nullable: false),
                    Income = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Expenses = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Condition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Entry = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferencePrefix = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShopStat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopStat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SparePartType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SparePartType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warnings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Entry = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warnings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameCatalogue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProductType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JAP = table.Column<bool>(type: "bit", nullable: false),
                    NA = table.Column<bool>(type: "bit", nullable: false),
                    PAL = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCatalogue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameCatalogue_ProductType_IdProductType",
                        column: x => x.IdProductType,
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reference",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProductType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Assigned = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reference_ProductType_IdProductType",
                        column: x => x.IdProductType,
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SoldConsole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProductType = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SparePartsPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Benefit = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoldConsole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoldConsole_ProductType_IdProductType",
                        column: x => x.IdProductType,
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SoldSleeve",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSparePartType = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoldSleeve", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoldSleeve_SparePartType_IdSparePartType",
                        column: x => x.IdSparePartType,
                        principalTable: "SparePartType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SparePartsPurchase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSparePartType = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    Concept = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SparePartsPurchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SparePartsPurchase_SparePartType_IdSparePartType",
                        column: x => x.IdSparePartType,
                        principalTable: "SparePartType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SoldCartdrige",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProductType = table.Column<int>(type: "int", nullable: false),
                    IdGame = table.Column<int>(type: "int", nullable: false),
                    IdRegion = table.Column<int>(type: "int", nullable: false),
                    IdCondition = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Benefit = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoldCartdrige", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoldCartdrige_Condition_IdCondition",
                        column: x => x.IdCondition,
                        principalTable: "Condition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SoldCartdrige_GameCatalogue_IdGame",
                        column: x => x.IdGame,
                        principalTable: "GameCatalogue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SoldCartdrige_ProductType_IdProductType",
                        column: x => x.IdProductType,
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SoldCartdrige_Region_IdRegion",
                        column: x => x.IdRegion,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Spot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProductType = table.Column<int>(type: "int", nullable: false),
                    IdGame = table.Column<int>(type: "int", nullable: false),
                    IdRegion = table.Column<int>(type: "int", nullable: false),
                    IdCondition = table.Column<int>(type: "int", nullable: false),
                    SpotDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    SpotPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spot_Condition_IdCondition",
                        column: x => x.IdCondition,
                        principalTable: "Condition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Spot_GameCatalogue_IdGame",
                        column: x => x.IdGame,
                        principalTable: "GameCatalogue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Spot_ProductType_IdProductType",
                        column: x => x.IdProductType,
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Spot_Region_IdRegion",
                        column: x => x.IdRegion,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cartdrige",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdReference = table.Column<int>(type: "int", nullable: false),
                    IdProductType = table.Column<int>(type: "int", nullable: false),
                    IdGame = table.Column<int>(type: "int", nullable: false),
                    IdRegion = table.Column<int>(type: "int", nullable: false),
                    IdCondition = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartdrige", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cartdrige_Condition_IdCondition",
                        column: x => x.IdCondition,
                        principalTable: "Condition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cartdrige_GameCatalogue_IdGame",
                        column: x => x.IdGame,
                        principalTable: "GameCatalogue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cartdrige_ProductType_IdProductType",
                        column: x => x.IdProductType,
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cartdrige_Reference_IdReference",
                        column: x => x.IdReference,
                        principalTable: "Reference",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cartdrige_Region_IdRegion",
                        column: x => x.IdRegion,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Console",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdReference = table.Column<int>(type: "int", nullable: false),
                    IdProductType = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SparePartsPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Console", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Console_ProductType_IdProductType",
                        column: x => x.IdProductType,
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Console_Reference_IdReference",
                        column: x => x.IdReference,
                        principalTable: "Reference",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cartdrige_IdCondition",
                table: "Cartdrige",
                column: "IdCondition");

            migrationBuilder.CreateIndex(
                name: "IX_Cartdrige_IdGame",
                table: "Cartdrige",
                column: "IdGame");

            migrationBuilder.CreateIndex(
                name: "IX_Cartdrige_IdProductType",
                table: "Cartdrige",
                column: "IdProductType");

            migrationBuilder.CreateIndex(
                name: "IX_Cartdrige_IdReference",
                table: "Cartdrige",
                column: "IdReference");

            migrationBuilder.CreateIndex(
                name: "IX_Cartdrige_IdRegion",
                table: "Cartdrige",
                column: "IdRegion");

            migrationBuilder.CreateIndex(
                name: "IX_Console_IdProductType",
                table: "Console",
                column: "IdProductType");

            migrationBuilder.CreateIndex(
                name: "IX_Console_IdReference",
                table: "Console",
                column: "IdReference");

            migrationBuilder.CreateIndex(
                name: "IX_GameCatalogue_IdProductType",
                table: "GameCatalogue",
                column: "IdProductType");

            migrationBuilder.CreateIndex(
                name: "IX_Reference_IdProductType",
                table: "Reference",
                column: "IdProductType");

            migrationBuilder.CreateIndex(
                name: "IX_SoldCartdrige_IdCondition",
                table: "SoldCartdrige",
                column: "IdCondition");

            migrationBuilder.CreateIndex(
                name: "IX_SoldCartdrige_IdGame",
                table: "SoldCartdrige",
                column: "IdGame");

            migrationBuilder.CreateIndex(
                name: "IX_SoldCartdrige_IdProductType",
                table: "SoldCartdrige",
                column: "IdProductType");

            migrationBuilder.CreateIndex(
                name: "IX_SoldCartdrige_IdRegion",
                table: "SoldCartdrige",
                column: "IdRegion");

            migrationBuilder.CreateIndex(
                name: "IX_SoldConsole_IdProductType",
                table: "SoldConsole",
                column: "IdProductType");

            migrationBuilder.CreateIndex(
                name: "IX_SoldSleeve_IdSparePartType",
                table: "SoldSleeve",
                column: "IdSparePartType");

            migrationBuilder.CreateIndex(
                name: "IX_SparePartsPurchase_IdSparePartType",
                table: "SparePartsPurchase",
                column: "IdSparePartType");

            migrationBuilder.CreateIndex(
                name: "IX_Spot_IdCondition",
                table: "Spot",
                column: "IdCondition");

            migrationBuilder.CreateIndex(
                name: "IX_Spot_IdGame",
                table: "Spot",
                column: "IdGame");

            migrationBuilder.CreateIndex(
                name: "IX_Spot_IdProductType",
                table: "Spot",
                column: "IdProductType");

            migrationBuilder.CreateIndex(
                name: "IX_Spot_IdRegion",
                table: "Spot",
                column: "IdRegion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounting");

            migrationBuilder.DropTable(
                name: "Cartdrige");

            migrationBuilder.DropTable(
                name: "Console");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "ShopStat");

            migrationBuilder.DropTable(
                name: "SoldCartdrige");

            migrationBuilder.DropTable(
                name: "SoldConsole");

            migrationBuilder.DropTable(
                name: "SoldSleeve");

            migrationBuilder.DropTable(
                name: "SparePartsPurchase");

            migrationBuilder.DropTable(
                name: "Spot");

            migrationBuilder.DropTable(
                name: "Warnings");

            migrationBuilder.DropTable(
                name: "Reference");

            migrationBuilder.DropTable(
                name: "SparePartType");

            migrationBuilder.DropTable(
                name: "Condition");

            migrationBuilder.DropTable(
                name: "GameCatalogue");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "ProductType");
        }
    }
}
