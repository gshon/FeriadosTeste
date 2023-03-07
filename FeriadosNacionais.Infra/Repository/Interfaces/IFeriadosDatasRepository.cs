using FeriadosNacionais.Infra.Entities;

namespace FeriadosNacionais.Infra.Repository
{
    public interface IFeriadosDatasRepository
    {
        Task<List<FeriadosDatasEntity>> ObterTodosFereiados();
        Task<FeriadosDatasEntity> ObterFeriadoPorId(int id);
        Task Incluir(FeriadosDatasEntity feriadosDatasModel);
        Task Atualizar(FeriadosDatasEntity feriadosDatasModel);
        Task Deletar(FeriadosDatasEntity feriadosDatasModel);
    }
}
