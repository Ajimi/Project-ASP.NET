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
    public class CandidatCount
    {
        public int count { get; set; }
        public Candidat candidat { get; set; }
    }
    public class CandidatService: Service<Candidat>, ICandidatService
    {
        public static IDatabaseFactory dbFactory = new DatabaseFactory();
        public static IUnitOfWork ut = new UnitOfWork(dbFactory);
        public CandidatService() : base(ut)
        {

        }

        public List<CandidatCount> numberOfParticipatedFormation()
        {

            return GetAll().Select(x => new CandidatCount { candidat = x, count = x.Formations.Count }).ToList();
        }

        public float priceOfFormation(Candidat candidat)
        {
            var formations = candidat.Formations;
            var totalPrice = formations.Select(s => s.Prix).Aggregate((x, y) => x + y);
            return totalPrice + totalPrice * ((formations.Count >= 5) ? 0.2f : 1);
        }

    }
}
