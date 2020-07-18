using System;
using System.Collections.Generic;
using System.Text;

namespace RealTimeApplication.Infrastructure.Dtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public string Feature01 { get; set; }
        public string Feature02 { get; set; }
        public decimal Price { get; set; }
        public string FileImage { get; set; }
    }
}
