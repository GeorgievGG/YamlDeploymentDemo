using System;
using System.ComponentModel.DataAnnotations;

namespace YamlDeploymentWeb.Models
{
    public class BikeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }
        public DateTime RentedUntil { get; set; }
    }
}
