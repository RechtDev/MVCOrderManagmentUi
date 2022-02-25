using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCOrderManagmentUi.Migrations
{
    public partial class PKKeyNEw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                columns: table => new
                {
                    prod_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prod_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    prod_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    prod_type = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PRODUCTS__56958AB29A69EB3E", x => x.prod_id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    cart_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cart_name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Shopping__2EF52A27390804F9", x => x.cart_id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCart_Contents",
                columns: table => new
                {
                    ShoppingCartContentID = table.Column<int>(type: "int", nullable: false),
                    prod_id = table.Column<int>(type: "int", nullable: true),
                    shoppingCart_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ShoppingC__shopp__2982930DB", x => x.ShoppingCartContentID);
                    table.ForeignKey(
                        name: "FK__ShoppingC__prod___276EDEB3",
                        column: x => x.prod_id,
                        principalTable: "PRODUCTS",
                        principalColumn: "prod_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ShoppingC__shopp__286302EC",
                        column: x => x.shoppingCart_id,
                        principalTable: "ShoppingCart",
                        principalColumn: "cart_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_Contents_prod_id",
                table: "ShoppingCart_Contents",
                column: "prod_id");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_Contents_shoppingCart_id",
                table: "ShoppingCart_Contents",
                column: "shoppingCart_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCart_Contents");

            migrationBuilder.DropTable(
                name: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "ShoppingCart");
        }
    }
}
