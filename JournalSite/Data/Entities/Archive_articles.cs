namespace JournalSite.Data.Entities
{
    public class Archive_articles
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Sender { get; set; }

        public string Path { get; set; }

        public Guid NumberId { get; set; }

        public DateTime Created { get; set; } = DateTime.UtcNow;

        public virtual Archive_number Number { get; set; }
    }
}
