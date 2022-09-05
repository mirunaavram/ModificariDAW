using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2.Entities;

namespace test2.Repositories
{
    public class ActivitateRepository : IActivitateRepository
    {
        private readonly TineriContext db;

        public ActivitateRepository(TineriContext db)
        {
            this.db = db;
        }

        public IQueryable<Activitate> GetActivitate()
        {
            var activitate = db.Activitate; //va fi mereu available pt ca o instantiez cand e instantiat controllerul
            return activitate;
        }

        public IQueryable<string> GetActivitateIds()
        {
            var activitateIds = db.Activitate.Select(x => x.Id);

            return activitateIds;
        }

        public IQueryable<Activitate> GetActivitateWithJoin()
        {
            var activitateJoin = db.Activitate
                .Include(x => x.PerioadaActivitate)
                .Include(x => x.TanarActivitate);
            return activitateJoin;
        }

        public async Task Create(Activitate activitate)
        {
            await db.Activitate.AddAsync(activitate);

            await db.SaveChangesAsync();
        }

        public async Task Update(Activitate activitate)
        {
            db.Activitate.Update(activitate);

            await db.SaveChangesAsync();
        }

        public void Delete(Activitate activitate)
        {
            db.Activitate.Remove(activitate);

            db.SaveChangesAsync();
        }

       
        
    }

}
