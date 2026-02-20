using E03ControlandoAcesso.Enums;
using E03ControlandoAcesso.Models;

List<string> observacoes =
[
    "O paciente apresenta quadro estável, mantendo a adesão ao tratamento medicamentoso prescrito na última consulta. Foram revisados os níveis glicêmicos e a pressão arterial, que se encontram dentro da normalidade. Recomenda-se a continuidade da dieta hipossódica e a prática regular de exercícios físicos leves, com retorno previsto para três meses para novos exames laboratoriais de rotina.",

    "Paciente relata início de sintomas gripais há aproximadamente quatro dias, incluindo febre persistente, mialgia intensa e tosse seca. Ao exame físico, nota-se congestão nasal e orofaringe levemente hiperemiada. Foi solicitada a realização de teste rápido para detecção de vírus respiratórios e prescrito tratamento sintomático. O paciente deve permanecer em repouso e manter hidratação rigorosa até a melhora do quadro.",

    "Realizada a retirada de pontos conforme o cronograma cirúrgico previsto. A ferida operatória apresenta excelente aspecto cicatricial, sem sinais de flogose, secreções purulentas ou deiscência. O paciente foi orientado sobre a importância de manter a proteção solar na região afetada para evitar hipercromia. Está liberado para retornar às atividades laborais gradualmente, evitando esforços físicos pesados por mais quinze dias.",

    "Consulta de rotina realizada sem queixas clínicas específicas por parte do paciente. Foram solicitados exames de rastreio preventivo, incluindo hemograma completo, perfil lipídico e avaliação da função renal e hepática. Orientações sobre vacinação atualizada foram fornecidas, reforçando a necessidade da dose de reforço anual. O paciente demonstra bom entendimento sobre hábitos de vida saudáveis e medidas preventivas primárias.        Consulta de rotina realizada sem queixas clínicas específicas por parte do paciente. Foram solicitados exames de rastreio preventivo, incluindo hemograma completo, perfil lipídico e avaliação da função renal e hepática. Orientações sobre vacinação atualizada foram fornecidas, reforçando a necessidade da dose de reforço anual. O paciente demonstra bom entendimento sobre hábitos de vida saudáveis e medidas preventivas primárias."
];

var medico1 = new Medico("12345-SP", "Dr. Marcos Pimenta", AreaMedica.Infectologia);
var medico2 = new Medico("67890-SP", "Dra. Ana Braga", AreaMedica.Pediatria);

var paciente = new Paciente("Renato Borba", 45);

var c1 = new Consulta("PRONT-001", new DateTime(2024, 05, 10), medico1, observacoes[0]);
var c2 = new Consulta("PRONT-002", new DateTime(2024, 06, 15), medico1, observacoes[1]);
var c3 = new Consulta("PRONT-003", new DateTime(2025, 08, 20), medico1, observacoes[2]);
var c4 = new Consulta("PRONT-004", new DateTime(2025, 09, 05), medico2, observacoes[3]);

paciente.HistoricoMedico.AdicionarConsulta(c1);
paciente.HistoricoMedico.AdicionarConsulta(c2);
paciente.HistoricoMedico.AdicionarConsulta(c3);
paciente.HistoricoMedico.AdicionarConsulta(c4);

static void MostrarNomePaciente(Paciente paciente)
{
    Console.Clear();
    Console.WriteLine($"PACIENTE: {paciente.Nome}");
    Console.WriteLine("--------------------------------------");
}

while (true)
{
    MostrarNomePaciente(paciente);
    Console.WriteLine("Filtre as consultas por nome, tipo do médico ou apenas precione enter para ver o histórico completo.");
    Console.WriteLine("OBS: Médicos[Marcos/Ana/Pimenta/Braga] Tipos[Pediatra/Infectologista]");
    Console.Write("Filtrar por: ");
    var filtro = Console.ReadLine();

    MostrarNomePaciente(paciente);
    paciente.HistoricoMedico.ExibirHistorico(filtro);

    Console.WriteLine("Precione ESC para sair, ou qualquer outra tecla para continuar..");
    if (Console.ReadKey().Key == ConsoleKey.Escape) break;
}

Console.Clear();
Console.WriteLine("Aplicação finalizada...");