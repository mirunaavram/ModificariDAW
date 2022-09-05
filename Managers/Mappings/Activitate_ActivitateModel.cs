using AutoMapper;
using test2.Entities;
using test2.Models;

namespace test2.Managers.Mappings
{
    public class Activitate_ActivitateModel : Profile
    {
        public Activitate_ActivitateModel()
        {
            CreateMap<Activitate, ActivitateModel>()
                .ForMember(a => a.Nume, am => am.MapFrom(am => am.Nume))
                .ForMember(a => a.Categorie, am => am.MapFrom(am => am.Categorie))
                .ForMember(a => a.NrParticipanti, am => am.MapFrom(am => am.NrParticipanti));
        }
    }
}
