using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GbpGridAgent;

namespace GBPGridAgent
{
    public static class GridGenerator
    {
        public static List<GridPoint> Generate(
            double centerLat,
            double centerLng,
            double radiusMiles,
            int gridSize
        )
        {
            var points = new List<GridPoint>();

            // 1 degree latitude ≈ 69 miles. Longitude shrinks by cos(latitude).
            double latMilesPerDeg = 69.0;
            double lngMilesPerDeg = 69.0 * Math.Cos(centerLat * Math.PI / 180.0);

            // Spacing between points so the grid edges sit at +/- radius.
            // gridSize points means (gridSize - 1) gaps.
            int gaps = Math.Max(gridSize - 1, 1);
            double stepMiles = (radiusMiles * 2) / gaps;

            double startOffset = radiusMiles; // top-left corner is -radius lng, +radius lat

            for (int row = 0; row < gridSize; row++)
            {
                // Row 0 = northernmost (highest latitude)
                double latMilesFromCenter = startOffset - (row * stepMiles);
                double lat = centerLat + (latMilesFromCenter / latMilesPerDeg);

                for (int col = 0; col < gridSize; col++)
                {
                    double lngMilesFromCenter = -startOffset + (col * stepMiles);
                    double lng = centerLng + (lngMilesFromCenter / lngMilesPerDeg);

                    points.Add(new GridPoint
                    {
                        Row = row,
                        Column = col,
                        Latitude = Math.Round(lat, 6),
                        Longitude = Math.Round(lng, 6)
                    });
                }
            }
            return points;
        }

    }
}