
using FeriadosNacionais.Domain.Models;

namespace FeriadosNacionais.Domain.Services
{
    public interface IFeriadosService
    {
        Task CarregarDadosFeriados();

        Task<List<FeriadosDatasModel>> ObterFeriadosTodos();

        Task<FeriadosDatasModel> ObterFeriadoPorId();

        Task IncluirFeriado(FeriadosDatasModel feriadosDatasModel);

        Task AtualizarFeriado(FeriadosDatasModel feriadosDatasModel);

        Task DeletarFeriado(FeriadosDatasModel feriadosDatasModel);
    }
}
