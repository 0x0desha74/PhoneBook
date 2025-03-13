using PhoneBook.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Repositories
{
   public interface IContactRepository
    {
        Task<IReadOnlyList<Contact>> SearchAsync(string searchWord);
    }
}
