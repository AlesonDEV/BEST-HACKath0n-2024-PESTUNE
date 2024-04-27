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
    public class StreetRepository : IStreetRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Street> _dbSet;

        public StreetRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<Street>();
        }

        public async Task<IEnumerable<Street>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Street?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(Street entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Delete(Street entity)
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

        public void Update(Street entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }
    }
}
