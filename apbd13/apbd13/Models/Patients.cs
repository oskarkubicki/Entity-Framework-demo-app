﻿using System;
using System.Collections.Generic;

namespace apbd13.Models
{
    public partial class Patients
    {
        public Patients()
        {
            Perscriptions = new HashSet<Perscriptions>();
        }

        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }

        public virtual ICollection<Perscriptions> Perscriptions { get; set; }
    }
}
