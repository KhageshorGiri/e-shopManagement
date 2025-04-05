using eshop.Customer.Core.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eshop.Customer.Core.ViewModels;
public class CustomerViewModel
{
    public int Id { get; set; }
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
}

public class NewCustomerViewModel
{
    public CreateCustomerViewModel CreateCustomerViewModel { get; set; }
    public CreateNewAddressViewModel CreateNewAddressViewModel { get; set; }
}

public class CreateCustomerViewModel
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

public class AddressViewModel
{
    public int Id { get; set; }
    public string Province { get; set; }
    public string City { get; set; }
    public string Zone { get; set; }
    public string AddressLocation { get; set; }
    public string LandMark { get; set; }
    public int CustomerId { get; set; }
}

public class CreateNewAddressViewModel
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

    [Required]
    public int CustomerId { get; set; }
}

// Object Mapping
public static class CustomerMapper
{
    public static Customers AsCustomerEntity(this CreateCustomerViewModel viewModel)
    {
        return new Customers
        {
            FullName = viewModel.FullName,
            Email = viewModel.Email,
            PhoneNumber = viewModel.PhoneNumber,
            DateOfBirth = viewModel.DateOfBirth,
        };
    }

    public static CustomerViewModel AsCustomerViewModel(this Customers entity)
    {
        return new CustomerViewModel
        {
            Id = entity.Id,
            FullName = entity.FullName,
            Email = entity.Email,
            PhoneNumber = entity.PhoneNumber,
            DateOfBirth = entity.DateOfBirth,
        };
    }

    public static List<CustomerViewModel> AsCustomerViewModelList(this List<Customers> list)
    {
        var result = new List<CustomerViewModel>();
        foreach(var customer in list)
        {
            result.Add(customer.AsCustomerViewModel());
        }
        return result;
    }
}

public static class AddressMapper
{
    public static Address AsAddressEntity(this CreateNewAddressViewModel viewModel)
    {
        return new Address
        {
           Province = viewModel.Province,
           City = viewModel.City,
           Zone = viewModel.Zone,
           AddressLocation = viewModel.AddressLocation,
           LandMark = viewModel.LandMark,
           CustomerId = viewModel.CustomerId,
        };
    }

    public static AddressViewModel AsAddressViewModel(this Address entity)
    {
        return new AddressViewModel
        {
            Id = entity.Id,
            Province = entity.Province,
            City = entity.City,
            Zone = entity.Zone,
            AddressLocation = entity.AddressLocation,
            LandMark = entity.LandMark,
            CustomerId = entity.CustomerId,
        };
    }

    public static List<AddressViewModel> AsAddressViewModelList(this List<Address> list)
    {
        var result = new List<AddressViewModel>();
        foreach (var address in list)
        {
            result.Add(address.AsAddressViewModel());
        }
        return result;
    }
}