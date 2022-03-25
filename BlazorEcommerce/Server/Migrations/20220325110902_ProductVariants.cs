using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorEcommerce.Server.Migrations
{
    public partial class ProductVariants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariants",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    OriginalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariants", x => new { x.ProductId, x.ProductTypeId });
                    table.ForeignKey(
                        name: "FK_ProductVariants_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductVariants_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Default" },
                    { 2, "Paperback" },
                    { 3, "E-Book" },
                    { 4, "Audiobook" },
                    { 5, "Stream" },
                    { 6, "Blu-ray" },
                    { 7, "VHS" },
                    { 8, "PC" },
                    { 9, "PlayStation" },
                    { 10, "Xbox" }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "ProductId", "ProductTypeId", "OriginalPrice", "Price" },
                values: new object[,]
                {
                    { 1, 2, 199.0, 99.0 },
                    { 1, 3, 0.0, 79.0 },
                    { 1, 4, 299.0, 199.0 },
                    { 2, 2, 149.0, 79.0 },
                    { 3, 2, 0.0, 69.0 },
                    { 4, 5, 0.0, 39.0 },
                    { 4, 6, 0.0, 99.0 },
                    { 4, 7, 0.0, 199.0 },
                    { 5, 5, 0.0, 39.0 },
                    { 6, 5, 0.0, 29.0 },
                    { 7, 8, 299.0, 199.0 },
                    { 7, 9, 0.0, 699.0 },
                    { 7, 10, 599.0, 499.0 },
                    { 8, 8, 249.0, 99.0 },
                    { 9, 8, 0.0, 149.0 },
                    { 10, 1, 2999.0, 1599.0 },
                    { 11, 1, 3999.0, 799.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ProductTypeId",
                table: "ProductVariants",
                column: "ProductTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductVariants");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 99.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 199.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 259.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 49.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Price",
                value: 39.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Price",
                value: 29.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Price",
                value: 49.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Price",
                value: 20.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "Price",
                value: 149.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "Price",
                value: 1499.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "Price",
                value: 799.0);
        }
    }
}
