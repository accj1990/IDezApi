using System.ComponentModel.DataAnnotations;

namespace IDezApi.Domain.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public required string Id { get; set; } = default!;
    }
}
