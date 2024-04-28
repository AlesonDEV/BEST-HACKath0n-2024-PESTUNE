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
    public class OrderRepository : IOrderRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Order> _dbSet;

        public OrderRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<Order>();
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(Order entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Delete(Order entity)
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

        public void Update(Order entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public async Task<Order?> GetByIdWithDetailsAsync(int orderId)
        {
            return await _dbSet.Include(order => order.DonorOrders)
                    .ThenInclude(dor => dor.Donor)
                .Include(order => order.DonorCenter)
                .Include(order => order.Importance)
                .FirstOrDefaultAsync(order => order.Id == orderId);
        }

        public async Task<IEnumerable<Order>> GetAllWithDetailsAsync()
        {
            return await _dbSet.Include(order => order.DonorOrders)
                    .ThenInclude(dor => dor.Donor)
                .Include(order => order.DonorCenter)
                .Include(order => order.Importance)
                .ToListAsync();
        }
    }
}
