using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class ProductModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Price = table.Column<double>(type: "decimal(18,2)", nullable: false),
                    PictureUrl = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Category = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Brand = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    QuantityInStock = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Category", "Description", "Name", "PictureUrl", "Price", "QuantityInStock" },
                values: new object[,]
                {
                    { 1, "Angular", "Boards", "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "Angular Speedster Board 2000", "/images/products/sb-ang1.png", 200.0, 82 },
                    { 2, "Angular", "Boards", "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.", "Green Angular Board 3000", "/images/products/sb-ang2.png", 150.0, 75 },
                    { 3, "NetCore", "Boards", "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", "Core Board Speed Rush 3", "/images/products/sb-core1.png", 180.0, 3 },
                    { 4, "NetCore", "Boards", "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.", "Net Core Super Board", "/images/products/sb-core2.png", 300.0, 52 },
                    { 5, "React", "Boards", "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "React Board Super Whizzy Fast", "/images/products/sb-react1.png", 250.0, 97 },
                    { 6, "Typescript", "Boards", "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.", "Typescript Entry Board", "/images/products/sb-ts1.png", 120.0, 37 },
                    { 7, "NetCore", "Hats", "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "Core Blue Hat", "/images/products/hat-core1.png", 10.0, 32 },
                    { 8, "React", "Hats", "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", "Green React Woolen Hat", "/images/products/hat-react1.png", 8.0, 6 },
                    { 9, "React", "Hats", "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "Purple React Woolen Hat", "/images/products/hat-react2.png", 15.0, 17 },
                    { 10, "VS Code", "Gloves", "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.", "Blue Code Gloves", "/images/products/glove-code1.png", 18.0, 74 },
                    { 11, "VS Code", "Gloves", "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.", "Green Code Gloves", "/images/products/glove-code2.png", 15.0, 19 },
                    { 12, "React", "Gloves", "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa.", "Purple React Gloves", "/images/products/glove-react1.png", 16.0, 77 },
                    { 13, "React", "Gloves", "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.", "Green React Gloves", "/images/products/glove-react2.png", 14.0, 45 },
                    { 14, "Redis", "Boots", "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", "Redis Red Boots", "/images/products/boot-redis1.png", 250.0, 49 },
                    { 15, "NetCore", "Boots", "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "Core Red Boots", "/images/products/boot-core2.png", 189.0, 28 },
                    { 16, "NetCore", "Boots", "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.", "Core Purple Boots", "/images/products/boot-core1.png", 199.0, 69 },
                    { 17, "Angular", "Boots", "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.", "Angular Purple Boots", "/images/products/boot-ang2.png", 150.0, 35 },
                    { 18, "Angular", "Boots", "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", "Angular Blue Boots", "/images/products/boot-ang1.png", 180.0, 27 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
