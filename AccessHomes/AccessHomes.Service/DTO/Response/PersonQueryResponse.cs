﻿using System;

namespace AccessHomes.Service.DTO.Response
{
    public class PersonQueryResponse
    {
        public long ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }
}
