namespace pb
{
    public interface IPhoneBookInterface
    {
        Task<PhoneBook> Get(int id);
        Task<IEnumerable<PhoneBook>> GetAll();
        Task Add(PhoneBook phoneBook);
        Task Update(PhoneBook phoneBook);
        Task Delete(int id);
    }
}
