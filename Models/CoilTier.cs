namespace TFGCalculator.Models;

public enum CoilMachineType
{
    None = 0,
    ElectricBlastFurnace = 1,
    MultiSmelter = 2,
    PyrolyseOven = 3,
    CrackingUnit = 4
}

public class CoilTier
{
    public int Level { get; set; }
    public string Name { get; set; } = "";
    public string IconPath { get; set; } = "";
    public int Temperature { get; set; }

    public static readonly List<CoilTier> AllCoils = new()
    {
        new() { Level = 1, Name = "Cupronickel", IconPath = "images/coils/coil_1.png", Temperature = 1800 },
        new() { Level = 2, Name = "Kanthal",     IconPath = "images/coils/coil_2.png", Temperature = 2700 },
        new() { Level = 3, Name = "Nichrome",    IconPath = "images/coils/coil_3.png", Temperature = 3600 },
        new() { Level = 4, Name = "RTM Alloy",   IconPath = "images/coils/coil_4.png", Temperature = 4500 },
        new() { Level = 5, Name = "HSS-G",       IconPath = "images/coils/coil_5.png", Temperature = 5400 },
        new() { Level = 6, Name = "Naquadah",    IconPath = "images/coils/coil_6.png", Temperature = 7200 },
        new() { Level = 7, Name = "Trinium",     IconPath = "images/coils/coil_7.png", Temperature = 9001 },
        new() { Level = 8, Name = "Tritanium",   IconPath = "images/coils/coil_8.png", Temperature = 10800 },
    };

    public static CoilTier GetByLevel(int level) =>
        AllCoils.FirstOrDefault(c => c.Level == level) ?? AllCoils[0];

    // === Multi Smelter ===
    public static readonly int[] MSParallels = { 32, 64, 64, 128, 128, 256, 256, 512 };
    public static readonly double[] MSEnergyMult = { 0.5, 1, 0.5, 1, 0.5, 1, 0.5, 1 };

    // === Pyrolyse Oven ===
    public static readonly double[] POSpeedMult = { 0.75, 1, 1.5, 2, 2.5, 3, 3.5, 4 };

    // === Cracking Unit ===
    public static readonly double[] CUEnergyMult = { 1, 0.9, 0.8, 0.7, 0.6, 0.5, 0.4, 0.3 };
}