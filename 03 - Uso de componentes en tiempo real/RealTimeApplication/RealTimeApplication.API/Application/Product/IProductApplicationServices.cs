using RealTimeApplication.Infrastructure.Dtos;
using System.Collections.Generic;

namespace RealTimeApplication.API.Application.Product
{
    public interface IProductApplicationServices
    {
        ProductDto Delete(int ProductId);
        ProductDto GetByProductId(int ProductId);
        ProductDto Insert(ProductDto Product);
        List<ProductDto> List();
        ProductDto Update(int ProductId, ProductDto Product);
    }
}