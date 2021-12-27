using Microsoft.EntityFrameworkCore.Migrations;

namespace AccessHomes.Persistence.Migrations.Application
{
    public partial class updateSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0e052301-66f6-44b3-9a0f-959456b520a2", "0dd950fd-7fe5-4008-ac3d-06aaf654b917" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0e052301-66f6-44b3-9a0f-959456b520a2", "28b975e2-e490-4d07-ac55-3ca2dff66af7" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "839fc8ea-a417-4d7d-8a91-cf5af4753f1b", "28b975e2-e490-4d07-ac55-3ca2dff66af7" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cd399030-1322-4939-9636-1b39a6ce9a75", "28b975e2-e490-4d07-ac55-3ca2dff66af7" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e781de18-bf00-4279-be70-cd53287a0224", "28b975e2-e490-4d07-ac55-3ca2dff66af7" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "0e052301-66f6-44b3-9a0f-959456b520a2");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "839fc8ea-a417-4d7d-8a91-cf5af4753f1b");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "cd399030-1322-4939-9636-1b39a6ce9a75");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "e781de18-bf00-4279-be70-cd53287a0224");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "0dd950fd-7fe5-4008-ac3d-06aaf654b917");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "28b975e2-e490-4d07-ac55-3ca2dff66af7");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "94c19365-e078-4eee-b36d-1410a109bcf7", "c30811f1-c5fc-4248-9ca4-23b7054fbdac", "SuperAdmin", "SuperAdmin" },
                    { "b0129122-7caf-4f30-9a61-77bcfafdeebc", "172ca203-ef2b-4a74-9458-4747c21f329a", "Admin", "Admin" },
                    { "fc79b43a-799d-46de-a8d2-a1a5697f4c5a", "dc39e699-cb8e-404c-a97b-cbe396de493d", "Moderator", "Moderator" },
                    { "414aaf6d-7241-424a-91f8-668f00aee5d7", "fc8f9a4f-5374-4431-9f19-f43c960a9cff", "Basic", "Basic" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType" },
                values: new object[,]
                {
                    { "9d9b57aa-8996-476f-9a14-73cfad6a070b", 0, "8e2fcbeb-28ff-48bc-96d7-bb8811bb3403", "superadmin@gmail.com", true, "John", "Doe", false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, "4de3716e-49a5-40ee-8776-61f3ae34eea6", false, "superadmin", 0 },
                    { "4c7a8208-2a32-4ec7-89ef-c56240eb7fd8", 0, "e264e56f-34f3-4e0f-903b-e3007962d3be", "basicuser@gmail.com", true, "Basic", "User", false, null, "BASICUSER@GMAIL.COM", "BASICUSER", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, "34471348-2c26-4d22-b363-537b94dd2d77", false, "basicuser", 0 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "94c19365-e078-4eee-b36d-1410a109bcf7", "9d9b57aa-8996-476f-9a14-73cfad6a070b" },
                    { "b0129122-7caf-4f30-9a61-77bcfafdeebc", "9d9b57aa-8996-476f-9a14-73cfad6a070b" },
                    { "fc79b43a-799d-46de-a8d2-a1a5697f4c5a", "9d9b57aa-8996-476f-9a14-73cfad6a070b" },
                    { "414aaf6d-7241-424a-91f8-668f00aee5d7", "4c7a8208-2a32-4ec7-89ef-c56240eb7fd8" },
                    { "414aaf6d-7241-424a-91f8-668f00aee5d7", "9d9b57aa-8996-476f-9a14-73cfad6a070b" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "414aaf6d-7241-424a-91f8-668f00aee5d7", "4c7a8208-2a32-4ec7-89ef-c56240eb7fd8" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "414aaf6d-7241-424a-91f8-668f00aee5d7", "9d9b57aa-8996-476f-9a14-73cfad6a070b" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "94c19365-e078-4eee-b36d-1410a109bcf7", "9d9b57aa-8996-476f-9a14-73cfad6a070b" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b0129122-7caf-4f30-9a61-77bcfafdeebc", "9d9b57aa-8996-476f-9a14-73cfad6a070b" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fc79b43a-799d-46de-a8d2-a1a5697f4c5a", "9d9b57aa-8996-476f-9a14-73cfad6a070b" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "414aaf6d-7241-424a-91f8-668f00aee5d7");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "94c19365-e078-4eee-b36d-1410a109bcf7");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "b0129122-7caf-4f30-9a61-77bcfafdeebc");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "fc79b43a-799d-46de-a8d2-a1a5697f4c5a");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "4c7a8208-2a32-4ec7-89ef-c56240eb7fd8");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "9d9b57aa-8996-476f-9a14-73cfad6a070b");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "839fc8ea-a417-4d7d-8a91-cf5af4753f1b", "ca1ba2dc-0aa4-4c43-a3ee-c7636707b809", "SuperAdmin", "SuperAdmin" },
                    { "e781de18-bf00-4279-be70-cd53287a0224", "31503b93-1ba4-4516-be9a-3a0610948cca", "Admin", "Admin" },
                    { "cd399030-1322-4939-9636-1b39a6ce9a75", "4aa769d7-e3dd-4f6e-ac0d-b76409869d85", "Moderator", "Moderator" },
                    { "0e052301-66f6-44b3-9a0f-959456b520a2", "3f2301ef-9b38-4f74-bf70-05e71db8cf05", "Basic", "Basic" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType" },
                values: new object[,]
                {
                    { "28b975e2-e490-4d07-ac55-3ca2dff66af7", 0, "57a7c861-2b94-4483-9770-5ccdfb9cbdc1", "superadmin@gmail.com", true, "John", "Doe", false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, "81d55c93-41c3-4839-b171-9f93b114ce62", false, "superadmin", 0 },
                    { "0dd950fd-7fe5-4008-ac3d-06aaf654b917", 0, "1089e81e-cede-4482-8f11-5cda178c26bd", "basicuser@gmail.com", true, "Basic", "User", false, null, "BASICUSER@GMAIL.COM", "BASICUSER", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, "8a03b503-48b7-4735-babc-223ab2df9542", false, "basicuser", 0 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "839fc8ea-a417-4d7d-8a91-cf5af4753f1b", "28b975e2-e490-4d07-ac55-3ca2dff66af7" },
                    { "e781de18-bf00-4279-be70-cd53287a0224", "28b975e2-e490-4d07-ac55-3ca2dff66af7" },
                    { "cd399030-1322-4939-9636-1b39a6ce9a75", "28b975e2-e490-4d07-ac55-3ca2dff66af7" },
                    { "0e052301-66f6-44b3-9a0f-959456b520a2", "0dd950fd-7fe5-4008-ac3d-06aaf654b917" },
                    { "0e052301-66f6-44b3-9a0f-959456b520a2", "28b975e2-e490-4d07-ac55-3ca2dff66af7" }
                });
        }
    }
}
