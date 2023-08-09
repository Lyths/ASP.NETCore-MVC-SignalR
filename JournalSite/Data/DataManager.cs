using JournalSite.Data.Interfaces.Abstract;

namespace JournalSite.Data
{
    public class DataManager
    {
        public IPostItems PostItems { get; set; }
        public IGroup Groups { get; set; }
        public IMessage Messages { get; set; }
        public IArticle Articles { get; set; }
        public IFile Files { get; set; }
        public IArchive_year ArchiveYears { get; set; }
        public IArchive_number ArchiveNumbers { get; set; }
        public IArchive_articles ArchiveArticles { get; set; }

        public DataManager(IPostItems postItems, IGroup groups, IMessage messages, IArticle articles, IFile files, IArchive_year archiveYears, IArchive_number archiveNumbers, IArchive_articles archiveArticles)
        {
            PostItems = postItems;
            Groups = groups;
            Messages = messages;
            Articles = articles;
            Files = files;
            ArchiveYears = archiveYears;
            ArchiveNumbers = archiveNumbers;
            ArchiveArticles = archiveArticles;

        }
    }
}
