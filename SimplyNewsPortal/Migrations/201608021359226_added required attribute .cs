namespace SimplyNewsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedrequiredattribute : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BlogPosts", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.BlogPosts", "Tags", c => c.String(nullable: false));
            AlterColumn("dbo.BlogPosts", "Content", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BlogPosts", "Content", c => c.String());
            AlterColumn("dbo.BlogPosts", "Tags", c => c.String());
            AlterColumn("dbo.BlogPosts", "Title", c => c.String());
        }
    }
}
