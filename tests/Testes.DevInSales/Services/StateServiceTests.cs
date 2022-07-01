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
    public class StateServiceTests
    {
        private DataContext _context;
        private StateService _stateService;

        public StateServiceTests()
        {
            _context = new DataContext(new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);
            _stateService = new StateService(_context);
            Seed();

        }
        [Fact]
        public void GetAll_ObterLista_RetornaLista()
        {
            var expected = _context.States.ToList();

            var actual = _stateService.GetAll(null);

            Assert.Equal(expected.Count(), actual.Count());
        }
        [Fact]
        public void GetAll_ObterLista_RetornaEspecifico()
        {

            var expected = _context.States.ToList();

            var actual = _stateService.GetAll("Estado Teste1");

            Assert.Equal(expected.FirstOrDefault().Name, actual.FirstOrDefault().Name);
        }

        [Fact] //BUGADO
        public void GetById_RetornaEstadoPeloIdDoEstado()
        {
            var readState = new ReadState { Id = 1, Name = "Estado Teste1", Initials = "ST1" };

            var expected = _context.States.FirstOrDefault(x => x.Id == 1);
            var actual = _stateService.GetById(1);
            Assert.Equal(readState, actual);
        }
        public void Seed()
        {
            _context.States.AddRange(new List<State>(

            ){
                new State(1 , "Estado Teste1", "ST1"),
                new State(2 , "Estado Teste2", "ST2")
            });
            _context.SaveChanges();
        }
    }
}