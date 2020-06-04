using System;
using System.Collections.Generic;

namespace apbd13.Models
{
    public partial class Order
    {
        public Order()
        {
            ConfectioneryOrder = new HashSet<ConfectioneryOrder>();
        }

        public int IdOrder { get; set; }
        public DateTime DateAccepted { get; set; }
        public DateTime DateFinished { get; set; }
        public string Notes { get; set; }
        public int IdClient { get; set; }
        public int IdEmployee { get; set; }

        public virtual Customer IdClientNavigation { get; set; }
        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual ICollection<ConfectioneryOrder> ConfectioneryOrder { get; set; }
    }
}
