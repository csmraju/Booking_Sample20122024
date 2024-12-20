using BookingSampleApp_V1.Models;

namespace BookingSampleApp_V1.Interfaces
{
    public interface IBook
    {
        public Task<string> Add(Book model);

        public Task<string> Update(Book model);

        public Task<string> Delete(int? BookId);

        public Task<IList<Book>> GetAll();

        public Task<Book> GetById(int? BookId);
        
    }
}
