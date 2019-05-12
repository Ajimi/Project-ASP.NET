using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    public enum TypeFormation
    {
        Locale, EnLigne
    }
    public class Formation
    {
        public short CodeFormateur { get; set; }
        public DateTime Date { get; set; }
        public String Description { get; set; }
        public int Duree { get; set; }
        public short IdFormation { get; set; }
        public int NbParticipants { get; set; }
        public String NomFormation { get; set; }
        public int Prix { get; set; }
        public TypeFormation TypeFormation { get; set; }
    }
}
