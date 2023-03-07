using FeriadosNacionais.Infra.Data;
using FeriadosNacionais.Infra.Entities;
using Microsoft.EntityFrameworkCore;

namespace FeriadosNacionais.Infra.Repository
{
    public class FeriadosDatasRepository : IFeriadosDatasRepository
    {
        private readonly FeriadosDbContext _feriadosDbContext;

        public FeriadosDatasRepository(FeriadosDbContext feriadosDbContext)
        {
            _feriadosDbContext = feriadosDbContext;
        }

        public async Task Atualizar(FeriadosDatasEntity feriadosDatasEntity)
        {
            _feriadosDbContext.FeriadosDatas.Update(feriadosDatasEntity);
            await _feriadosDbContext.SaveChangesAsync();
        }

        public async Task Deletar(FeriadosDatasEntity feriadosDatasEntity)
        {
            _feriadosDbContext.FeriadosDatas.Remove(feriadosDatasEntity);
            await _feriadosDbContext.SaveChangesAsync();
        }

        public async Task Incluir(FeriadosDatasEntity feriadosDatasEntity)
        {
            await _feriadosDbContext.FeriadosDatas.AddAsync(feriadosDatasEntity);
            await _feriadosDbContext.SaveChangesAsync();
        }

        public async Task<FeriadosDatasEntity> ObterFeriadoPorId(int id)
        {
            return await _feriadosDbContext.FeriadosDatas.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<List<FeriadosDatasEntity>> ObterTodosFereiados()
        {
            return await _feriadosDbContext.FeriadosDatas.ToListAsync();
        }
    }
}
