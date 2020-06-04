using System;
using System.Collections.Generic;

namespace apbd13.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }

        public int IdClient { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
