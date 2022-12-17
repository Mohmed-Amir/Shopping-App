using System;
using System.Collections.Generic;

#nullable disable

namespace Shop.DataModels.Models
{
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }
        public int? SubTotal { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedOn { get; set; }
    }
}
