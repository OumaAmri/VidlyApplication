namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMemberShipeTable : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE  MemberShipTypes SET Name='Free' Where Id=1");
            Sql("UPDATE  MemberShipTypes SET Name='Monthly' Where Id=2");
            Sql("UPDATE  MemberShipTypes SET Name='Quarty' Where Id=3");
            Sql("UPDATE  MemberShipTypes SET Name='Year' Where Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
