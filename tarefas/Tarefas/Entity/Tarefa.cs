namespace Tarefas.Entity;

public class Tarefa
{
    public Guid Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public bool Concluida { get; set; }
    public DateTime DataCriacao { get; set; }
}