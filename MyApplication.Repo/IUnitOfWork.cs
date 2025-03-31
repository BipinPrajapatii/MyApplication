using MyApplication.Data;
using MyApplication.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MyApplication.Repo
{
    public interface IUnitOfWork
    {
        public MyApplicationDbContext _context { get; }
        Task<bool> Save();

        GenericRepository<ExceptionLogger> ExceptionLoggerRepository { get; }
        GenericRepository<User> UserRepository { get; }
        GenericRepository<Product> ProductRepository { get; }
        GenericRepository<History> HistoryRepository { get; }
        GenericRepository<Company> CompanyRepository { get; }
    }
}
