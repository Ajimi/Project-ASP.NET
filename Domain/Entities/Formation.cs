using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public enum TypeFormation
    {
        Locale, EnLigne
    }
    public class Formation
    {
        [Key, Column(Order = 0)]
        public short IdFormation { get; set; }
        [Column(TypeName = "Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }
        public String Description { get; set; }
        public DateTime Duree { get; set; }
        public int NbParticipants { get; set; }
        public String NomFormation { get; set; }
        public int Prix { get; set; }

        public int CodeFormateur { get; set; }
        public TypeFormation TypeFormation { get; set; }
        public Formateur Formateur { get; set; }
        public List<Candidat> Candidats { get; set; }
    }
}
