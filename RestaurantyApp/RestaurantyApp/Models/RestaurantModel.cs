using System.Text.Json.Serialization;

namespace RestaurantyApp.Models;

public class PhotonResponse
{
    [JsonPropertyName("features")]
    public List<Feature> Features { get; set; } = new();
}

public class Feature
{
    [JsonPropertyName("properties")]
    public Properties Properties { get; set; } = new();

    [JsonPropertyName("geometry")]
    public Geometry Geometry { get; set; } = new();
}

public class Properties
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("street")]
    public string? Street { get; set; }

    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("postcode")]
    public string? Postcode { get; set; }
}

public class Geometry
{
    [JsonPropertyName("coordinates")]
    public List<double> Coordinates { get; set; } = new();
}
