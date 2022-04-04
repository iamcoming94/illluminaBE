namespace pb
{
    public interface IRepository
    {
        Task<PhoneBook> GetAsync(int id);
        Task<IEnumerable<PhoneBook>> GetAllAsync();
        Task UpdateAsync(PhoneBook entity);
        Task DeleteAsync(int id);
        Task AddAsync(PhoneBook entity);        
    }
}
