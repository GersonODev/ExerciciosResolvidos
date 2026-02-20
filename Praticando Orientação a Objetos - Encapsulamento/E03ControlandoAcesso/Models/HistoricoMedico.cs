namespace E03ControlandoAcesso.Models;

internal class HistoricoMedico
{
    private List<Consulta> _consultas = [];

    public void AdicionarConsulta(Consulta consulta) 
        => _consultas.Add(consulta);

    public void ExibirHistorico(string? filtro = null)
    {
        Console.WriteLine("--- Histórico médico ---");
        if (_consultas.Count == 0)
        {
            Console.WriteLine("Ainda não há consultas no histórico");
            return;
        }

        int numeroDeConsultas = 0;

        foreach (var consulta in _consultas)
        {
            if (string.IsNullOrWhiteSpace(filtro)
            || consulta.Medico.Nome.Contains(filtro, StringComparison.OrdinalIgnoreCase)
            || consulta.Medico.TipoMedico.Contains(filtro, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(consulta);
                numeroDeConsultas++;
                Console.WriteLine("---");
            }
        }

        Console.WriteLine($"\nConsultas encontradas: {numeroDeConsultas}");
    }
}
