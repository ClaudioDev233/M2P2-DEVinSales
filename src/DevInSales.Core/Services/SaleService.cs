using DevInSales.Core.Data.Context;
using DevInSales.Core.Entities;
using DevInSales.Core.Interfaces;

namespace DevInSales.Core.Services
{
    public class SaleService : ISaleService
    {
        private readonly DataContext _context;

        public SaleService(DataContext context)
        {
            _context = context;
        }
        public int CreateSale(Sale sale)
        {
            throw new NotImplementedException();
        }

        public Sale? GetSaleById(int id)
        {
            throw new NotImplementedException();
        }
    }
}