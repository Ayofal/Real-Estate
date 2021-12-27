using Microsoft.EntityFrameworkCore.Migrations;

namespace AccessHomes.Persistence.Migrations.Application
{
    public partial class EnumToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5f7c029d-1472-430d-a30f-78503c5647d2", "0ee02b20-f895-44a4-a003-9c63bcbad427" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "48e303f6-66ad-466e-8985-8f6a142742af", "f8ae4abf-a3e7-4c34-ad26-e36e57f4acf5" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5f7c029d-1472-430d-a30f-78503c5647d2", "f8ae4abf-a3e7-4c34-ad26-e36e57f4acf5" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ba3f97ef-1ac4-4eec-947e-1f62a8fac310", "f8ae4abf-a3e7-4c34-ad26-e36e57f4acf5" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "be99482b-516a-4ff7-8f99-dfac487de580", "f8ae4abf-a3e7-4c34-ad26-e36e57f4acf5" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "48e303f6-66ad-466e-8985-8f6a142742af");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "5f7c029d-1472-430d-a30f-78503c5647d2");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "ba3f97ef-1ac4-4eec-947e-1f62a8fac310");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "be99482b-516a-4ff7-8f99-dfac487de580");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "0ee02b20-f895-44a4-a003-9c63bcbad427");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "f8ae4abf-a3e7-4c34-ad26-e36e57f4acf5");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Amenity",
                table: "Amenities",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5b6b2dc1-780a-4841-9bd0-15ed05e8934c", "e6db8a09-1f8b-4014-bc73-94654ace8aa2", "SuperAdmin", "SuperAdmin" },
                    { "ad07c9fa-9ed0-4aad-938a-9b4e705c5773", "99f282fa-f3e8-4465-9b76-25edcebc3921", "Admin", "Admin" },
                    { "283a50f4-576e-4804-92a7-dcf79b0cb47c", "252ccdcf-62aa-46db-b6f0-e1bd3dcc452d", "Moderator", "Moderator" },
                    { "fdeac8a2-4ad6-4286-be61-0373a7382f02", "1e53f444-36fe-47d0-9d2e-d74d6248b567", "Basic", "Basic" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType" },
                values: new object[,]
                {
                    { "b3aad0f7-8818-4bc3-af68-d24ad5ea2011", 0, "7174fcd2-40e6-4a2b-abd7-98c0181748ff", "superadmin@gmail.com", true, "John", "Doe", false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, "bc80aad9-8b9c-48e4-807a-3f501a844cf5", false, "superadmin", 0 },
                    { "8b27b9a5-a5b7-4979-a7eb-8b4d386a31b3", 0, "462d8c0b-9338-4717-84f9-ca93a59abc49", "basicuser@gmail.com", true, "Basic", "User", false, null, "BASICUSER@GMAIL.COM", "BASICUSER", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, "de1a4d96-27ce-48ff-8c32-4a14d430e6ee", false, "basicuser", 0 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "5b6b2dc1-780a-4841-9bd0-15ed05e8934c", "b3aad0f7-8818-4bc3-af68-d24ad5ea2011" },
                    { "ad07c9fa-9ed0-4aad-938a-9b4e705c5773", "b3aad0f7-8818-4bc3-af68-d24ad5ea2011" },
                    { "283a50f4-576e-4804-92a7-dcf79b0cb47c", "b3aad0f7-8818-4bc3-af68-d24ad5ea2011" },
                    { "fdeac8a2-4ad6-4286-be61-0373a7382f02", "8b27b9a5-a5b7-4979-a7eb-8b4d386a31b3" },
                    { "fdeac8a2-4ad6-4286-be61-0373a7382f02", "b3aad0f7-8818-4bc3-af68-d24ad5ea2011" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fdeac8a2-4ad6-4286-be61-0373a7382f02", "8b27b9a5-a5b7-4979-a7eb-8b4d386a31b3" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "283a50f4-576e-4804-92a7-dcf79b0cb47c", "b3aad0f7-8818-4bc3-af68-d24ad5ea2011" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5b6b2dc1-780a-4841-9bd0-15ed05e8934c", "b3aad0f7-8818-4bc3-af68-d24ad5ea2011" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad07c9fa-9ed0-4aad-938a-9b4e705c5773", "b3aad0f7-8818-4bc3-af68-d24ad5ea2011" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fdeac8a2-4ad6-4286-be61-0373a7382f02", "b3aad0f7-8818-4bc3-af68-d24ad5ea2011" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "283a50f4-576e-4804-92a7-dcf79b0cb47c");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "5b6b2dc1-780a-4841-9bd0-15ed05e8934c");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "ad07c9fa-9ed0-4aad-938a-9b4e705c5773");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "fdeac8a2-4ad6-4286-be61-0373a7382f02");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "8b27b9a5-a5b7-4979-a7eb-8b4d386a31b3");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "b3aad0f7-8818-4bc3-af68-d24ad5ea2011");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Properties",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Properties",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Amenity",
                table: "Amenities",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "be99482b-516a-4ff7-8f99-dfac487de580", "7643bd54-1fd0-47ca-9fbc-fd56d744f2bf", "SuperAdmin", "SuperAdmin" },
                    { "ba3f97ef-1ac4-4eec-947e-1f62a8fac310", "82d607d5-b97e-427d-879a-a270e70a996d", "Admin", "Admin" },
                    { "48e303f6-66ad-466e-8985-8f6a142742af", "b822ae65-9c5d-49ac-b5da-52bef6e1213c", "Moderator", "Moderator" },
                    { "5f7c029d-1472-430d-a30f-78503c5647d2", "f4bf8cc2-af6a-4354-b843-807f0d23d050", "Basic", "Basic" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType" },
                values: new object[,]
                {
                    { "f8ae4abf-a3e7-4c34-ad26-e36e57f4acf5", 0, "d924584b-a70a-4de0-81f9-e98b2aa71e09", "superadmin@gmail.com", true, "John", "Doe", false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, "6644b8bc-517c-4c65-9e3b-f97af49f27dd", false, "superadmin", 0 },
                    { "0ee02b20-f895-44a4-a003-9c63bcbad427", 0, "a78aaed3-3d9a-4dd9-81af-cfba78d3bcb7", "basicuser@gmail.com", true, "Basic", "User", false, null, "BASICUSER@GMAIL.COM", "BASICUSER", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, "3287a0e8-94a5-4ddd-9f74-c89fd8218a3b", false, "basicuser", 0 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "be99482b-516a-4ff7-8f99-dfac487de580", "f8ae4abf-a3e7-4c34-ad26-e36e57f4acf5" },
                    { "ba3f97ef-1ac4-4eec-947e-1f62a8fac310", "f8ae4abf-a3e7-4c34-ad26-e36e57f4acf5" },
                    { "48e303f6-66ad-466e-8985-8f6a142742af", "f8ae4abf-a3e7-4c34-ad26-e36e57f4acf5" },
                    { "5f7c029d-1472-430d-a30f-78503c5647d2", "0ee02b20-f895-44a4-a003-9c63bcbad427" },
                    { "5f7c029d-1472-430d-a30f-78503c5647d2", "f8ae4abf-a3e7-4c34-ad26-e36e57f4acf5" }
                });
        }
    }
}
