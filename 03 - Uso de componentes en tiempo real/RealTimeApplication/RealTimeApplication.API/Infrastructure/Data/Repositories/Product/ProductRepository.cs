using AutoMapper;
using RealTimeApplication.API.Infrastructure.Data.Contexts;
using RealTimeApplication.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RealTimeApplication.API.Infrastructure.Data.Repositories.Product
{
    using RealTimeApplication.API.Infrastructure.Data.Entities;
    public class ProductRepository : IProductRepository
    {
        private readonly RealtimeapplicationContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(RealtimeapplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<ProductDto> List()
        {
            return _mapper.Map<List<ProductDto>>(_context.Products.ToList());
        }

        public ProductDto GetByProductId(int productId)
        {
            return _mapper.Map<ProductDto>(_context.Products.Where(w => w.ProductId == productId).FirstOrDefault());
        }

        public ProductDto Update(ProductDto Product)
        {
            Product ProductUpdate = _context.Products.Where(w => w.ProductId == Product.ProductId).FirstOrDefault();
            ProductUpdate = _mapper.Map<Product>(Product);
            _context.Products.Update(ProductUpdate);
            _context.SaveChanges();

            return _mapper.Map<ProductDto>(ProductUpdate);
        }

        public ProductDto Insert(ProductDto Product)
        {
            Product ProductCreate = new Product();
            ProductCreate = _mapper.Map<Product>(Product);
            _context.Products.Add(ProductCreate);
            _context.SaveChanges();

            return _mapper.Map<ProductDto>(ProductCreate);
        }

        public ProductDto Delete(int ProductId)
        {
            Product ProductDelete = _context.Products.Where(w => w.ProductId == ProductId).FirstOrDefault();
            _context.Products.Remove(ProductDelete);
            _context.SaveChanges();

            return _mapper.Map<ProductDto>(ProductDelete);
        }
    }
}
