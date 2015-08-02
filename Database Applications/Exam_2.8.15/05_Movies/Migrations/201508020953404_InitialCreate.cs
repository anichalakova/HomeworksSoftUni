namespace _05_Movies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Isbn = c.String(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        AgeRestriction = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Email = c.String(),
                        Age = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Stars = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.MovieUsers",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.MovieId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "UserId", "dbo.Users");
            DropForeignKey("dbo.Ratings", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.MovieUsers", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.MovieUsers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "CountryId", "dbo.Countries");
            DropIndex("dbo.MovieUsers", new[] { "MovieId" });
            DropIndex("dbo.MovieUsers", new[] { "UserId" });
            DropIndex("dbo.Ratings", new[] { "MovieId" });
            DropIndex("dbo.Ratings", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "CountryId" });
            DropTable("dbo.MovieUsers");
            DropTable("dbo.Ratings");
            DropTable("dbo.Users");
            DropTable("dbo.Movies");
            DropTable("dbo.Countries");
        }
    }
}
