using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eshop.Customer.Core.Entity;
internal class Address : BaseEntity
{
    [Required]
    [StringLength(50, MinimumLength = 5)]
    public string Province { get; set; }

    [Required]
    [StringLength(150, MinimumLength = 4)]
    public string City { get; set; }

    [Required]
    [StringLength(250, MinimumLength = 4)]
    public string Zone { get; set; }

    [Required]
    [StringLength(250, MinimumLength = 4)]
    public string AddressLocation { get; set; }

    [StringLength(250, MinimumLength = 4)]
    public string LandMark { get; set; }

    // Navigation to customer
    [ForeignKey(nameof(Customer))]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
}
