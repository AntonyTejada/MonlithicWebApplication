namespace MonolithicWebApplication.Infraestructure.API.Models
{
    public class ExternalProduct
    {
        public int IdProduct { set; get; }
        public string NameProduct { set; get; }
        public string DescriptionProduct { set; get; }
        public string ImageUrlProduct { get; set; }
        public int MemoryProduct { get; set; }
        public int StorageCapacityProduct { get; set; }
        public string ResolutionImageProduct { get; set; }
        public double PriceProduct { get; set; }
    }
}
