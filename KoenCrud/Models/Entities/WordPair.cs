namespace KoenCrud.Models.Entities
{
    public class WordPair
    {
        public Guid Id { get; set; }
        public required string Korean { get; set; }
        public required string English { get; set; }
    }
}
