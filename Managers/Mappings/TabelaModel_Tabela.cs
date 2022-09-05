using AutoMapper;
using test2.Entities;
using test2.Models;

namespace test2.Managers.Mappings
{
    public class TabelaModel_Tabela : Profile
    {
        public TabelaModel_Tabela()
        {
            CreateMap<TabelaModel, Tabela>()
                .ForMember(tm => tm.IdTanar, t => t.MapFrom(t => t.TanarId))
                .ForMember(tm => tm.IdActivitate, t => t.MapFrom(t => t.ActivitateId))
                .ForMember(tm => tm.An, t => t.MapFrom(t => t.An));
        }
    }
}
