using eshop.Customer.Core.Service.Interfaces;
using eshop.Customer.Core.ViewModels;

namespace eshop.Customer.Core.Service;
internal class CustomerService : ICustomerService
{
    public Task AddNewAddressAsync(AddNewAddressViewModel address, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task AddNewCustomerAsync(CreateCustomerViewModel customer, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<AddressViewModel> GetAllAddressForCustomerAsync(string customerId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<List<CustomerViewModel>> GetAllCustomersAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<CustomerViewModel> GetCustomerById(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAddressAsync(UpdateCostomerAddressViewModel address, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCustomerInfoAsyc(UpdateCustomerViewModel customer, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
