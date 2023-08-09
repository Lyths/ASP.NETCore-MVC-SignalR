namespace JournalSite.Data.Entities
{
    public class Archive_year
    {
        public Archive_year()
        {
            Numbers = new List<Archive_number>();
        }

        public Guid Id { get; set; }

        public int Year { get; set; }

        public virtual ICollection<Archive_number> Numbers { get; set; }
    }
}
