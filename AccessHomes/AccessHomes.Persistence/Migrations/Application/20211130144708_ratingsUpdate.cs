using Microsoft.EntityFrameworkCore.Migrations;

namespace AccessHomes.Persistence.Migrations.Application
{
    public partial class ratingsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Inspection",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Inspection",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "510057bf-a91a-4398-83e7-58a558ae5edd",
                column: "ConcurrencyStamp",
                value: "5c1051ff-80fe-4b18-a6ee-6d17603f5a7e");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "76cdb59e-48da-4651-b300-a20e9c08a750",
                column: "ConcurrencyStamp",
                value: "414efcf5-f077-4ad5-8438-4de4322bd8f0");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "887bf7da-6dbb-4429-b646-dc9f2dda90cc",
                column: "ConcurrencyStamp",
                value: "96fa90ad-20ce-43cf-a564-e134655012b2");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "b1f48d22-a0ef-42af-9f37-638a5e59bf77",
                column: "ConcurrencyStamp",
                value: "8d0381f6-47ca-46a1-80a5-4a31683b4c9b");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "7cc5cd62-6240-44e5-b44f-bff0ae73342",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a103b3bf-1077-4064-8727-828f4408be43", "19a9e71d-e1c0-42b8-b8df-5eb961f48cbb" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "9a6a928b-0e11-4d5d-8a29-b8f04445e72",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fd650507-9d0f-49dc-a127-b3226210badd", "7df8667f-425c-4007-a303-b62fd1f3dc93" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Inspection");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Inspection");

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
    }
}
