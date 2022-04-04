using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace pb
{
    public class Repository : IRepository
    {
        private readonly dbContext _dbContext;

        public Repository(dbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task AddAsync(PhoneBook entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _dbContext.PhoneBooks.Where(x => x.ID == id).FirstOrDefaultAsync();
            if (result != null)
            {
                _dbContext.PhoneBooks.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<PhoneBook> GetAsync(int id)
        {
            return await _dbContext.PhoneBooks.Where(x => x.ID == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PhoneBook>> GetAllAsync()
        {
            return await _dbContext.PhoneBooks.ToListAsync();
        }

        public async Task UpdateAsync(PhoneBook entity)
        {
            _dbContext.PhoneBooks.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
