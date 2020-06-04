using System;
using System.Collections.Generic;

namespace apbd13.Models
{
    public partial class Perscriptions
    {
        public int IdPerscription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public int IdPatient { get; set; }

        public virtual Patients IdPatientNavigation { get; set; }
    }
}
