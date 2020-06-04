using System;
using System.Collections.Generic;

namespace apbd13.Models
{
    public partial class ConfectioneryOrder
    {
        public int IdConfection { get; set; }
        public int IdOrder { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }

        public virtual Confectionery IdConfectionNavigation { get; set; }
        public virtual Order IdOrderNavigation { get; set; }
    }
}
