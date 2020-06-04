using System;
using System.Collections.Generic;

namespace apbd13.Models
{
    public partial class Confectionery
    {
        public Confectionery()
        {
            ConfectioneryOrder = new HashSet<ConfectioneryOrder>();
        }

        public int IdConfectionery { get; set; }
        public string NAme { get; set; }
        public float PricePerite { get; set; }
        public string Typ { get; set; }

        public virtual ICollection<ConfectioneryOrder> ConfectioneryOrder { get; set; }
    }
}
