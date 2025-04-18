using ecommerce.Models;

namespace ecommerce.Models.View
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int BasketId { get; set; }
        public int ProductId { get; set; }

        public string Delivery { get; set; }
        public string Address { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    

    //public virtual user user { get; set; } = null!; // User tablosuna erişim sağlar
    //public virtual product product { get; set; } = null!; // Product tablosuna erişim sağlar
    //public virtual basket basket { get; set; } = null!; // Basket tablosuna erişim sağlar



}
}
