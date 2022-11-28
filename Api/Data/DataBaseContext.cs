namespace api.Data
{
    public class DataBaseContext : DbContext
    {
        string connectionString = Configuration.Configuration.ConnectionString;
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(connectionString);
    }
}