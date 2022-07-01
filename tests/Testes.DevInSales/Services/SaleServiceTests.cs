using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevInSales.Core.Data.Context;
using DevInSales.Core.Data.Dtos;
using DevInSales.Core.Entities;
using DevInSales.Core.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Testes.DevInSales.Services
{
    public class SaleServiceTests
    {
        private DataContext _context;
        private SaleService _saleService;
        public SaleServiceTests()
        {
            _context = new DataContext(new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);
            _saleService = new SaleService(_context);
            Seed();
        }

        [Fact]
        public void GetSaleProductsBySaleId_RetornaListaDeSaleProducts()
        {
            var expected = _context.SaleProducts
                .Where(p => p.SaleId == 1)
                .Include(p => p.Products)
                .Select(p => new SaleProductResponse(p.Products.Name, p.Amount, p.UnitPrice, p.Amount * p.UnitPrice))
                .ToList();
            var actual = _saleService.GetSaleProductsBySaleId(1);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetSaleBySellerId_RetornaTodasSalesDeUmDeterminadoSellerPeloId()
        {
            var expected = _context.Sales.Where(x => x.SellerId == 1);

            var actual = _saleService.GetSaleBySellerId(1);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetSaleByBuyerId_RetornaTodasSalesDeUmDeterminadoBuyerPeloId()
        {
            var expected = _context.Sales.Where(x => x.BuyerId == 1);

            var actual = _saleService.GetSaleByBuyerId(1);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetDeliveryById_RetornaUmDeliveryPeloDeliveryId()
        {
            var expected = _context.Deliveries.FirstOrDefault(x => x.Id == 1);
            var actual = _saleService.GetDeliveryById(1);

            Assert.Equal(expected, actual);
        }
        private void Seed()
        {
            _context.Sales.AddRange(new List<Sale>(){
                new Sale(1,2, new DateTime()),
                new Sale(2,1, new DateTime()),
                 new Sale(3,1, new DateTime()),
            });
            _context.Deliveries.AddRange(new List<Delivery>(){

                new Delivery(1, 1, new DateTime()),
                new Delivery(2, 2, new DateTime()),
            }
            );
            _context.SaveChanges();
        }
    }
}