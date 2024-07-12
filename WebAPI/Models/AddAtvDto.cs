namespace WebAPI.Models
{
    public class AddAtvDto
    {
        public required string Tarefa { get; set; }
        public required string ParaNome { get; set; }
        public required DateTime Data { get; set; }
    }
}
