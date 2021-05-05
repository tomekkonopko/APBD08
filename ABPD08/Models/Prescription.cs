using ABPD08.Models;
using System;
using System.Collections.Generic;

namespace ABPD08.Models
{
    public class Prescription
    {
        public Prescription()
        {
            PresciptionMedicaments = new HashSet<PresciptionMedicament>();
        }

        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }

        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }

        public ICollection<PresciptionMedicament> PresciptionMedicaments { get; set; }

    }
}