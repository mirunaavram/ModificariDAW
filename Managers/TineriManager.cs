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
    public class TineriManager : ITineriManager
    {
        protected readonly IMapper Mapper;

        private readonly ITineriRepository tineriRepository;
        public TineriManager(ITineriRepository repository)
        {
            this.tineriRepository = repository;
        }

        public async Task Create(Tanar tineri)
        {
            //tineri.Name= "Ion"; -> e un buss logic
            await tineriRepository.Create(tineri);
        }


        public List<TanarModel> GetTineri()
        {
            var tineri = tineriRepository.GetTineri().ToList();

            var tineriModelsList = new List<TanarModel>();

            foreach (var tanar in tineri)
            {
                var tanarModel = Mapper.Map<Tanar, TanarModel>(tanar);
                tineriModelsList.Add(tanarModel);
            }

            return tineriModelsList;
        }

        public Tanar GetTineriById(Guid id)
        {
            var tineri = tineriRepository.GetTineri()
                .FirstOrDefault(x => x.Id == id);

            return tineri;
        }

        public List<TanarLocatieNumeModel> GetTineriFiltered()
        {
            var tineri = tineriRepository.GetTineriWithJoin();
            var tineriFiltered = tineri
                .Where(x => x.Locatie.Oras == "Bucharest")
                .Select(x => new TanarLocatieNumeModel { Id = x.Id, Nume = x.Nume })
                .ToList();
            return tineriFiltered;


        }

        public List<TanarLocatieNumeModel> GetTineriFilteredOrdered()
        {
            var tineriFiltered = GetTineriFiltered();
            var tineriOrdered = tineriFiltered.OrderByDescending(X => X.Nume)
                .ToList();
            return tineriOrdered;
        }

        public List<Guid> GetTineriIds()
        {
            return tineriRepository.GetTineriIds().ToList();
        }

        public List<Tanar> GetTineriWithJoin()
        {
            return tineriRepository.GetTineriWithJoin().ToList();
        }

        public async Task Update(EditTanarModel editTanarModel)
        {
            var tineri = tineriRepository.GetTineri()
                .FirstOrDefault(x => x.Id == editTanarModel.Id);
            tineri.Prenume = editTanarModel.Prenume;

            await tineriRepository.Update(tineri);
        }


        public void Delete(Guid id)
        {
            var tineri = GetTineriById(id);
            tineriRepository.Delete(tineri);
        }
    }
}
