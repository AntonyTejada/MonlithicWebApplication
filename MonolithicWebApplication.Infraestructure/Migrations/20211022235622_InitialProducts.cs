using Microsoft.EntityFrameworkCore.Migrations;

namespace MonolithicWebApplication.Infraestructure.Migrations
{
    public partial class InitialProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "IdProduct", "CategoryId", "DescriptionProduct", "ImageUrlProduct", "MemoryProduct", "NameProduct", "PriceProduct", "ResolutionImageProduct", "StorageCapacityProduct" },
                values: new object[,]
                {
                    { 1, 2, "Xbox Series X", "https://as.com/meristation/imagenes/2020/11/05/reportajes/1604585433_047408_1604585657_noticia_normal.jpg", 10, "Xbox", 2550000.0, "FHD 4K", 1000 },
                    { 2, 2, "Playstation 5", "https://cdn.computerhoy.com/sites/navi.axelspringer.es/public/styles/1200/public/media/image/2020/06/playstation-5-1964465.jpg?itok=EXk3Upcm", 10, "Playstation", 2550000.0, "FHD 4K", 1000 },
                    { 3, 3, "HP 245 G7", "https://redecdecolombia.com/wp-content/uploads/2020/08/HP-245-G7-.jpg", 8, "HP", 1850000.0, "1200x720", 1000 },
                    { 4, 3, "Yoga c740", "https://www.pcworld.es/cmsdata/reviews/3783451/lenovo_yoga_c740_review_3_thumb1200_16-9.jpg", 10, "Lenovo", 3550000.0, "1500x900", 256 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "IdProduct",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "IdProduct",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "IdProduct",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "IdProduct",
                keyValue: 4);
        }
    }
}
