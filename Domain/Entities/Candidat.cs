using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Candidat
    {
        public short IdCandidat { get; set; }
        public String CIN { get; set; }
        public String Email { get; set; }
        public String Image { get; set; }
        public String Nom { get; set; }
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])[a-zA-Z0-9]*$", ErrorMessage ="Password must contain at least one upper case lower case and a number")]
        public String Password { get; set; }
        public String Prenom { get; set; }
        public List<Formation> Formations { get; set; }
        public Formateur Formateur { get; set; }
    }
}
