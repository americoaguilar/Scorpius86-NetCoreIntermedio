using RealTimeApplication.API.Infrastructure.Data.Repositories.Product;
using RealTimeApplication.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeApplication.API.Application.Product
{
    public class ProductApplicationServices : IProductApplicationServices
    {
        private readonly IProductRepository _ProductRepository;

        public ProductApplicationServices(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }

        public List<ProductDto> List()
        {
            return _ProductRepository.List();
        }

        public ProductDto GetByProductId(int ProductId)
        {
            return _ProductRepository.GetByProductId(ProductId);
        }
        public ProductDto Update(int ProductId, ProductDto Product)
        {
            Product.ProductId = ProductId;
            return _ProductRepository.Update(Product);
        }

        public ProductDto Insert(ProductDto Product)
        {
            return _ProductRepository.Insert(Product);
        }
        public ProductDto Delete(int ProductId)
        {
            return _ProductRepository.Delete(ProductId);
        }
    }
}
