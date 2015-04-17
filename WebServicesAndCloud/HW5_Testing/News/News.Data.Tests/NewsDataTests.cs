namespace News.Data.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using News.Data;
    using System.Data.Entity.Validation;

    [TestClass]
    public class NewsDataTests
    {
        [TestMethod]
        public void AddNews_IfNewsIsValid_ShouldAddToDb()
        {
            // Arrange -> prepare the objects
            var news = new News.Data.NewsItem()
            {
                Title = "Test News 1",
                PublishDate = DateTime.Now,
                Content = "Test news 1 content"
            };

            var dbContext = new NewsDbContext();

            // Act -> perform some logic
            dbContext.News.Add(news);
            dbContext.SaveChanges();

            // Assert -> validate the results
            var newsInDb = dbContext.News.Find(news.Id);

            Assert.IsNotNull(newsInDb);
            Assert.AreEqual(news.Title, newsInDb.Title);
            Assert.AreEqual(news.Content, newsInDb.Content);
            Assert.AreEqual(news.PublishDate, newsInDb.PublishDate);
            Assert.IsTrue(newsInDb.Id != 0);
        }

    }
}
