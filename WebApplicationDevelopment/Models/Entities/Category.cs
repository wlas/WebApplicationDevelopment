﻿namespace WebApplicationDevelopment.Models.Entities
{
    public class Category : BaseModel
    {
        public virtual List<Product?> Products { get; set; } = new List<Product>();
    }
}
