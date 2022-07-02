using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevInSales.Core.Data.Context;
using DevInSales.Core.Entities;
using DevInSales.Core.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Moq;
using DevInSales.Core.Data.Dtos;

namespace Testes.DevInSales.Services
{
    public class AddressServiceTests
    {
        private DataContext _context;
        private AddressService _addressService;
        public AddressServiceTests()
        {
            _context = new DataContext(new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);
            _addressService = new AddressService(_context);
            Seed();
        }
        [Fact]
        public void Add_AdicionaUmEnderecoNoBanco()
        {
            var novoEndereco = new Address("Rua Teste Adiciona", "26598-592", 123, "Casa 2", 1);
            _addressService.Add(novoEndereco);

        }

        [Fact]
        public void GetById_RetornaEnderecoPeloAddressId()
        {
            var expected = _context.Addresses.FirstOrDefault(x => x.Id == 1);
            var actual = _addressService.GetById(1);
            Assert.Equal(expected, actual);
        }
        public void Seed()
        {
            _context.States.AddRange(new List<State>()
            {
                new State(1,"Estado Teste", "ET"),
                 new State(2,"Estado Teste2", "ET2")

            });
            _context.Cities.AddRange(new List<City>()
            {
                new City(1, "Cidade Teste"),
                new City(2, "Cidade Teste2")
            });
            _context.Addresses.AddRange(new List<Address>(){
                new Address("Rua Testinho", "89525-589", 250, "Casa", 1),
                new Address("Rua Teste", "25982-589", 230, "Apt", 2),
            });
            _context.SaveChanges();
        }
    }
}