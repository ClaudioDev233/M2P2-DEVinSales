using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevInSales.Core.Data.Context;
using DevInSales.Core.Entities;
using DevInSales.Core.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Testes.DevInSales.Services
{
    public class DeliveryServiceTests
    {
        public readonly DataContext _context;
        public readonly DeliveryService _deliveryService;
        public DeliveryServiceTests()
        {
            _context = new DataContext(new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);
            _deliveryService = new DeliveryService(_context);
            Seed();
        }
        // Getby no parameters
        [Fact]
        public void GetAll_ObterLista_RetornaListaSemParametros()
        {
            var expected = _context.Deliveries.ToList();
            var actual = _deliveryService.GetBy(null, null);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void GetAll_ObterLista_RetornaListaUsandoAddressId()
        {
            var expected = _context.Deliveries.Where(x => x.AddressId == 1);
            var actual = _deliveryService.GetBy(1, null);
            Assert.Equal(expected, actual);

        }
        [Fact]
        public void GetAll_ObterLista_RetornaListaUsandoSaleId()
        {
            var expected = _context.Deliveries.Where(x => x.SaleId == 1);
            var actual = _deliveryService.GetBy(1, null);
            Assert.Equal(expected, actual);

        }


        public void Seed()
        {
            _context.Deliveries.AddRange(new List<Delivery>(){
                new Delivery(1, 1, new DateTime()),
                new Delivery(2,2, new DateTime()),
            });
            _context.SaveChanges();
        }
    }
}