namespace Assinment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeDatabase2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PassWord", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "PassWord");
        }
    }
}
