using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2.Entities;

namespace test2.Repositories
{
    public class TineriRepository : ITineriRepository //aici spunem cum se implementeaza
    {

        private readonly TineriContext db;

        public TineriRepository(TineriContext db)
        {
            this.db = db;
        }

        public IQueryable<Tanar> GetTineri()
        {
            var tineri = db.Tineri; //va fi mereu available pt ca o instantiez cand e instantiat controllerul
            return tineri;
        }

        public IQueryable<Guid> GetTineriIds()
        {
            var tineriIds = db.Tineri.Select(x => x.Id);

            return tineriIds;
        }

        public IQueryable<Tanar> GetTineriWithJoin()
        {
            var tineriJoin = db.Tineri
                .Include(x => x.Locatie)
                .Include(x => x.TanarActivitate);
            return tineriJoin;
        }

        public async Task Create(Tanar tineri)
        {
            await db.Tineri.AddAsync(tineri);

            await db.SaveChangesAsync();
        }

        public async Task Update(Tanar tineri)
        {
            db.Tineri.Update(tineri);

            await db.SaveChangesAsync();
        }

        public void Delete(Tanar tineri)
        {
            db.Tineri.Remove(tineri);

           db.SaveChangesAsync();
        }

    }
}
