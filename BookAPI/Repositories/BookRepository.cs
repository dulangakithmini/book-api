﻿using System.Collections.Generic;
using System.Threading.Tasks;
using BookAPI.Models;

namespace BookAPI.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _context;

        public BookRepository(BookContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Book>> Get()
        {
            throw new System.NotImplementedException();
        }

        public Task<Book> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Book> Create(Book book)
        {
            throw new System.NotImplementedException();
        }

        public Task<Book> Update(Book book)
        {
            throw new System.NotImplementedException();
        }

        public Task<Book> Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}