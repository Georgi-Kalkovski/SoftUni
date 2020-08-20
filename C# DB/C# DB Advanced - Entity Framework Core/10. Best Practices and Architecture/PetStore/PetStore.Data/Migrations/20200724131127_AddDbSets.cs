using Microsoft.EntityFrameworkCore.Migrations;

namespace PetStore.Data.Migrations
{
    public partial class AddDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientProduct_Client_ClientId",
                table: "ClientProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientProduct_Order_OrderId",
                table: "ClientProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientProduct_Product_ProductId",
                table: "ClientProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Pet_Breed_BreedId",
                table: "Pet");

            migrationBuilder.DropForeignKey(
                name: "FK_Pet_Client_ClientId",
                table: "Pet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pet",
                table: "Pet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientProduct",
                table: "ClientProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Client",
                table: "Client");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Breed",
                table: "Breed");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Pet",
                newName: "Pets");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "ClientProduct",
                newName: "ClientProducts");

            migrationBuilder.RenameTable(
                name: "Client",
                newName: "Clients");

            migrationBuilder.RenameTable(
                name: "Breed",
                newName: "Breeds");

            migrationBuilder.RenameIndex(
                name: "IX_Pet_ClientId",
                table: "Pets",
                newName: "IX_Pets_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Pet_BreedId",
                table: "Pets",
                newName: "IX_Pets_BreedId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientProduct_ProductId",
                table: "ClientProducts",
                newName: "IX_ClientProducts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientProduct_OrderId",
                table: "ClientProducts",
                newName: "IX_ClientProducts_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pets",
                table: "Pets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientProducts",
                table: "ClientProducts",
                columns: new[] { "ClientId", "ProductId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Breeds",
                table: "Breeds",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientProducts_Clients_ClientId",
                table: "ClientProducts",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientProducts_Orders_OrderId",
                table: "ClientProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientProducts_Products_ProductId",
                table: "ClientProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Breeds_BreedId",
                table: "Pets",
                column: "BreedId",
                principalTable: "Breeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Clients_ClientId",
                table: "Pets",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientProducts_Clients_ClientId",
                table: "ClientProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientProducts_Orders_OrderId",
                table: "ClientProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientProducts_Products_ProductId",
                table: "ClientProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Breeds_BreedId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Clients_ClientId",
                table: "Pets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pets",
                table: "Pets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientProducts",
                table: "ClientProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Breeds",
                table: "Breeds");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "Pets",
                newName: "Pet");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Client");

            migrationBuilder.RenameTable(
                name: "ClientProducts",
                newName: "ClientProduct");

            migrationBuilder.RenameTable(
                name: "Breeds",
                newName: "Breed");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_ClientId",
                table: "Pet",
                newName: "IX_Pet_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_BreedId",
                table: "Pet",
                newName: "IX_Pet_BreedId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientProducts_ProductId",
                table: "ClientProduct",
                newName: "IX_ClientProduct_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientProducts_OrderId",
                table: "ClientProduct",
                newName: "IX_ClientProduct_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pet",
                table: "Pet",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Client",
                table: "Client",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientProduct",
                table: "ClientProduct",
                columns: new[] { "ClientId", "ProductId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Breed",
                table: "Breed",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientProduct_Client_ClientId",
                table: "ClientProduct",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientProduct_Order_OrderId",
                table: "ClientProduct",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientProduct_Product_ProductId",
                table: "ClientProduct",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_Breed_BreedId",
                table: "Pet",
                column: "BreedId",
                principalTable: "Breed",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_Client_ClientId",
                table: "Pet",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
