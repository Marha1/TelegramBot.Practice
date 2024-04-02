using System.ComponentModel.DataAnnotations;
namespace Domain.Models;
  public abstract class BaseEntity
{
    /// <summary>
    /// Уникальный идентификатор сущности.
    /// </summary>
    public Guid Id { get; set; }
    public string? Name { get; set; }
    
}