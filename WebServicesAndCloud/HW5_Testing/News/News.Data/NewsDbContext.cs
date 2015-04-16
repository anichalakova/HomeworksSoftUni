namespace News.Data
{
    using News.Data.Migrations;
    using System.Data.Entity;

    public class NewsDbContext : DbContext
    {
        public NewsDbContext()
            : base("News")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<NewsDbContext, Configuration>());
        }

        public virtual IDbSet<NewsItem> News { get; set; }
    }
}
