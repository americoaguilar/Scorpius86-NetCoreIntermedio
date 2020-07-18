using RealTimeApplication.Infrastructure.Dtos;
using System.Collections.Generic;

namespace RealTimeApplication.API.Infrastructure.Data.Repositories.Product
{
    public interface IProductRepository
    {
        ProductDto Delete(int ProductId);
        ProductDto GetByProductId(int productId);
        ProductDto Insert(ProductDto Product);
        List<ProductDto> List();
        ProductDto Update(ProductDto Product);
    }
}