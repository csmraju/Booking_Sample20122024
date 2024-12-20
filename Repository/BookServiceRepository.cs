using BookingSampleApp_V1.DataAccess;
using BookingSampleApp_V1.Interfaces;
using BookingSampleApp_V1.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BookingSampleApp_V1.Repository
{
    public class BookServiceRepository : IBook
    {
        private readonly BookingDbContext _contextDb;

        public BookServiceRepository(BookingDbContext contextDb)
        {
            _contextDb = contextDb;
        }

        public async Task<string> Add(Book model)
        {
            string response = "Record Saved";
            await _contextDb.Book.AddAsync(model);
            _contextDb.SaveChanges();
            return response;
        }

        public async Task<string> Update(Book model)
        {
            string response = "Record Not found";
            var book =  _contextDb.Book.Where(x=>x.BookId==model.BookId).FirstOrDefault();
            if (book != null)
            {
                book.Author = model.Author;
                book.PublishYear = model.PublishYear;
                book.Price = model.Price;
                book.Generation = model.Generation;
                book.Title = model.Title;
                _contextDb.Attach(book).State = EntityState.Modified;
                //_contextDb.Book.Update(model);
                await _contextDb.SaveChangesAsync();
                response ="Record Updated";
            }
            
            return response;
        }

        public async Task<string> Delete(int? BookId)
        {
            string response = "Record Not found";
            var book = await _contextDb.Book.Where(x => x.BookId == BookId).FirstOrDefaultAsync();
            if (book != null)
            {
                _contextDb.Book.Remove(book);
                _contextDb.SaveChanges();
                response = "Record Deleted";
            }
            return response;
        }

        public async Task<IList<Book>> GetAll()
        {
            var bookings = await  _contextDb.Book.ToListAsync();
            return bookings;
        }

        public async Task<Book> GetById(int? BookId)
        {
            var book = await _contextDb.Book.Where(x=>x.BookId == BookId).FirstOrDefaultAsync();
            return book;
        }


    }
}
