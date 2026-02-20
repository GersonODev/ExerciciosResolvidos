namespace E03ControlandoAcesso.Models;

public class Paciente(string nome, int idade)
{
    internal HistoricoMedico HistoricoMedico { get; } = new();
    public string Nome { get; } = nome;
    public int Idade { get; } = idade;
}