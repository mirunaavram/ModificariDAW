using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2.Entities;

namespace test2.Repositories
{
    public interface ITabelaRepository
    {

        IQueryable<Tabela> GetTabela();
       // IQueryable<string> GetActivitateIds();
       // IQueryable<Activitate> GetActivitateWithJoin();

        Task Create(Tabela tabela);
        Task Update(Tabela tabela);
        void Delete(Tabela tabela);
    }
}
