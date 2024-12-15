
using System.ComponentModel.DataAnnotations;

namespace CMgt.shared.ViewModels;

public class OrderDto
{
    public int Quantity { get; set; }
    public int ProductId { get; set; }
}


public class OrderViewModel
{
    public DateTime OrderDate { get; set; }
    public string ProductName { get; set; }
    public string Size { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string Brand { get; set; }
    public string UserName { get; set; }
}

