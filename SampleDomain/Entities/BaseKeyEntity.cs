using System.ComponentModel.DataAnnotations;

namespace SampleDomain.Entities;

public abstract class BaseKeyEntity
{
    [Key]
    public Guid Id { get; set; }
}
