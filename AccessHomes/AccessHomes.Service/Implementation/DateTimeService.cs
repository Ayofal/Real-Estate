using AccessHomes.Service.Contract;
using System;

namespace AccessHomes.Service.Implementation
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}