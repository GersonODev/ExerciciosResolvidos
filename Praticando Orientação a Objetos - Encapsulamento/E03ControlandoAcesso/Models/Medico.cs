using E03ControlandoAcesso.Enums;

namespace E03ControlandoAcesso.Models;

public class Medico
{
    public Medico(string crm, string nome, AreaMedica areaMedica)
    {
        CRM = crm;
        Nome = nome;
        ObterTipoMedico(areaMedica);
    }
    public string CRM { get; }
    public string Nome { get; }
    public string TipoMedico { get; private set; } = string.Empty;

    private void ObterTipoMedico(AreaMedica areaMedica)
    {
        TipoMedico = areaMedica switch
        {
            AreaMedica.Cardiologia => "Cardiologista",
            AreaMedica.Dermatologia => "Dermatologista",
            AreaMedica.Ginecologia => "Ginecologista",
            AreaMedica.Infectologia => "Infectologista",
            AreaMedica.Neurologia => "Neurologista",
            AreaMedica.Oftalmologia => "Oftalmologista",
            AreaMedica.Ortopedia => "Ortopedista",
            AreaMedica.Pediatria => "Pediatra",
            AreaMedica.Psiquiatria => "Psiquiatra",
            AreaMedica.Urologia => "Urologista",
            _ => "Médico"
        };
    }
}
