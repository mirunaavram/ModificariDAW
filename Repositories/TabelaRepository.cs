using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2.Entities;

namespace test2.Repositories
{
    public class TabelaRepository : ITabelaRepository
    {
        private readonly TineriContext db;
        public TabelaRepository(TineriContext db)
        {
            this.db = db;
        }

        public IQueryable<Tabela> GetTabela()
        {
            var tabela= db.Tabela; //va fi mereu available pt ca o instantiez cand e instantiat controllerul
            return tabela;
        }

        /*
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
        */

        public async Task Create(Tabela tabela)
        {
            await db.Tabela.AddAsync(tabela);

            await db.SaveChangesAsync();
        }

        public async Task Update(Tabela tabela)
        {
            db.Tabela.Update(tabela);

            await db.SaveChangesAsync();
        }

        public void Delete(Tabela tabela)
        {
            db.Tabela.Remove(tabela);

            db.SaveChangesAsync();
        }
    }
}
