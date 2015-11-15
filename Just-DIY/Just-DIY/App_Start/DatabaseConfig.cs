namespace Just_DIY
{
    using System.Data.Entity;

    using Just_DIY.Data;
    using Just_DIY.Data.Migrations;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Just_DIYDbContext, Configuration>());
            Just_DIYDbContext.Create().Database.Initialize(true);
        }
    }
}