namespace BookStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Description_And_FilePath_To_Book : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "FilePath", c => c.String());
            AddColumn("dbo.Books", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Description");
            DropColumn("dbo.Books", "FilePath");
        }
    }
}
