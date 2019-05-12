using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class FormationViewModel
    {
        public int CodeFormateur { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }
        public String Description { get; set; }
        public DateTime Duree { get; set; }
        public short IdFormation { get; set; }
        public int NbParticipants { get; set; }
        public String NomFormation { get; set; }
        public int Prix { get; set; }
        public TypeFormation TypeFormation { get; set; }
        public FormateurViewModel FormateurViewModel { get; set; }
    }
}