using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuallyBoughtTogetherApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductEntryEntities",
                columns: table => new
                {
                    ProductEntryId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    CoPurchaseProductId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductEntryEntities", x => x.ProductEntryId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductEntryEntities");
        }
    }
}
