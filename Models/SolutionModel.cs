using System.ComponentModel.DataAnnotations;

namespace project_renault.Models
{
    public class SolutionModel
    {
        [Key]
        public int Id_Solution { get; set; }
        public string? Estrategia { get; set; }
        public string? Probabilidade_Residual { get; set; }
        public string? Impacto_Residual { get; set; }
        public string? Validacao_Acao { get; set; }
        public string? Validacao_Risco { get; set; }
        public string? Id_Piloto { get; set; }
        public string? Nome_Piloto { get; set; }
        public string? Capitalizacao { get; set; }
        public DateTime Inicio_Plano_De_Acao { get; set; }
        public string? Acao { get; set; }
        public string? Comentario { get; set; }
        public DateTime Data_Resolucao { get; set; }
        public DateTime DataAlerta { get; set; }
        public int id_risk {  get; set; }
    }
}