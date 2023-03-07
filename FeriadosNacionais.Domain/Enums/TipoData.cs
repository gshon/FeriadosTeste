
using System.ComponentModel;

namespace FeriadosNacionais.Domain.Enums
{
    public enum TipoData
    {
        [Description("Dia da Semana")]
        DiaSemana = 1,

        [Description("Fim de Semana")]
        FimSemana = 2,

        [Description("Feriado")]
        Feriado = 3
    }
}
