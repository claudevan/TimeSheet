namespace TimeSheet.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class permite_data_alteracao_nula : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Marcacao", "DataAlteracao", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Marcacao", "DataAlteracao", c => c.DateTime(nullable: false));
        }
    }
}
