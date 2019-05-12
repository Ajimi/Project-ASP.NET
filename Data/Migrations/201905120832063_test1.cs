namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidats",
                c => new
                    {
                        IdCandidat = c.Short(nullable: false, identity: true),
                        CIN = c.String(),
                        Email = c.String(),
                        Image = c.String(),
                        Nom = c.String(),
                        Password = c.String(),
                        Prenom = c.String(),
                        Formateur_CodeFormateur = c.Short(),
                    })
                .PrimaryKey(t => t.IdCandidat)
                .ForeignKey("dbo.Formateurs", t => t.Formateur_CodeFormateur)
                .Index(t => t.Formateur_CodeFormateur);
            
            CreateTable(
                "dbo.Formateurs",
                c => new
                    {
                        CodeFormateur = c.Short(nullable: false, identity: true),
                        Niveau = c.String(),
                        NomFormateur = c.String(),
                    })
                .PrimaryKey(t => t.CodeFormateur);
            
            CreateTable(
                "dbo.Formations",
                c => new
                    {
                        IdFormation = c.Short(nullable: false),
                        CodeFormateur = c.Short(nullable: false),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        Description = c.String(),
                        Duree = c.DateTime(nullable: false),
                        NbParticipants = c.Int(nullable: false),
                        NomFormation = c.String(),
                        Prix = c.Int(nullable: false),
                        TypeFormation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdFormation, t.CodeFormateur })
                .ForeignKey("dbo.Formateurs", t => t.CodeFormateur, cascadeDelete: true)
                .Index(t => t.CodeFormateur);
            
            CreateTable(
                "dbo.Participation",
                c => new
                    {
                        Candidat_IdCandidat = c.Short(nullable: false),
                        Formation_IdFormation = c.Short(nullable: false),
                        Formation_CodeFormateur = c.Short(nullable: false),
                    })
                .PrimaryKey(t => new { t.Candidat_IdCandidat, t.Formation_IdFormation, t.Formation_CodeFormateur })
                .ForeignKey("dbo.Candidats", t => t.Candidat_IdCandidat, cascadeDelete: true)
                .ForeignKey("dbo.Formations", t => new { t.Formation_IdFormation, t.Formation_CodeFormateur }, cascadeDelete: true)
                .Index(t => t.Candidat_IdCandidat)
                .Index(t => new { t.Formation_IdFormation, t.Formation_CodeFormateur });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Participation", new[] { "Formation_IdFormation", "Formation_CodeFormateur" }, "dbo.Formations");
            DropForeignKey("dbo.Participation", "Candidat_IdCandidat", "dbo.Candidats");
            DropForeignKey("dbo.Candidats", "Formateur_CodeFormateur", "dbo.Formateurs");
            DropForeignKey("dbo.Formations", "CodeFormateur", "dbo.Formateurs");
            DropIndex("dbo.Participation", new[] { "Formation_IdFormation", "Formation_CodeFormateur" });
            DropIndex("dbo.Participation", new[] { "Candidat_IdCandidat" });
            DropIndex("dbo.Formations", new[] { "CodeFormateur" });
            DropIndex("dbo.Candidats", new[] { "Formateur_CodeFormateur" });
            DropTable("dbo.Participation");
            DropTable("dbo.Formations");
            DropTable("dbo.Formateurs");
            DropTable("dbo.Candidats");
        }
    }
}
