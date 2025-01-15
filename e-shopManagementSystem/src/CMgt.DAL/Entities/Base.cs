
namespace CMgt.Domain.Entities;

public class Base
{
    public int Id { get; set; }

    public int CreatedBy { get; set; }
    public int? ModifiedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}
