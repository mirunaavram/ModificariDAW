using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2.Entities;

namespace test2.Repositories
{
    public interface ITineriRepository //aici spunem ce poate sa faca
    {

        IQueryable<Tanar> GetTineri();
        IQueryable<Guid> GetTineriIds();
        IQueryable<Tanar> GetTineriWithJoin();

        Task Create(Tanar tineri);
        Task Update(Tanar tineri);

        void Delete(Tanar tineri);
        //ITineriRepository ca un fel de lista de servicii/ functionalitati pe care le oferim unui serviciu
    }
}
