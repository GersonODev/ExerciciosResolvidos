using System.Text;

namespace E03ControlandoAcesso.Models;

public class Consulta(
    string codigoProntuario,
    DateTime dataConsulta,
    Medico medico,
    string observacoes)
{
    private readonly string _codigoProntuario = codigoProntuario;
    private readonly DateTime _dataConsulta = dataConsulta;
    private readonly string _observacoes = observacoes;
    public Medico Medico { get; } = medico;

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine($"\n{"Prontuário: " + _codigoProntuario,-50} Data da consulta: {_dataConsulta:dd/MM/yyyy}");
        sb.AppendLine($"{"Médico: " + Medico.Nome,-50} CRM: {Medico.CRM}");
        sb.AppendLine($"Observações:");
        if (_observacoes.Length == 0)
        {
            return "Nenhuma informação encontrada..";
        }
        else
        {
            ExibirObservacoesFormatadas(sb);
        }

        return sb.ToString();
    }

    private void ExibirObservacoesFormatadas(StringBuilder sb)
    {
        const int comprimentoMax = 75; // Reduzido levemente para evitar conflito com o console

        // 1. Remove qualquer quebra de linha ou espaço duplo que veio do banco/input
        string textoNormalizado = System.Text.RegularExpressions.Regex.Replace(_observacoes, @"\s+", " ").Trim();
        var palavras = textoNormalizado.Split(' ');

        int acumuladoNaLinha = 0;

        foreach (var palavra in palavras)
        {
            // Verifica se a palavra + 1 espaço cabe na linha atual
            if (acumuladoNaLinha + palavra.Length > comprimentoMax)
            {
                sb.AppendLine();
                acumuladoNaLinha = 0;
            }

            sb.Append(palavra).Append(' ');
            acumuladoNaLinha += palavra.Length + 1;
        }
    }
}

