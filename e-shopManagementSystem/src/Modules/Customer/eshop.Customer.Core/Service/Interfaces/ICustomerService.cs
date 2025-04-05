using eshop.Customer.Core.ViewModels;

namespace eshop.Customer.Core.Service.Interfaces;
public interface ICustomerService
{
    Task<List<CustomerViewModel>> GetAllCustomersAsync(CancellationToken cancellationToken = default); 
    Task<CustomerViewModel> GetCustomerById(int id, CancellationToken cancellationToken = default);
    Task AddNewCustomerAsync(NewCustomerViewModel customer, CancellationToken cancellationToken = default);
    Task UpdateCustomerInfoAsyc(int customerId, CreateCustomerViewModel customer, CancellationToken cancellationToken = default);
    Task<AddressViewModel> GetAllAddressForCustomerAsync(string customerId, CancellationToken cancellationToken = default);
    Task AddNewAddressAsync(CreateNewAddressViewModel address, CancellationToken cancellationToken = default);
    Task UpdateAddressAsync(int addressId, CreateNewAddressViewModel address, CancellationToken cancellationToken = default);
    Task DeleteAddressAsync(int addressId,  CancellationToken cancellationToken = default); 
}
