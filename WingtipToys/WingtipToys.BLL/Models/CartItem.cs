using System;
using System.Collections.Generic;

namespace WingtipToys.BLL.Models
{
    public partial class CartItem
    {
        public string ItemId { get; set; }
        public string CartId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
