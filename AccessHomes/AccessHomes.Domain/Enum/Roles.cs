using System;

namespace AccessHomes.Domain.Enum
{
    public enum Roles
    {
        SuperAdmin,
        Admin,
        Moderator,
        Basic
    }

    public static class Constants
    {
        

        public static readonly string SuperAdmin = "510057bf-a91a-4398-83e7-58a558ae5edd";
        public static readonly string Admin = "76cdb59e-48da-4651-b300-a20e9c08a750";
        public static readonly string Moderator = "887bf7da-6dbb-4429-b646-dc9f2dda90cc";
        public static readonly string Basic = "b1f48d22-a0ef-42af-9f37-638a5e59bf77";


        public static readonly string SuperAdminUser = "7cc5cd62-6240-44e5-b44f-bff0ae73342";
        public static readonly string BasicUser = "9a6a928b-0e11-4d5d-8a29-b8f04445e72";
    }


}
