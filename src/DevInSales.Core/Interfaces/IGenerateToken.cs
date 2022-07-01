using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevInSales.Core.Entities;

namespace DevInSales.Core.Interfaces
{
    public interface IGenerateToken
    {
        public Task<string> GerarToken(User user);
    }
}