using eshop.Customer.Core.ViewModels;

namespace eshop.Customer.Core.Service.Interfaces;
public interface ICustomerService
{
    Task<List<CustomerViewModel>> GetAllCustomersAsync(CancellationToken cancellationToken = default); 
    Task<CustomerViewModel> GetCustomerById(int id, CancellationToken cancellationToken = default);
    Task AddNewCustomerAsync(CreateCustomerViewModel customer, CancellationToken cancellationToken = default);
    Task UpdateCustomerInfoAsyc(UpdateCustomerViewModel customer, CancellationToken cancellationToken = default);
    Task<AddressViewModel> GetAllAddressForCustomerAsync(string customerId, CancellationToken cancellationToken = default);
    Task AddNewAddressAsync(AddNewAddressViewModel address, CancellationToken cancellationToken = default);
    Task UpdateAddressAsync(UpdateCostomerAddressViewModel address, CancellationToken cancellationToken = default);
}
