﻿using BookAPI.Models;
using BookAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Repositories
{
    public class BookRepository : IBookRepository
    {

        private readonly BookContext _context;
        public BookRepository(BookContext context)
        {
            _context = context;
        }


        public  async Task<Book> Create(Book book)
        {
            _context.Book.Add(book);
          await  _context.SaveChangesAsync();

            return book;

        }

        public async Task Delete(int id)
        {
            var bookToDelete = await _context.Book.FindAsync(id);

            _context.Book.Remove(bookToDelete);

           await _context.SaveChangesAsync();


        }

        public async  Task<IEnumerable<Book>> Get()
        {
            return await _context.Book.ToListAsync();
        }

        public async Task<Book> GetOne(int id)
        {
            var bookToGet = await _context.Book.FindAsync(id);

            return bookToGet;

        }

        public async  Task Update(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;

            await _context.SaveChangesAsync();




        }
    }
}
