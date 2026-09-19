using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels;

public class CreateTodoViewModel {
    [Required(ErrorMessage = "O título é obrigatório")]
    [StringLength(100, ErrorMessage = "O título não pode ter mais de 100 caracteres")]
    [Display(Name = "Título da Tarefa")]
    public string Title { get; set; } = string.Empty;

    [Display(Name = "Descrição")]
    public string? Description { get; set; }

    [Display(Name = "Status da Tarefa")]
    public string? Status { get; set; }

    [Display(Name = "Prioridade da Tarefa")]
    public string? Priority { get; set; }

    [Display(Name = "Data de Vencimento")]
    [DataType(DataType.Date)]
    public DateTime? DeadLineAt { get; set; }

    [Display(Name = "Data da Finalização")]
    public DateTime? CompletedAt { get; set; }

}