namespace ecommerce.Models.View
{
    public class StockMasterViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ColorId { get; set; }
        public string Storage { get; set; }
        public string Code { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public DateOnly CreateDate { get; set; }
        public DateOnly UpdateDate { get; set; }
        public virtual Color Color { get; set; } = null;
    }
}
