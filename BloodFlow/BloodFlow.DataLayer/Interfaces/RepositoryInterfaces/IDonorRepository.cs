﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodFlow.DataLayer.Entities;

namespace BloodFlow.DataLayer.Interfaces.RepositoryInterfaces
{
    public interface IDonorRepository : IRepository<Donor>
    {
        Task<Donor?> GetByIdWithDetailsAsync(int donorId);

        Task<IEnumerable<Donor>> GetAllWithDetailsAsync();
    }
}
