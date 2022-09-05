using AutoMapper;
using test2.Entities;
using test2.Models;

namespace test2.Managers.Models
{
    public class Tanar_TanarModel : Profile
    {
        public Tanar_TanarModel()
        {
            CreateMap<Tanar, TanarModel>()
                .ForMember(tm => tm.Nume, t => t.MapFrom(t => t.Nume))
                .ForMember(tm => tm.Prenume, t => t.MapFrom(t => t.Prenume))
                .ForMember(tm => tm.ZiDeNastere, t => t.MapFrom(t => t.DateOfBirth));
        }
    }
}
