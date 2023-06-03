using System;
using UnityEngine;

public static class RRandom {

    public delegate long Generator(long seed);

    private static Generator DefaultGenerator = LinearCongruential;
    private static Generator NonNullGenerator(Generator generator) {
        return generator != null ? generator : DefaultGenerator;
    }

    public static long Tausworthe(long seed) {
        seed ^= seed >> 13;
        seed ^= seed << 18;
        return seed & 0x7fffffff;
    }

    public static long LinearCongruential(long seed, long a, long c, long m) {
        seed = (a * seed + c) % m;
        return seed;
    }
    
    public static long LinearCongruential(long seed) {
        // common params: https://en.wikipedia.org/wiki/Linear_congruential_generator#Parameters_in_common_use
        return LinearCongruential(seed, 1664525, 1013904223, 4294967296);
    }
    
    static long Offset = 0;
    public static long Random(Generator generator = null) {
        generator = generator != null ? generator : DefaultGenerator;
        var r = NonNullGenerator(generator)(Offset + DateTimeOffset.Now.ToUnixTimeMilliseconds());
        Offset = -2 * Offset + DateTimeOffset.Now.ToUnixTimeMilliseconds() - 1;
        return r;
    }

    public static bool Bool(long seed, float odds, Generator generator = null) {
        return (Math.Abs(NonNullGenerator(generator)(seed)) % 100) < (odds * 100);
    }

    public static float Percent(long seed, Generator generator = null) {
        return (Math.Abs(NonNullGenerator(generator)(seed)) % 100) / 100f;
    }
    
    public static float Percent(Generator generator = null) {
        return Percent(RRandom.Random(), generator);
    }
    
    public static long Range(long seed, long min, long max, Generator generator = null) {
        var oldMin = min;
        min = min > max ? max : min; 
        max = oldMin > max ? oldMin : max; 
        var p = RRandom.Percent(seed, generator);
        return min + (long)(Mathf.Round((p * (max - min))));
    }
    
    public static long Range(long min, long max, Generator generator = null) {
        return Range(RRandom.Random(), min, max, generator);
    }
    
    public static float Range(float min, float max, Generator generator = null) {
        return Range(RRandom.Random(), min, max, generator);
    }
    
    public static int Range(int min, int max, Generator generator = null) {
        return (int) Mathf.Round(
            Range(RRandom.Random(), (float)min, (float)max, generator)
        );
    }
    
    public static float Range(long seed, float min, float max, Generator generator = null) {
        var oldMin = min;
        min = min > max ? max : min; 
        max = oldMin > max ? oldMin : max; 
        var p = RRandom.Percent(seed, generator);
        return min + (p * (max - min));
    }

    public static T GetRandomItem<T>(T[] array, long seed, Generator generator = null) {
        var rand = Range(seed, 0, array.Length, generator);
        return array[rand];
    }
    
    public static T GetRandomItem<T>(T[] array, Generator generator = null) {
        return GetRandomItem(array, RRandom.Random(), generator);
    }
}