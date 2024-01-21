namespace WebApplicationDevelopment.Models.Entities
{
    public class Product : BaseModel
    {
        public decimal Price { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public int StoreId { get; set; }
        public virtual Store? Store { get; set; }
    }
}
 