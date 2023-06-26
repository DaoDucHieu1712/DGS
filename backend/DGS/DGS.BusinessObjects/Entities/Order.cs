﻿using DGS.BusinessObjects.Common;
using DGS.BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS.BusinessObjects.Entities
{
    [Table("Order")]
    public class Order : BaseEntity<int>
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        public int? CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? CreateAt { get; set; }
        public decimal? TotalPrice { get; set; }
        public string? ShipAddress { get; set; }
        public OrderStatus Status { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
