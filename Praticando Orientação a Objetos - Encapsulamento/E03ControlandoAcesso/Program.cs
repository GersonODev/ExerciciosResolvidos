using E03ControlandoAcesso.Enums;
using E03ControlandoAcesso.Models;

List<string> observacoes =
[
    "Febre Prolongada: Paciente apresenta febre persistente (38,5°C) há 10 dias. Solicitei hemoculturas e sorologias para investigar arboviroses e endocardite.",

    "Adesão ao Tratamento: Paciente em retorno de HIV. Estável, carga viral indetectável. Reforcei a importância da adesão rigorosa à terapia antirretroviral.",

    "Infecção de Pele: Celulite em membro inferior sem melhora com cefalexina. Alterei esquema para cobertura de MRSA e agendei retorno em 48 horas",

    "Desenvolvimento: Lactente de 6 meses em consulta de rotina. Peso e estatura adequados (P50). Iniciando introdução alimentar. Vacinação atualizada"
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