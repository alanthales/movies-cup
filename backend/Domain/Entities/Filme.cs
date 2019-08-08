namespace Domain.Entities
{
    public class Filme : BaseEntity<string>
    {
        public string Titulo {get; set; }
        public int Ano { get; set; }
        public decimal Nota { get; set; }
    }
}