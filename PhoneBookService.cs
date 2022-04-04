namespace pb
{
    public class PhoneBookService : IPhoneBookInterface
    {
        private readonly IRepository _repository;
        public PhoneBookService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task Add(PhoneBook phoneBook)
        {
            await _repository.AddAsync(phoneBook);
        }

        public async Task Delete(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<PhoneBook> Get(int id)
        {
            var result = await _repository.GetAsync(id);
            return result;
        }

        public async Task<IEnumerable<PhoneBook>> GetAll()
        {
            var result = await _repository.GetAllAsync();
            return result;
        }

        public async Task Update(PhoneBook phoneBook)
        {
            await _repository.UpdateAsync(phoneBook);
        }
    }
}
