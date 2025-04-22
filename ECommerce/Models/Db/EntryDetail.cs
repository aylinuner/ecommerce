namespace ecommerce.Models.Db
{
    public class EntryDetail
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;

        //public int ProductId { get; set; }     
        public int StockId { get; set; }

        public string ProductName { get; set; } = null!;

        public int Quantity { get; set; }

        public int Amount { get; set; }

        public int TotalAmount { get; set; }

        public int Weight { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int EntryMasterId { get; set; }

        public virtual StockMaster Stock { get; set; } = null;


    }
}
