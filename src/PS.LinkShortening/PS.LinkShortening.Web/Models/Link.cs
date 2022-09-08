namespace PS.LinkShortening.Web.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string LongURL { get; set; } = null!;
        public string ShortURL { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public int CountTransitions { get; set; }
    }
}
