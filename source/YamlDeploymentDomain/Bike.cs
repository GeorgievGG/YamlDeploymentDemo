using System;

namespace YamlDeploymentDomain
{
    public class Bike
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }
        public DateTime RentedUntil { get; set; }
    }
}
