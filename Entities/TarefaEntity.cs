using System.ComponentModel.DataAnnotations;

namespace ApiToDo.Entities
{
    public class TarefaEntity
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o título da tarefa")]
        public string Title { get; set; }
        public string? Description { get; set; } = null;
        public bool Done { get; set; } = false;
        public DateTime Data { get; set; } = DateTime.Now;
    }
}
