using Data.Infrastructure;
using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class FormateurService:Service<Formateur>, IFormateurService
    {
        public static IDatabaseFactory dbFactory = new DatabaseFactory();
        public static IUnitOfWork ut = new UnitOfWork(dbFactory);
        public FormateurService() : base(ut)
        {

        }

        public List<Formateur> getFirstThree()
        {
            return GetAll()
            .OrderBy(
                x => 
                x.Formations.Where(f=> f.TypeFormation == TypeFormation.EnLigne)
                .Select(formation => formation.NbParticipants)
                )
            .Take(3)
            .ToList();
        }
    }
}
