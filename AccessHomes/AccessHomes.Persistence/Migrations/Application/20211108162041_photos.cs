using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccessHomes.Persistence.Migrations.Application
{
    public partial class photos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ParkingLot",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Duration",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Properties",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Bedrooms",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Bathrooms",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "Availability",
                table: "Properties",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Attachments",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Attachments");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ParkingLot",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Duration",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Properties",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Bedrooms",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Bathrooms",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Availability",
                table: "Properties",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "510057bf-a91a-4398-83e7-58a558ae5edd",
                column: "ConcurrencyStamp",
                value: "d16bf1cf-b33e-4d20-81d2-b2813461588a");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "76cdb59e-48da-4651-b300-a20e9c08a750",
                column: "ConcurrencyStamp",
                value: "a1d4a184-5b8a-42a9-9491-7ee8e63497b8");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "887bf7da-6dbb-4429-b646-dc9f2dda90cc",
                column: "ConcurrencyStamp",
                value: "074acd2a-f01c-4364-96f3-56765406b1ba");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "b1f48d22-a0ef-42af-9f37-638a5e59bf77",
                column: "ConcurrencyStamp",
                value: "6deb65d2-4960-42b7-870d-4203ed8d60ea");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "7cc5cd62-6240-44e5-b44f-bff0ae73342",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f8967a52-d941-4fa1-9ca9-244ec2d3f954", "f522b486-556f-4bb0-8fa9-1d16d2fa0ae5" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "9a6a928b-0e11-4d5d-8a29-b8f04445e72",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "29b13a95-124e-4c3f-ae2c-71904ec9ab0b", "7db866e7-d6eb-47f7-ab22-aa95ed25d860" });
        }
    }
}
