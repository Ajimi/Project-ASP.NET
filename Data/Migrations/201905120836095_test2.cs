namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Participation", new[] { "Formation_IdFormation", "Formation_CodeFormateur" }, "dbo.Formations");
            DropForeignKey("dbo.Formations", "CodeFormateur", "dbo.Formateurs");
            DropIndex("dbo.Formations", new[] { "CodeFormateur" });
            DropIndex("dbo.Participation", new[] { "Formation_IdFormation", "Formation_CodeFormateur" });
            RenameColumn(table: "dbo.Formations", name: "CodeFormateur", newName: "Formateur_CodeFormateur");
            DropPrimaryKey("dbo.Formations");
            DropPrimaryKey("dbo.Participation");
            AlterColumn("dbo.Formations", "IdFormation", c => c.Short(nullable: false, identity: true));
            AlterColumn("dbo.Formations", "Formateur_CodeFormateur", c => c.Short());
            AddPrimaryKey("dbo.Formations", "IdFormation");
            AddPrimaryKey("dbo.Participation", new[] { "Candidat_IdCandidat", "Formation_IdFormation" });
            CreateIndex("dbo.Formations", "Formateur_CodeFormateur");
            CreateIndex("dbo.Participation", "Formation_IdFormation");
            AddForeignKey("dbo.Participation", "Formation_IdFormation", "dbo.Formations", "IdFormation", cascadeDelete: true);
            AddForeignKey("dbo.Formations", "Formateur_CodeFormateur", "dbo.Formateurs", "CodeFormateur");
            DropColumn("dbo.Participation", "Formation_CodeFormateur");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Participation", "Formation_CodeFormateur", c => c.Short(nullable: false));
            DropForeignKey("dbo.Formations", "Formateur_CodeFormateur", "dbo.Formateurs");
            DropForeignKey("dbo.Participation", "Formation_IdFormation", "dbo.Formations");
            DropIndex("dbo.Participation", new[] { "Formation_IdFormation" });
            DropIndex("dbo.Formations", new[] { "Formateur_CodeFormateur" });
            DropPrimaryKey("dbo.Participation");
            DropPrimaryKey("dbo.Formations");
            AlterColumn("dbo.Formations", "Formateur_CodeFormateur", c => c.Short(nullable: false));
            AlterColumn("dbo.Formations", "IdFormation", c => c.Short(nullable: false));
            AddPrimaryKey("dbo.Participation", new[] { "Candidat_IdCandidat", "Formation_IdFormation", "Formation_CodeFormateur" });
            AddPrimaryKey("dbo.Formations", new[] { "IdFormation", "CodeFormateur" });
            RenameColumn(table: "dbo.Formations", name: "Formateur_CodeFormateur", newName: "CodeFormateur");
            CreateIndex("dbo.Participation", new[] { "Formation_IdFormation", "Formation_CodeFormateur" });
            CreateIndex("dbo.Formations", "CodeFormateur");
            AddForeignKey("dbo.Formations", "CodeFormateur", "dbo.Formateurs", "CodeFormateur", cascadeDelete: true);
            AddForeignKey("dbo.Participation", new[] { "Formation_IdFormation", "Formation_CodeFormateur" }, "dbo.Formations", new[] { "IdFormation", "CodeFormateur" }, cascadeDelete: true);
        }
    }
}
