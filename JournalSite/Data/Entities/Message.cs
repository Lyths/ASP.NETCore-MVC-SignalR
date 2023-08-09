namespace JournalSite.Data.Entities
{
    public class Message
    {
        public Guid Id { get; set; }

        public string Sender { get; set; }

        public string Text { get; set; }

        public string GroupName { get; set; }

        public DateTime Time { get; set; } = DateTime.UtcNow;
    }
}
