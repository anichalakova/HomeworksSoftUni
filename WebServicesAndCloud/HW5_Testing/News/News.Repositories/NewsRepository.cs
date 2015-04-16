using System.Linq;

using System.Data.Entity;
using News.Data;

namespace News.Repositories
{
    public class NewsRepository : IRepository<NewsItem>
    {
        private readonly DbContext dbContext;

        public NewsRepository(DbContext context)
        {
            this.dbContext = context;
        }

        public NewsItem Add(NewsItem entity)
        {
            this.dbContext.Set<NewsItem>().Add(entity);
            return entity;
        }

        public NewsItem Find(int id)
        {
            return this.dbContext.Set<NewsItem>().Find(id);
        }

        public IQueryable<NewsItem> All()
        {
            return this.dbContext.Set<NewsItem>();
        }

        public void Delete(NewsItem entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
        }

        public void Update(NewsItem entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }

        private void ChangeState(NewsItem news, EntityState state)
        {
            var entry = this.dbContext.Entry(news);
            if (entry.State == EntityState.Detached)
            {
                this.dbContext.Set<NewsItem>().Attach(news);
            }

            entry.State = state;
        }
    }
}
