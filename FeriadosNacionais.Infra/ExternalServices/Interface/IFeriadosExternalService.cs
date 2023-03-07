using FeriadosNacionais.Infra.Entities;

namespace FeriadosNacionais.Infra.ExternalServices
{
    public interface IFeriadosExternalService
    {
        Task<List<FeriadosDatasEntity>> ConsultaFeriadosNacionais();
    }
}
