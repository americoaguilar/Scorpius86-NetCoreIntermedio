using System;
using System.Collections.Generic;
using System.Text;

namespace RealTimeApplication.Infrastructure.Dtos
{
    public class ClientDto
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string FileImageIcon { get; set; }
        public decimal Paid { get; set; }
        public int AveragePercentage { get; set; }
    }
}
