using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhasV1.Validador;

namespace JornadaMilhasV1.Modelos;

public class Periodo: Valida
{
    private DateTime? data;

    public DateTime DataInicial { get; set; }
    public DateTime DataFinal { get; set; }

    public Periodo(DateTime? dataInicial, DateTime? dataFinal)
    {
        // Se alguma das datas for null, será inicializada com o  valor padrão de DateTime (01/01/0001 00:00:00)
        DataInicial = dataInicial ?? default;
        DataFinal = dataFinal ?? default;
        Validar();
    }

    public Periodo(DateTime? dt)
    {
        data = dt;
    }

    protected override void Validar()
    {
        if (DataInicial > DataFinal)
        {
            Erros.RegistrarErro("Erro: Data de ida não pode ser maior que a data de volta.");
        }

        if (DataInicial == default || DataFinal == default)
        {
            Erros.RegistrarErro("Erro: Período de viagem inválido.");
        }
    }
}
