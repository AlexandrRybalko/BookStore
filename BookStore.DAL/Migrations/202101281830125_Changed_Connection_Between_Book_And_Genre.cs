namespace BookStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changed_Connection_Between_Book_And_Genre : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "GenreId", "dbo.Genres");
            DropIndex("dbo.Books", new[] { "GenreId" });
            CreateTable(
                "dbo.BookGenres",
                c => new
                    {
                        Book_Id = c.Int(nullable: false),
                        Genre_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Book_Id, t.Genre_Id })
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.Genre_Id, cascadeDelete: true)
                .Index(t => t.Book_Id)
                .Index(t => t.Genre_Id);
            
            DropColumn("dbo.Books", "GenreId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "GenreId", c => c.Int(nullable: false));
            DropForeignKey("dbo.BookGenres", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.BookGenres", "Book_Id", "dbo.Books");
            DropIndex("dbo.BookGenres", new[] { "Genre_Id" });
            DropIndex("dbo.BookGenres", new[] { "Book_Id" });
            DropTable("dbo.BookGenres");
            CreateIndex("dbo.Books", "GenreId");
            AddForeignKey("dbo.Books", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
    }
}
