using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2.Entities;
using test2.Models;

namespace test2.Managers
{
    public interface ITabelaManager
    {
        List<Tabela> GetTabela();
        //List<string> GetActivitateIds();
        //List<Activitate> GetActivitateWithJoin();
        List<TabelaModel> GetTabelaFiltered();

        //List<TabelaModel> GetTabelaOrdered();

        //Activitate GetActivitateById(string id);
        Task Create(TabelaModel tabelaModel);
        Task Update(TabelaModel tabela);
        void Delete(Guid id);
    }
}
