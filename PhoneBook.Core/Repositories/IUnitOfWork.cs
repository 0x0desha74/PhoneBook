using PhoneBook.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Repositories
{
    public interface IUnitOfWork :IDisposable
    {
        IContactRepository ContactRepository { get; set; }
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        Task<int> Complete();

    }
}
