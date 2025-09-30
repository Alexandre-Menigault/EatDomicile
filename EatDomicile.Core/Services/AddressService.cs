using EatDomicile.Core.Contexts;

namespace EatDomicile.Core.Services;

public class AddressService
{
    private readonly ProductContext _context;

    public AddressService(ProductContext context)
    {
        _context = context;
    }
    
    public bool AddressExists(int id)
    {
        return _context.Addresses.Any(a => a.Id == id);
    }
}