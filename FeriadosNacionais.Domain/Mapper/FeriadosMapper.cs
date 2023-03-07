using AutoMapper;
using FeriadosNacionais.Domain.Models;
using FeriadosNacionais.Infra.Entities;

namespace FeriadosNacionais.Domain.Mapper
{
    public class FeriadosMapper : Profile
    {
        public FeriadosMapper()
        {
            CreateMap<FeriadosDatasModel, FeriadosDatasEntity>();
            CreateMap<FeriadosDatasEntity, FeriadosDatasModel>();
        }
    }
}
