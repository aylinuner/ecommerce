using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class EntryMaster
{
    public int Id { get; set; }

    public string WaybillNo { get; set; } = null!;

    public DateTime WaybillDate { get; set; }

    public int WaybillTotal { get; set; }

    public int? SupplierId { get; set; }

    public int? ReceiverId { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    //public virtual ICollection<EntryDetail> EntryDetail { get; set; } = new List<EntryDetail>();
}
