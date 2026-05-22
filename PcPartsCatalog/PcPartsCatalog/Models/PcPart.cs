using SQLite;

namespace PcPartsCatalog.Models;

public class PcPart
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Name { get; set; } = "";
    public string Category { get; set; } = "";
    public string Manufacturer { get; set; } = "";
    public double Price { get; set; }
    public string Description { get; set; } = "";
}