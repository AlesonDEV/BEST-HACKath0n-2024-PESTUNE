using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodFlow.DataLayer.Entities;
using BloodFlow.DataLayer.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace BloodFlow.DataLayer.Repositories
{
    internal class DonorCenterContactRepository : IDonorCenterContactRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<DonorCenterContact> _dbSet;

        public DonorCenterContactRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<DonorCenterContact>();
        }

        public async Task<IEnumerable<DonorCenterContact>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<DonorCenterContact?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(DonorCenterContact entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Delete(DonorCenterContact entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public void Update(DonorCenterContact entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }
    }
}
