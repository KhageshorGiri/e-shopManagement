using System.ComponentModel.DataAnnotations;

namespace eshop.Customer.Domain.Entity;

internal class Customer : BaseEntity
{
    [Required]
    [StringLength(150, MinimumLength = 4)]
    public required string FullName { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }

    [Required]
    [StringLength(15, MinimumLength = 10)]
    public required string PhoneNumber { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime DateOfBirth { get; set; }
}
