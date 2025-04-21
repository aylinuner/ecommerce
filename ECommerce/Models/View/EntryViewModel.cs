using ecommerce.Models;

namespace ecommerce.Models.View
{
    public class EntryViewModel
    {
        public int Id { get; set; }

        public string WaybillNo { get; set; } = null!;

        public DateTime WaybillDate { get; set; }

        public int WaybillTotal { get; set; }

        public int? SupplierId { get; set; }

        public int? ReceiverId { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }
        public virtual List<EntryDetailViewModel> EntryDetails { get; set; } = new List<EntryDetailViewModel>();
    }

    public class EntryDetailViewModel
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;

        public int ProductId { get; set; }

        public int StockMasterId { get; set; }

        public string ProductName { get; set; } = null!;

        public int Quantity { get; set; }

        public int Amount { get; set; }

        public int TotalAmount { get; set; }

        public int Weight { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int EntryMasterId { get; set; }

        public Product Product { get; set; }
        public StockMaster StockMaster { get; set; }

    }
}
