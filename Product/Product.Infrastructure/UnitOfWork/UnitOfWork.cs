using Product.Domain.Interfaces.Repositories;
using Product.Domain.Interfaces.UnitOfWork;
using Product.Domain.Models;
using Product.Infrastructure.Context;
using Product.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IRepository<Category> _categoryRepository;
        private IRepository<Domain.Models.Product> _productRepository;

        public UnitOfWork(ApplicationDbContext context, IRepository<Category> categoryRepository, IRepository<Domain.Models.Product> productRepository)
        {
            _context = context;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public IRepository<Category> Category => _categoryRepository ??= new Repository<Category>(_context);
        public IRepository<Domain.Models.Product> Product => _productRepository ??= new Repository<Domain.Models.Product>(_context);

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
