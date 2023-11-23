namespace OfferCatalog.API.Models
{
    public class ItemNew
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal JoiningFees { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Type { get; set; }
        public int DepartmentId { get; set; }
        public bool IsActive { get; set; }
        public bool IsPhysical { get; set; }
        public string ImageUrl { get; set; }
        
    }
}
