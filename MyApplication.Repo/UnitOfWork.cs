using MyApplication.Data;
using MyApplication.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Repo
{
    public class UnitOfWork :IUnitOfWork
    {
        public MyApplicationDbContext  _context { get; private set; }
        private GenericRepository<ExceptionLogger> _ExceptionLoggerRepository;
        private GenericRepository<User> _UserRepository;
        private GenericRepository<Product> _ProductRepository;
        private GenericRepository<History> _HistoryRepository;
        private GenericRepository<Company> _CompanyRepository;
        public UnitOfWork(MyApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Save()
        {
            try
            {
                int _save = await _context.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch (System.Exception e)
            {
                return await Task.FromResult(false);
            }
        }
        public GenericRepository<ExceptionLogger> ExceptionLoggerRepository
        {
            get
            {

                if (this._ExceptionLoggerRepository == null)
                {
                    this._ExceptionLoggerRepository = new GenericRepository<ExceptionLogger>(_context);
                }
                return _ExceptionLoggerRepository;
            }
        }
        public GenericRepository<User> UserRepository
        {
            get
            {

                if (this._UserRepository == null)
                {
                    this._UserRepository = new GenericRepository<User>(_context);
                }
                return _UserRepository;
            }
        }

        public GenericRepository<Product> ProductRepository
        {
            get
            {

                if (this._ProductRepository == null)
                {
                    this._ProductRepository = new GenericRepository<Product>(_context);
                }
                return _ProductRepository;
            }
        }
        public GenericRepository<History> HistoryRepository
        {
            get
            {
                if (this._HistoryRepository == null)
                {
                    this._HistoryRepository = new GenericRepository<History>(_context);
                }
                return _HistoryRepository;
            }
        }
        public GenericRepository<Company> CompanyRepository
        {
            get
            {
                if (this._CompanyRepository == null)
                {
                    this._CompanyRepository = new GenericRepository<Company>(_context);
                }
                return _CompanyRepository;
            }
        }
    }
}
