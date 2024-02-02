using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProcessoSeletivo.Model
{
    [Table("Perguntas")] // Define o nome da tabela no banco de dados
    public class Pergunta
    {
        [Key] // Define a chave primária da tabela
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PerguntaId { get; set; }

        [Required] // Indica que a propriedade é obrigatória
        public string Descricao { get; set; }
    }
}
