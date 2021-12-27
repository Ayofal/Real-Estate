using System.ComponentModel.DataAnnotations;

namespace AccessHomes.Domain
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
