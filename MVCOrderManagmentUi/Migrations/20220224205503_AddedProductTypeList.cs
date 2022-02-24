using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCOrderManagmentUi.Migrations
{
    public partial class AddedProductTypeList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ShoppingCartContentID",
                table: "ShoppingCart_Contents",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ShoppingC__shopp__2982930DB",
                table: "ShoppingCart_Contents",
                column: "ShoppingCartContentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__ShoppingC__shopp__2982930DB",
                table: "ShoppingCart_Contents");

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingCartContentID",
                table: "ShoppingCart_Contents",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
