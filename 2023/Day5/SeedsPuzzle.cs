namespace AdventOfCode._2023.Day5;

using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

public class SeedsPuzzle
{

    private readonly SeedRangeReader _seedRangeReader;
    private static Regex _numbers = new Regex(@"\d+");
    public SeedsPuzzle() : this(new SeedRangeReader())
    {
        
    }

    public SeedsPuzzle(SeedRangeReader seedRangeReader)
    {
        _seedRangeReader = seedRangeReader;

    }

    public (long Answer1, long Answer2) CalculateAnswers(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            throw new ArgumentException("Value cannot be null or empty.", nameof(filePath));
        }

        if (!File.Exists(filePath))
        {
            throw new InvalidOperationException($"Input file does not exist. File=\"{filePath}\"");
        }

        var file = File.ReadAllLines(filePath).Where(x => !string.IsNullOrEmpty(x)).ToList();
        var seeds = _numbers.Matches(file.First()).Select(m => long.Parse(m.Value)).OrderBy(x => x).ToList();

        var almanac = GetAlmanac(file);

        var lowestLocation = FindLowestLocation(seeds, almanac);

        var answer1 = lowestLocation;

        var seedRanges = _seedRangeReader.ReadSeedRange(file.First());

        var stopwatch = new Stopwatch();
        stopwatch.Start();

        var answer2 = Part2(almanac,  seedRanges);
        stopwatch.Stop();

        Console.WriteLine($"Time taken for pt 2: {stopwatch.ElapsedMilliseconds}ms");
        return (answer1, answer2);
    }

    private long Part2(Almanac almanac, List<MapRange> seedRanges)
    {
        var ranges = new List<List<MapRange>>
        {
            seedRanges
        };

        foreach (var almanacRange in almanac.MapRanges)
        {
            ranges.Add(MapRanges(ranges.Last(), almanacRange));
        }

        return ranges.Last().OrderBy(m => m.Start).First().Start;
    }

    private List<MapRange> MapRanges(List<MapRange> ranges, List<MapRange> mapRanges)
    {
        var result = new List<MapRange>();
        foreach (var range in ranges)
        {
            var overlappingRanges = mapRanges.Where(range.OverlappingRanges).ToList();
            result.AddRange(range.LeftJoin(overlappingRanges));
        }

        return result;
    }

    private Almanac GetAlmanac(List<string> file)
    {

        var location = 1;
        var seedToSoil = GetMapRanges(file, ref location).OrderBy(x => x.Start).ToList();
        var soilToFertilizer = GetMapRanges(file, ref location).OrderBy(x => x.Start).ToList();
        var fertilizerToWater = GetMapRanges(file, ref location).OrderBy(x => x.Start).ToList();
        var waterToLight = GetMapRanges(file, ref location).OrderBy(x => x.Start).ToList();
        var lightToTemperature = GetMapRanges(file, ref location).OrderBy(x => x.Start).ToList();
        var temperatureToHumidity = GetMapRanges(file, ref location).OrderBy(x => x.Start).ToList();
        var humidityToLocation = GetMapRanges(file, ref location).OrderBy(x => x.Start).ToList();

        var almanac = new Almanac(
            seedToSoil, soilToFertilizer, fertilizerToWater, waterToLight, lightToTemperature, temperatureToHumidity,
            humidityToLocation);
        return almanac;
    }

    private static long FindLowestLocation(List<long> seeds, Almanac almanac)
    {
        var lowestLocation = long.MaxValue;

        foreach (var seed in seeds)
        {
            var result = GetSeedLocation(almanac, seed);
            lowestLocation = result < lowestLocation ? result : lowestLocation;
        }

        return lowestLocation;
    }

    private static long GetSeedLocation(Almanac almanac, long seed)
    {
        var result = GetTargetNumber(almanac.SeedToSoil, seed);
        result = GetTargetNumber(almanac.SoilToFertilizer, result);
        result = GetTargetNumber(almanac.FertilizerToWater, result);
        result = GetTargetNumber(almanac.WaterToLight, result);
        result = GetTargetNumber(almanac.LightToTemperature, result);
        result = GetTargetNumber(almanac.TemperatureToHumidity, result);
        result = GetTargetNumber(almanac.HumidityToLocation, result);
        return result;
    }

    private static long GetTargetNumber(List<MapRange> seedToSoil, long seed)
    {
        long result = seedToSoil.FirstOrDefault(m => m.IsNumberInRange(seed))?.TryGetTargetNumber(seed, out result) == true
            ? result
            : seed;
        return result;
    }

    private List<MapRange> GetMapRanges(List<string> input, ref int location)
    {
        location++;
        var rawMaps = new List<MapRange>();
        while (location < input.Count)
        {
            var line = input.ElementAt(location);
            var matches = _numbers.Matches(line);

            if (matches.Any())
            {
                var mapRange = new MapRange(
                    long.Parse(matches.ElementAt(1).Value),
                    long.Parse(matches.ElementAt(0).Value),
                    long.Parse(matches.ElementAt(2).Value));

                rawMaps.Add(mapRange);

                location++;
            }
            else
            {
                break;
            }
        }

        return rawMaps;
    }
}