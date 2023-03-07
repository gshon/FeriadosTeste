using FeriadosNacionais.Infra.Entities;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace FeriadosNacionais.Infra.ExternalServices
{
    public class FeriadosExternalService : IFeriadosExternalService
    {
        public FeriadosExternalService()
        {
            
        }

        public async Task<List<FeriadosDatasEntity>> ConsultaFeriadosNacionais()
        {
            try
            {
                using var client = new HttpClient();

                client.BaseAddress = new Uri("http://dadosbr.github.io/feriados/nacionais.json");

                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);

                if (response.IsSuccessStatusCode)
                {
                    var dataObjects = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<FeriadosDatasEntity>>(dataObjects);

                    if (result != null)
                        return result;
                    else
                        throw new Exception("Erro ao obter os dados");
                }
                else
                {
                    throw new Exception("Não foi possível obter os dados");
                }
            }
            catch (Exception ex)
            {

                throw;
            }            
        }
    }
}
