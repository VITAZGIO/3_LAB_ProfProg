using PcPartsCatalog.Models;

namespace PcPartsCatalog.Services;

public class ApiService
{
    public async Task<List<PcPart>> GetDemoPartsAsync()
    {
        await Task.Delay(1000);

        return new List<PcPart>
        {
            new PcPart
            {
                Name = "Intel Core i5-10505",
                Category = "Процессор",
                Manufacturer = "Intel",
                Price = 18000,
                Description = "6 ядер, 12 потоков"
            },

            new PcPart
            {
                Name = "RTX 3060",
                Category = "Видеокарта",
                Manufacturer = "NVIDIA",
                Price = 32000,
                Description = "12 GB видеопамяти"
            },

            new PcPart
            {
                Name = "Kingston Fury 32GB",
                Category = "Оперативная память",
                Manufacturer = "Kingston",
                Price = 9000,
                Description = "DDR4 3200 MHz"
            }
        };
    }
}