namespace ASP.NET_CarsAuction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "IsCheck", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cars", "DateTimeLot", c => c.DateTime(nullable: false));
            AddColumn("dbo.Cars", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "UserName");
            DropColumn("dbo.Cars", "DateTimeLot");
            DropColumn("dbo.Cars", "IsCheck");
        }
    }
}
