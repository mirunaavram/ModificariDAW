using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2.Entities;
using test2.Models;

namespace test2.Managers
{
    public interface IActivitateManager
    {
        List<Activitate> GetActivitate();
        List<string> GetActivitateIds();
        List<Activitate> GetActivitateWithJoin();
        List<ActivitateModel> GetActivitateFiltered();

        List<ActivitateModel> GetActivitatiOrdered();

        Activitate GetActivitateById(string id);
        Task Create(Activitate activitate);
        Task Update(ActivitateModel activitate);
        void Delete(string id);
    }
}
