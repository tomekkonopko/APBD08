using System.Collections.Generic;

namespace ABPD08.Models
{
    public class Medicament
    {
        public Medicament()
        {
            PresciptionMedicaments = new HashSet<PresciptionMedicament>();
        }
        public int IdMedicament { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public ICollection<PresciptionMedicament> PresciptionMedicaments { get; set; }

    }
}