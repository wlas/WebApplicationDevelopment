namespace WebApplicationDevelopment.Models.Entities
{
    public class Store : BaseModel
    {
        public virtual List<Product?> Products {  get; set; }
    }
}
