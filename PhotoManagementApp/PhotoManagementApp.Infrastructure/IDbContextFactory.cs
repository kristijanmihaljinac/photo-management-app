namespace PhotoManagementApp.Infrastructure
{
    public interface IDbContextFactory
    {
        PhotoManagementDbContext Create();
    }
}
