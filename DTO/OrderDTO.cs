﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    

    public class OrderDTO
    {
     public OrderDTO()
    {
            OrderItems = new HashSet<OrderItemDTO>();
    }
        public DateTime OrderDate { get; set; }
        public int OrderId { get; set; }
        public ICollection<OrderItemDTO> OrderItems { get; set; }
        public int OrderSum { get; set; }
        public int UserId { get; set; }
        
    }
}
