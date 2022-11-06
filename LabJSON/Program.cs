using System.Text.Json;
using System.Xml.Serialization;

public class ExportProduct
{
    protected string name;
    public string Name { get { return name; } set { name = value; } }

    protected string country;
    public string Country { get { return country; } set { country = value; } }

    protected float volume;
    public float Volume { get { return volume; } set { volume = (value >= 0 ? value : 0); } }

    public ExportProduct(string name, string country, float volume)
    {
        this.name = name;
        this.country = country;
        this.volume = volume;
    }

    public ExportProduct()
    {

    }

    public override string ToString()
    {
        return $"Exported Products Data: Name: '{name}', Country: '{country}', Volume: '{volume}'. ";
    }


}

public class ExportedProducts
{
    public List<ExportProduct> exportedproducts = new List<ExportProduct>();

    public ExportedProducts()
    {

    }

    public void Add(string name, string country, float volume)
    {
        exportedproducts.Add(new ExportProduct(name, country, volume));
    }

    public void CreatePO(string filename)
    {
        string json = JsonSerializer.Serialize(exportedproducts);

        File.WriteAllText(filename, json);
    }

    public void ReadPO(string filename)
    {
        string json = File.ReadAllText(filename);
        this.exportedproducts = JsonSerializer.Deserialize<List<ExportProduct>>(json);
    }

    public void FindByMostExpensive()
    {

        var mostexpensive = this.exportedproducts.Max(item => item.Volume);

        float mostexpensiveproduct = mostexpensive;

        Console.WriteLine();
        Console.WriteLine($"Most expensive product volume is: {mostexpensiveproduct}");
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        string fileName = @"C:\Users\Sonya\source\repos\LabJSON\json1.json";

        ExportedProducts exportedproducts = new ExportedProducts();

        exportedproducts.Add("Xiomi", "China", 10000);
        exportedproducts.Add("IPhone", "USA", 9900);
        exportedproducts.Add("MacBook", "USA", 100);
        exportedproducts.Add("Camera", "China", 2000);
        exportedproducts.Add("Rug", "Turkey", 6000);
        exportedproducts.Add("Pasta", "Italia", 12000);
        exportedproducts.Add("IMac", "USA", 2100);
        exportedproducts.Add("Plade", "China", 2000);
        exportedproducts.Add("Car", "Spain", 600);
        exportedproducts.Add("Blender", "Mexica", 200);

        exportedproducts.CreatePO(fileName);

        ExportedProducts exportedproducts2 = new ExportedProducts();

        exportedproducts2.ReadPO(fileName);

        foreach (ExportProduct exportproduct in exportedproducts2.exportedproducts)
        {
            Console.WriteLine(exportproduct.ToString());
        }

        exportedproducts2.FindByMostExpensive();

        foreach (ExportProduct exportproduct in exportedproducts2.exportedproducts)
        {
            Console.WriteLine(exportproduct.ToString());
        }

        Console.WriteLine();

        var task = exportedproducts.exportedproducts
            .GroupBy(group => group.Volume, group => group.Country)
            .Select(item => new { item.Key, Value = item.Count() });

        foreach (var item in task)
        {
            {
                Console.WriteLine($"Volume is: {item.Key}, from {item.Value} country.");
            }
            Console.WriteLine();
        }
    }
}