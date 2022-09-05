using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2.Entities;

namespace test2.Repositories
{
    public interface IActivitateRepository
    {

        
        IQueryable<Activitate> GetActivitate();
        IQueryable<string> GetActivitateIds();
        IQueryable<Activitate> GetActivitateWithJoin();

        Task Create(Activitate activitate);
        Task Update(Activitate activitate);
        void Delete(Activitate activitate);
    }
}
