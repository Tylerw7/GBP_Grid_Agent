using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;


namespace GbpGridAgent;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<SearchCampaign> Campaigns => Set<SearchCampaign>();
    public DbSet<GridPoint> GridPoints => Set<GridPoint>();
    public DbSet<SearchResult> SearchResults => Set<SearchResult>();
}