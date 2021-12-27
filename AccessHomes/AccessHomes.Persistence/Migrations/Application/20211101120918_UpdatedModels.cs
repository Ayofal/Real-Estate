using Microsoft.EntityFrameworkCore.Migrations;

namespace AccessHomes.Persistence.Migrations.Application
{
    public partial class UpdatedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Properties",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "510057bf-a91a-4398-83e7-58a558ae5edd",
                column: "ConcurrencyStamp",
                value: "7fc8ffef-8109-4be0-8e75-3f2c4b972762");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "76cdb59e-48da-4651-b300-a20e9c08a750",
                column: "ConcurrencyStamp",
                value: "d0251d3f-17b7-45f1-9722-0858fad9c58b");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "887bf7da-6dbb-4429-b646-dc9f2dda90cc",
                column: "ConcurrencyStamp",
                value: "204a1bc7-bae1-4f96-a656-e801dcbdf720");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "b1f48d22-a0ef-42af-9f37-638a5e59bf77",
                column: "ConcurrencyStamp",
                value: "fbeede19-dd11-44b4-87ab-50771ad7c7c8");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "7cc5cd62-6240-44e5-b44f-bff0ae73342",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "274898c5-f4a3-4c71-bb49-015d8ddb959e", "d6ba7be8-699d-46c3-a3fe-f4c19cf3dc87" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "9a6a928b-0e11-4d5d-8a29-b8f04445e72",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b3a9dccc-2d38-4d1c-a622-b19b37697bee", "f031918c-e189-4787-9ad7-c164d5e9b793" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Properties",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "510057bf-a91a-4398-83e7-58a558ae5edd",
                column: "ConcurrencyStamp",
                value: "ca6cc1d2-627e-4b7b-848b-88c4911512b1");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "76cdb59e-48da-4651-b300-a20e9c08a750",
                column: "ConcurrencyStamp",
                value: "c72a6efc-b0c1-4d84-abf0-8eb19104697d");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "887bf7da-6dbb-4429-b646-dc9f2dda90cc",
                column: "ConcurrencyStamp",
                value: "19bec4d9-c8c4-48fa-a7cf-e4fe269d0180");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "b1f48d22-a0ef-42af-9f37-638a5e59bf77",
                column: "ConcurrencyStamp",
                value: "812f13b4-a12c-4501-92b6-df6fb4bc75c1");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "7cc5cd62-6240-44e5-b44f-bff0ae73342",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e947b557-f833-4bcc-8287-95d4ad5c7640", "01e56b7b-bbf5-4aa2-9b81-a4ea7a4c6c41" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "9a6a928b-0e11-4d5d-8a29-b8f04445e72",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f7f9346b-28df-436c-9a21-28165a8d947a", "ef4d925d-a0ac-4b26-9c15-1db6c80165de" });
        }
    }
}
