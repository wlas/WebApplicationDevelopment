namespace WebApplicationDevelopment.Models.Entities
{
    public class Store : BaseModel
    {
        public virtual List<Product?> Products {  get; set; }
        public int Count { get; set; }
    }
}
