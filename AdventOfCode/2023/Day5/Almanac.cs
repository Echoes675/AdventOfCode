namespace AdventOfCode._2023.Day5;

public record Almanac(
    List<MapRange> SeedToSoil, List<MapRange> SoilToFertilizer, List<MapRange> FertilizerToWater,
    List<MapRange> WaterToLight, List<MapRange> LightToTemperature, List<MapRange> TemperatureToHumidity,
    List<MapRange> HumidityToLocation)
{
    public List<List<MapRange>> MapRanges => new ()
    {
        SeedToSoil,
        SoilToFertilizer,
        FertilizerToWater,
        WaterToLight,
        LightToTemperature,
        TemperatureToHumidity,
        HumidityToLocation,
    };
};
