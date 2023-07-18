using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LevvaCoins.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "VARCHAR", maxLength: 200, nullable: false),
                    password = table.Column<string>(type: "VARCHAR", maxLength: 255, nullable: false),
                    avatar = table.Column<string>(type: "VARCHAR", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "VARCHAR", maxLength: 255, nullable: false),
                    amount = table.Column<decimal>(type: "decimal", precision: 8, scale: 2, nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    categoryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    userId = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.id);
                    table.ForeignKey(
                        name: "FK_transactions_categories_categoryId",
                        column: x => x.categoryId,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transactions_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_categories_description",
                table: "categories",
                column: "description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_transactions_categoryId",
                table: "transactions",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_userId",
                table: "transactions",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_users_email",
                table: "users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
