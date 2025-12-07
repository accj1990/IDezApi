using System.ComponentModel.DataAnnotations.Schema;

using IDezApi.Domain.Common;

namespace IDezApi.Domain.Entity
{
    [Table("user", Schema = "public")]
    public class User : BaseEntity
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string? Picture { get; set; } = default!;
        public required bool IsAdmin { get; set; } = false;
    }
}
