﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodFlow.DataLayer.Entities;

namespace BloodFlow.DataLayer.Interfaces.RepositoryInterfaces
{
    public interface IStreetRepository : IRepository<Street>
    {
        Task<Street?> GetByIdWithDetailsAsync(int streetId);

        Task<IEnumerable<Street?>> GetAllWithDetailsAsync();
    }
}
