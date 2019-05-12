using Data.Infrastructure;
using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class FormationService:Service<Formation>, IFormationService
    {
        public static IDatabaseFactory dbFactory = new DatabaseFactory();
        public static IUnitOfWork ut = new UnitOfWork(dbFactory);
        public FormationService() : base(ut)
        {

        }

        public List<Formation> getFormationsByDate(DateTime date)
        {
            return GetMany(x => equalsMonth(x.Date, date)).ToList();
        }

        public List<Formation> getTodayFormation()
        {
            return GetAll().Where(f => f.Date > DateTime.Now).ToList();
        }
        private bool equalsMonth(DateTime x, DateTime date)
        {
            return x.Year == date.Year && x.Month == date.Month;
        }
    }
}
