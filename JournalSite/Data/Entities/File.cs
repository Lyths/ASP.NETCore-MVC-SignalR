namespace JournalSite.Data.Entities
{
    public class File
    {
        public Guid Id { get; set; } 

        public string FilePath { get; set; }

        public Guid ArticleId { get; set; }

        public Article Article { get; set; }
    }
}
