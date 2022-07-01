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
    public class SaleProductServiceTests
    {
        private readonly DataContext _context;
        private readonly SaleProductService _saleProduct;
        public SaleProductServiceTests()
        {
            _context = new DataContext(new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);
            _saleProduct = new SaleProductService(_context);
            Seed();
        }

        [Fact]
        public void GetSaleProductById_RetornaSaleProductComSucesso()
        {
           
            SaleProduct? expected = _context.SaleProducts.FirstOrDefault(x => x.Id == 2);
            var actual = _saleProduct.GetSaleProductById(2);

            Assert.Equal(expected.Id, actual);
        }

        public void Seed()
        {
            _context.SaleProducts.AddRange(new List<SaleProduct>(){
                new SaleProduct(1, 1, 10, 5),
                new SaleProduct(2, 3, 15, 15),
            });
            _context.SaveChanges();
        }
    }
}