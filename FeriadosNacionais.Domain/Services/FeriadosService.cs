using AutoMapper;
using FeriadosNacionais.Domain.Models;
using FeriadosNacionais.Infra.Entities;
using FeriadosNacionais.Infra.ExternalServices;
using FeriadosNacionais.Infra.Repository;

namespace FeriadosNacionais.Domain.Services
{
    public class FeriadosService : IFeriadosService
    {
        private readonly IFeriadosExternalService _feriadosExternalService;
        private readonly IFeriadosDatasRepository _feriadosDatasRepository;
        private readonly IMapper _mapper;

        public FeriadosService(IFeriadosExternalService feriadosExternalService, IFeriadosDatasRepository feriadosDatasRepository, IMapper mapper)
        {
            _feriadosExternalService = feriadosExternalService;
            _feriadosDatasRepository = feriadosDatasRepository;
            _mapper = mapper;
        }

        public async Task CarregarDadosFeriados()
        {
            var feriadosSalvos = await _feriadosDatasRepository.ObterTodosFereiados();

            if (feriadosSalvos.Any())
                return;

            var feriadosList = await _feriadosExternalService.ConsultaFeriadosNacionais();

            if (feriadosList.Any())
            {
                foreach (var item in feriadosList)
                {
                    await _feriadosDatasRepository.Incluir(item);
                }
            }
        }

        public async Task IncluirFeriado(FeriadosDatasModel feriadosDatasModel)
        {
            var feriadoEntity = _mapper.Map<FeriadosDatasEntity>(feriadosDatasModel);

            await _feriadosDatasRepository.Incluir(feriadoEntity);
        }

        public async Task AtualizarFeriado(FeriadosDatasModel feriadosDatasModel)
        {
            var feriadoEntity = _mapper.Map<FeriadosDatasEntity>(feriadosDatasModel);

            await _feriadosDatasRepository.Atualizar(feriadoEntity);
        }        

        public async Task DeletarFeriado(FeriadosDatasModel feriadosDatasModel)
        {
            var feriadoEntity = _mapper.Map<FeriadosDatasEntity>(feriadosDatasModel);

            await _feriadosDatasRepository.Deletar(feriadoEntity);
        }

        public Task<FeriadosDatasModel> ObterFeriadoPorId()
        {
            throw new NotImplementedException();
        }

        public async Task<List<FeriadosDatasModel>> ObterFeriadosTodos()
        {
            var feriadosModelList = new List<FeriadosDatasModel>();
            var feriadosEntityList = await _feriadosDatasRepository.ObterTodosFereiados();

            if (feriadosEntityList.Any())
            {
                foreach(var item in feriadosEntityList)
                {
                    feriadosModelList.Add(_mapper.Map<FeriadosDatasModel>(item));
                }
            }

            return feriadosModelList;          
        }
    }
}
