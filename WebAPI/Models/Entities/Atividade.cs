namespace WebAPI.Models.Entities
{
    public class Atividade
    {
        public Guid Id { get; set; }
        public required string  Tarefa { get; set; }
        public required string ParaNome { get; set; }
        public required DateTime Data {  get; set; }
    }
}