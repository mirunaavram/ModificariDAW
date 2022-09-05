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
    public class ActivitateManager : IActivitateManager
    {
        protected readonly IMapper Mapper;

        private readonly IActivitateRepository activitateRepository;
        public ActivitateManager(IActivitateRepository activitateRepository)
        {
            this.activitateRepository = activitateRepository;
        }

        public async Task Create(Activitate activitate)
        {
            //tineri.Name= "Ion"; -> e un buss logic
            await activitateRepository.Create(activitate);
        }



        public List<Activitate> GetActivitate()
        {
            return activitateRepository.GetActivitate().ToList();
        }

        public Activitate GetActivitateById(string id)
        {
            var activitate = activitateRepository.GetActivitate()
                .FirstOrDefault(x => x.Id == id);

            return activitate;
        }

        //activitatea la care participa mai multi de 2 tineri
        public List<ActivitateModel> GetActivitateFiltered()
        {
            var activitate = activitateRepository.GetActivitateWithJoin();

            var activitateFiltered = activitate
                .Where(x => x.TanarActivitate.Count > 0)
                .Select(x => new ActivitateModel { Nume = x.Nume, Categorie = x.Categorie, NrParticipanti = x.NrParticipanti })
                .ToList();
            return activitateFiltered;


        }

        //in ordine descendenta dupa nume
        public List<ActivitateModel> GetActivitatiOrdered()
        {
            var activitateOrdered = activitateRepository.GetActivitate()
                .OrderByDescending(X => X.Nume)
                //.Select(x => new ActivitateModel { Nume = x.Nume, Categorie = x.Categorie, NrParticipanti = x.NrParticipanti })
                .ToList();
            var activitatiOrderedModel = new List<ActivitateModel>();
            foreach (var activitate in activitateOrdered)
            {
                var model = Mapper.Map<Activitate, ActivitateModel>(activitate);
                activitatiOrderedModel.Add(model);
            }
            return activitatiOrderedModel;
        }

        public List<string> GetActivitateIds()
        {
            return activitateRepository.GetActivitateIds().ToList();
        }

        public List<Activitate> GetActivitateWithJoin()
        {
            return activitateRepository.GetActivitateWithJoin().ToList();
        }

        public async Task Update(ActivitateModel activitateModel)
        {
            var activitate = activitateRepository.GetActivitate()
                .FirstOrDefault(x => x.Nume == activitateModel.Nume);
            activitate.NrParticipanti = activitateModel.NrParticipanti;

            await activitateRepository.Update(activitate);
        }


        public void Delete(string id)
        {
            var activitate = GetActivitateById(id);
            activitateRepository.Delete(activitate);
        }
    }
}
