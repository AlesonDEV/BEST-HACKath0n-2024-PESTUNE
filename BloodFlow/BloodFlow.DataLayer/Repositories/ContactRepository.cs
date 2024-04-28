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
    public class ContactRepository : IContactRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Contact> _dbSet;

        public ContactRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<Contact>();
        }

        public async Task AddAsync(Contact entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Delete(Contact entity)
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

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Contact?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Update(Contact entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }
    }
}
