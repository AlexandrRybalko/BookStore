// <auto-generated />
namespace BookStore.DAL.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.1.2-31219")]
    public sealed partial class Changed_Connection_Between_Book_And_Genre : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(Changed_Connection_Between_Book_And_Genre));
        
        string IMigrationMetadata.Id
        {
            get { return "202101281830125_Changed_Connection_Between_Book_And_Genre"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}