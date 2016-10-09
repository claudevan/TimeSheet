namespace TimeSheet.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_DataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Marcacao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        DataMarcacao = c.DateTime(nullable: false),
                        EntradaManha = c.Long(),
                        SaidaManha = c.Long(),
                        EntradaTarde = c.Long(),
                        SaidaTarde = c.Long(),
                        Descricao = c.String(maxLength: 100),
                        DataAlteracao = c.DateTime(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Marcacao");
        }
    }
}
