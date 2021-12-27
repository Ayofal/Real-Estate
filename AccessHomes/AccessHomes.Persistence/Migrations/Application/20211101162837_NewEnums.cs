using Microsoft.EntityFrameworkCore.Migrations;

namespace AccessHomes.Persistence.Migrations.Application
{
    public partial class NewEnums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyRatings");

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
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Bathrooms",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ParkingLot",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "ParkingLot",
                table: "Properties");

            migrationBuilder.AlterColumn<string>(
                name: "State",
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

            migrationBuilder.AlterColumn<int>(
                name: "Bedrooms",
                table: "Properties",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Bathrooms",
                table: "Properties",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "PropertyRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AverageRating = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    PropertiesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyRatings_Properties_PropertiesId",
                        column: x => x.PropertiesId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_PropertyRatings_PropertiesId",
                table: "PropertyRatings",
                column: "PropertiesId");
        }
    }
}
