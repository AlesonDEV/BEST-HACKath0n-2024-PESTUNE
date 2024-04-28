using BloodFlow.DataLayer.Entities;
using BloodFlow.DataLayer.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.DataLayer.Repositories
{
    internal class DonorCenterRepository : IDonorCenterRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<DonorCenter> _dbSet;

        public DonorCenterRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<DonorCenter>();
        }

        public async Task<IEnumerable<DonorCenter>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<DonorCenter?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(DonorCenter entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Delete(DonorCenter entity)
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

        public void Update(DonorCenter entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public async Task<DonorCenter?> GetByIdWithDetailsAsync(int donorCenterId)
        {
            return await _dbSet.Include(donorCenter => donorCenter.Contact)
                .Include(donorCenter => donorCenter.Street)
                .Include(donorCenter => donorCenter.Orders)
                .FirstOrDefaultAsync(donorCenter => donorCenter.Id == donorCenterId);
        }

        public async Task<IEnumerable<DonorCenter?>> GetAllWithDetailsAsync()
        {
            return await _dbSet.Include(donorCenter => donorCenter.Contact)
                .Include(donorCenter => donorCenter.Street)
                .Include(donorCenter => donorCenter.Orders)
                .ToListAsync();
        }
    }
}
