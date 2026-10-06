namespace GbpGridAgent;

public class SearchCampaign
{
    public int Id { get; set; }
    public string BusinessName { get; set; } = "";
    public string? BusinessPlaceId { get; set; }
    public string Keyword { get; set; } = "";
    public double CenterLatitude { get; set; }
    public double CenterLongitude { get; set; }
    public double RadiusMiles { get; set; }
    public int GridSize { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public List<GridPoint> GridPoints { get; set; } = new();
}

public class GridPoint
{
    public int Id { get; set; }
    public int CampaignId { get; set; }
    public int Row { get; set; }
    public int Column { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int? Rank { get; set; }          // null = business not found in results
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public List<SearchResult> Results { get; set; } = new();
}

public class SearchResult
{
    public int Id { get; set; }
    public int GridPointId { get; set; }
    public string? PlaceId { get; set; }
    public string BusinessName { get; set; } = "";
    public int Rank { get; set; }
    public double? Rating { get; set; }
    public int? ReviewCount { get; set; }
    public string? Category { get; set; }
}