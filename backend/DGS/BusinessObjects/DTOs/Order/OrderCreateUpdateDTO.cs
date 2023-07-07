using DGS.BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DGS.BusinessObjects.DTOs.Order
{
    public class OrderCreateUpdateDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? CustomerName { get; set; }
        [JsonIgnore]
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public decimal? TotalPrice { get; set; }
        public string? ShipAddress { get; set; }
        public OrderStatus Status { get; set; }
    }
}
