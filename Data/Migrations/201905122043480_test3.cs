namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Formations", "CodeFormateur", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Formations", "CodeFormateur");
        }
    }
}
