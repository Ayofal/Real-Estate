using Microsoft.EntityFrameworkCore.Migrations;

namespace AccessHomes.Persistence.Migrations.Application
{
    public partial class DisableProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "Properties",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "510057bf-a91a-4398-83e7-58a558ae5edd",
                column: "ConcurrencyStamp",
                value: "7f3581d7-7da1-4fb0-8c60-13891580b1f7");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "76cdb59e-48da-4651-b300-a20e9c08a750",
                column: "ConcurrencyStamp",
                value: "dc52478b-2f9a-43a4-a0af-edd9d7fc399c");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "887bf7da-6dbb-4429-b646-dc9f2dda90cc",
                column: "ConcurrencyStamp",
                value: "4120119c-265d-469d-add4-e937b32a3a5c");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "b1f48d22-a0ef-42af-9f37-638a5e59bf77",
                column: "ConcurrencyStamp",
                value: "49cb79a0-b89c-48b2-b5bf-996bf268b2f5");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "7cc5cd62-6240-44e5-b44f-bff0ae73342",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8a98af61-2d5c-4876-a24a-0e0f48b2729e", "8d2fe8e6-8005-4add-ae9b-47d3de8aa1c3" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "9a6a928b-0e11-4d5d-8a29-b8f04445e72",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "20f92d9e-ac93-4c0d-910c-13b1ffb4fa49", "490a12fb-df20-4580-95c5-c9cc9f6f121d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "Properties");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "510057bf-a91a-4398-83e7-58a558ae5edd",
                column: "ConcurrencyStamp",
                value: "6ff5e000-fccf-4951-917b-736dce8b664d");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "76cdb59e-48da-4651-b300-a20e9c08a750",
                column: "ConcurrencyStamp",
                value: "9495d371-6f15-4d55-a5c1-1cd326efc02f");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "887bf7da-6dbb-4429-b646-dc9f2dda90cc",
                column: "ConcurrencyStamp",
                value: "5aa7844d-d157-4e87-8302-1ac473ba7939");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "b1f48d22-a0ef-42af-9f37-638a5e59bf77",
                column: "ConcurrencyStamp",
                value: "9bf44f21-5f7d-477a-aa02-a2bbe412eec3");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "7cc5cd62-6240-44e5-b44f-bff0ae73342",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0a0d79d8-b6d9-4ec0-8e4a-0afab2759402", "27db6398-b6ae-42df-b69e-09f140b6a849" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "9a6a928b-0e11-4d5d-8a29-b8f04445e72",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6e92f841-5e8a-4f84-964f-321ff6ae8c68", "4778a1dc-12f5-425b-b985-ef033657def5" });
        }
    }
}
