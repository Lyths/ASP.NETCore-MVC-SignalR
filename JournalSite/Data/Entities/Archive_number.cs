using System.ComponentModel.DataAnnotations.Schema;

namespace JournalSite.Data.Entities
{
    public class Archive_number
    {
        public Archive_number()
        {
            Articles = new List<Archive_articles>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid YearId { get; set; }

        public virtual Archive_year Year { get; set; }

        public virtual ICollection<Archive_articles> Articles { get; set; }
    }
}
