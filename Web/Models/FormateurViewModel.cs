using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class FormateurViewModel
    {

        public short CodeFormateur { get; set; }
        public String Niveau { get; set; }
        public String NomFormateur { get; set; }
        public List<FormationViewModel> Formations { get; set; }

    }
}