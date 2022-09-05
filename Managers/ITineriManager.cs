using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2.Entities;
using test2.Models;

namespace test2.Managers
{
    public interface ITineriManager
    {
        List<TanarModel> GetTineri();
        List<Guid> GetTineriIds();
        List<Tanar> GetTineriWithJoin();
        List<TanarLocatieNumeModel> GetTineriFiltered();
        List<TanarLocatieNumeModel> GetTineriFilteredOrdered();

        Tanar GetTineriById(Guid Id);
        Task Create(Tanar tineri);
        Task Update(EditTanarModel model);

        void Delete(Guid Id);
    }
}
