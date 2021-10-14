using Microsoft.EntityFrameworkCore.Migrations;

namespace MonolithicWebApplication.Infraestructure.Migrations
{
    public partial class CreateDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    IdCategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCategory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DescriptionCategory = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.IdCategory);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    IdProduct = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameProduct = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DescriptionProduct = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ImageUrlProduct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemoryProduct = table.Column<int>(type: "int", nullable: false),
                    StorageCapacityProduct = table.Column<int>(type: "int", nullable: false),
                    ResolutionImageProduct = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PriceProduct = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.IdProduct);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "IdCategory",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "IdCategory", "DescriptionCategory", "NameCategory" },
                values: new object[] { 1, "Smartphone", "Smartphone" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "IdCategory", "DescriptionCategory", "NameCategory" },
                values: new object[] { 2, "Consoles", "Consoles" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "IdCategory", "DescriptionCategory", "NameCategory" },
                values: new object[] { 3, "Laptops", "Laptops" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
