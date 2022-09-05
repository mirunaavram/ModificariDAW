using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2.Entities;
using test2.Models;
using test2.Repositories;

namespace test2.Managers
{
    public class TabelaManager: ITabelaManager
    {
        private readonly ITabelaRepository tabelaRepository;
        protected readonly IMapper Mapper;

        public TabelaManager(ITabelaRepository tabelaRepository)
        {
            this.tabelaRepository = tabelaRepository;
        }

        public async Task Create(TabelaModel tabelaModel)
        {

            var tabela = Mapper.Map<TabelaModel, Tabela>(tabelaModel);
            await tabelaRepository.Create(tabela);
        }



        public List<Tabela> GetTabela()
        {
            return tabelaRepository.GetTabela().ToList();
        }

        /*
        public Activitate GetActivitateById(string id)
        {
            var activitate = activitateRepository.GetActivitate()
                .FirstOrDefault(x => x.Id == id);

            return activitate;
        }
        */

        public List<TabelaModel> GetTabelaFiltered()
        {
            //var tabela = tabelaRepository.GetActivitateWithJoin();
            var tabelaFiltered = tabelaRepository.GetTabela()
                //.Where(x => x.IdTanar == "1")
                .Select(x => new TabelaModel { An = x.An })
                .ToList();
            return tabelaFiltered;

        }

        /*
        public List<TabelaModel> GetActivitateOrdered()
        {
            var tabelaOrdered = activitateRepository.GetActivitate()
                .OrderByDescending(X => X.Nume)
                .Select(x => new ActivitateModel { Nume = x.Nume, Categorie = x.Categorie, NrParticipanti = x.NrParticipanti })
                .ToList();
            return activitateOrdered;
        }
        */
        /*
        public List<string> GetActivitateIds()
        {
            return activitateRepository.GetActivitateIds().ToList();
        }

        public List<Activitate> GetActivitateWithJoin()
        {
            return activitateRepository.GetActivitateWithJoin().ToList();
        }
        */


        public async Task Update(TabelaModel tabelaModel)
        {
            var tabela = tabelaRepository.GetTabela()
                .FirstOrDefault(x => x.IdTanar == tabelaModel.TanarId);
                
                //.FirstOrDefault(x => x.An == tabelaModel.An);
            tabela.An = tabelaModel.An;

            await tabelaRepository.Update(tabela);
        }


        public void Delete(Guid id)
        {
            var tabela = tabelaRepository.GetTabela()
                .FirstOrDefault(x => x.IdTanar == id);

            tabelaRepository.Delete(tabela);
        }

        
    }
}
