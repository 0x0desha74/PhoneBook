using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Entities;
using PhoneBook.Core.Repositories;
using PhoneBook.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Repository.Repositories
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ContactRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<Contact>> SearchAsync(string searchWord)
        {
            if (string.IsNullOrEmpty(searchWord))
                return await _dbContext.Contacts.ToListAsync();

            searchWord = searchWord.ToLower();
            return await _dbContext.Contacts
                   .Where(c => EF.Functions.Like(c.Name.ToLower(), $"%{searchWord}%") ||
                               EF.Functions.Like(c.PhoneNumber, $"%{searchWord}%") ||
                               EF.Functions.Like(c.Email.ToLower(), $"%{searchWord}%"))
                   .ToListAsync();

        }
    }
}
