using eshop.Customer.Core.Data;
using eshop.Customer.Core.Entity;
using eshop.Customer.Core.Service.Interfaces;
using eshop.Customer.Core.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace eshop.Customer.Core.Service;
internal class CustomerService : ICustomerService
{
    private readonly CustomerDbContext _context;
    public CustomerService(CustomerDbContext context)
    {
        _context = context;
    }

    public async Task<List<CustomerViewModel>> GetAllCustomersAsync(CancellationToken cancellationToken = default)
    {
        var allCutomers = await (_context.Customers
                            .Select(c => new Customers
                            {
                                Id = c.Id,
                                FullName = c.FullName,
                                Email = c.Email,
                                PhoneNumber = c.PhoneNumber,
                            })
                            .AsNoTracking()
                            .ToListAsync(cancellationToken));

        return allCutomers.AsCustomerViewModelList();
    }

    public async Task<CustomerViewModel> GetCustomerById(int id, CancellationToken cancellationToken = default)
    {
        var allCutomers = await(_context.Customers.Where(c =>c.Id == id)
                            .Select(c => new Customers
                            {
                                Id = c.Id,
                                FullName = c.FullName,
                                Email = c.Email,
                                PhoneNumber = c.PhoneNumber,
                            })
                            .AsNoTracking()
                            .FirstOrDefaultAsync(cancellationToken));

        return allCutomers.AsCustomerViewModel();
    }

    public Task UpdateCustomerInfoAsyc(int customerId, CreateCustomerViewModel customer, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task AddNewCustomerAsync(NewCustomerViewModel customerInfo, CancellationToken cancellationToken = default)
    {
        var newCustomer = customerInfo.CreateCustomerViewModel.AsCustomerEntity();
        var newAddress = customerInfo.CreateNewAddressViewModel.AsAddressEntity();

        using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
        {
            try
            {
                await _context.Customers.AddAsync(newCustomer);
                await _context.SaveChangesAsync(cancellationToken);

                newAddress.CustomerId = newCustomer.Id;
                await _context.Addresses.AddAsync(newAddress);
                await _context.SaveChangesAsync(cancellationToken);

                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }
    }

    public Task AddNewAddressAsync(CreateNewAddressViewModel address, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<AddressViewModel> GetAllAddressForCustomerAsync(string customerId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAddressAsync(int addressId, CreateNewAddressViewModel address, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAddressAsync(int addressId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
