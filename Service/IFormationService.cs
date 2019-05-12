using Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IFormationService:IService<Formation>
    {
        List<Formation> getFormationsByDate(DateTime date);

        List<Formation> getTodayFormation();
    }
}
