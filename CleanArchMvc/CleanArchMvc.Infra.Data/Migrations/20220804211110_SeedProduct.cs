using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchMvc.Infra.Data.Migrations
{
    public partial class SeedProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" +
                "VALUES('Samsung s22 Ultra', '16gb 512gb Preto', 6899.99, 50, 's22ultra.png', 2)");

            migrationBuilder.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" +
               "VALUES('Air Fryer', 'Polishop', 1099.99, 24, 'airFryer.png', 1)");

            migrationBuilder.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" +
               "VALUES('Acer Aspire', '256ssd 16gb Silver', 3899.99, 39, 'acerAspire.png', 3)");

            migrationBuilder.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" +
               "VALUES('Sony Vaio', '1tb hd 8gb White', 1849.99, 41, 'sonyVaio.png', 3)");

            migrationBuilder.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" +
               "VALUES('Refrigerator Brastemp', 'Dark Gray', 1099.99, 6, 'refrigerator.png', 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}