using System.ComponentModel.DataAnnotations;

namespace Medicoz.Domain.Common.concrets;

public class BaseEntity
{
    [Key]
    public string Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string UpdatedBy { get; set; }
}
