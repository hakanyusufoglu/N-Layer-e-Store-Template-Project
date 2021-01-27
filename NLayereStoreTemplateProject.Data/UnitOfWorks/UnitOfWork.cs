﻿using NLayereStoreTemplateProject.Core.Repositories;
using NLayereStoreTemplateProject.Core.UnitOfWorks;
using NLayereStoreTemplateProject.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Data.UnitOfWorks
{
    //tüm işlemler onaylandıktan sonra tek bir adım ile veritabanına veri kaydetme, değiştirme işlemleri gerçekleştirilmektedir.
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private OrderRepository _orderRepository;
        private ProductRepository _productRepository;
        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public IOrderRepository Order => _orderRepository = _orderRepository ?? new OrderRepository(_context);

        public IProductRepository Product => _productRepository = _productRepository ?? new ProductRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
