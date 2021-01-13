namespace Planny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'65d10bee-06f7-40b4-b24f-5e6688b14ef7', N'admin@planny.com', 0, N'ALRvZR08gf0muxNs7ppyfW0Axj777L9eu9NrKAaA5Ms7DW5knhfnG2hb9A8z/RfICg==', N'fd47a101-6190-48ac-a26e-ea4d142a2d13', NULL, 0, 0, NULL, 1, 0, N'admin@planny.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c1c46542-d4f5-4d96-89b0-07f40be45b26', N'guest@planny.com', 0, N'AGWPTKCFnselYLpy+abze67pASG5Zmz6HFgmwdJ1dosCQvXgmvdQUkKa1UvzaNAJww==', N'3755904f-e796-449b-8bfa-26b81f45dced', NULL, 0, 0, NULL, 1, 0, N'guest@planny.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9a305d77-ccba-4686-b806-3c4703fac69a', N'CanManageProject')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'65d10bee-06f7-40b4-b24f-5e6688b14ef7', N'9a305d77-ccba-4686-b806-3c4703fac69a')

");
        }
        
        public override void Down()
        {
        }
    }
}
